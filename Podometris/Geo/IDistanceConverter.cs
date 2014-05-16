namespace NExtra.Geo
{
    public interface IDistanceConverter
    {
        /// <summary>
        /// Convert kilometers to miles.
        /// </summary>
        double ConvertKilometersToMiles(double kilometers);

        /// <summary>
        /// Convert miles to kilometers.
        /// </summary>
        double ConvertMilesToKilometers(double miles);
    }
}
