using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using NExtra.Geo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Podometris
{
  public partial class MainPage : PhoneApplicationPage
  {
    private GeoCoordinateWatcher _watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
    private MapPolyline _line;
    private DispatcherTimer _timer = new DispatcherTimer();
    private long _startTime;

    public MainPage()
    {
      InitializeComponent();

      // create a line which illustrates the run
      _line = new MapPolyline();
      _line.StrokeColor = Colors.Red;
      _line.StrokeThickness = 5;
      Map.MapElements.Add(_line);

      _watcher.PositionChanged += Watcher_PositionChanged;

      _timer.Interval = TimeSpan.FromSeconds(1);
      _timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      TimeSpan runTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - _startTime);
      timeLabel.Text = runTime.ToString(@"hh\:mm\:ss");
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
      if (_timer.IsEnabled)
      {
        _watcher.Stop();
        _timer.Stop();
        StartButton.Content = "Start";
          
       TimeSpan runTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - _startTime);

        try
        {
            if (runTime.TotalSeconds > 0)
            {
                Stats stat = new Stats() { Km = _kilometres, Time = runTime.ToString(@"hh\:mm\:ss"), Date = DateTime.Now };
                this.Write(stat);
            }
        }
        catch (Exception)
        {

        }

      }
      else
      {
        _watcher.Start();
        _timer.Start();
        _startTime = System.Environment.TickCount;
        StartButton.Content = "Stop";
      }
    }

    private ObservableCollection<Stats> Read()
    {
        if (IsolatedStorageSettings.ApplicationSettings.Contains("stats"))
        {
            List<Stats> myList = new List<Stats>();
            myList = (List<Stats>)IsolatedStorageSettings.ApplicationSettings["stats"];
            ObservableCollection<Stats> myObs = new ObservableCollection<Stats>(myList);
            return myObs;
        }
        else
        {
            return new ObservableCollection<Stats>();
        }

    }


    private void Write(Stats stats)
    {
        ObservableCollection<Stats> data = this.Read();
        data.Add(stats);

        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        settings.Remove("stats");
        settings.Add("stats", data.ToList());
        settings.Save();

    }

    //ID_CAP_LOCATION
    private double _kilometres;
    private long _previousPositionChangeTick;

    private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
    {
      var coord = new GeoCoordinate(e.Position.Location.Latitude, e.Position.Location.Longitude);

      if (_line.Path.Count > 0)
      {
        var previousPoint = _line.Path.Last();
        var distance = coord.GetDistanceTo(previousPoint);
        var millisPerKilometer = (1000.0 / distance) * (System.Environment.TickCount - _previousPositionChangeTick);
        _kilometres += distance / 1000.0;

        //paceLabel.Text = TimeSpan.FromMilliseconds(millisPerKilometer).ToString(@"mm\:ss");
        TimeSpan runTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - _startTime);
        paceLabel.Text = string.Format("{0:f2}",_kilometres/runTime.TotalHours);
        distanceLabel.Text = string.Format("{0:f2} km", _kilometres);
        caloriesLabel.Text = string.Format("{0:f0}", _kilometres * 65);

        PositionHandler handler = new PositionHandler();
        var heading = handler.CalculateBearing(new Position(previousPoint), new Position(coord));
        Map.SetView(coord, Map.ZoomLevel, heading, MapAnimationKind.Parabolic);

        ShellTile.ActiveTiles.First().Update(new IconicTileData()
        {
          Title = "Podometris",
          WideContent1 = string.Format("{0:f2} km", _kilometres),
          WideContent2 = string.Format("{0:f0} calories", _kilometres * 65),
        });
      }
      else
      {
        Map.Center = coord;
      }

      _line.Path.Add(coord);
      _previousPositionChangeTick = System.Environment.TickCount;
    }

    // List of objectives
    private void ApplicationBarIconButton_Objectives(object sender, EventArgs e)
    {
        NavigationService.Navigate(new Uri("/Objectives.xaml", UriKind.Relative));
    }

    // Quit the application
    private void  ApplicationBarIconButton_Exit(object sender, EventArgs e)
    {
        Application.Current.Terminate();    
    }

    private void ApplicationBarIconButton_Share(object sender, EventArgs e)
    {
        if (!_timer.IsEnabled)
        {
            TimeSpan runTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - _startTime);
            ShareStatusTask shareStatusTask = new ShareStatusTask();
            shareStatusTask.Status = "J'ai parcouru " + string.Format("{0:f2} km", _kilometres) + " en " + runTime.ToString(@"hh\:mm\:ss") + " et perdu " + string.Format("{0:f0}", _kilometres * 65) + " calories ";
            shareStatusTask.Show();
        }
       
    }
  }
}