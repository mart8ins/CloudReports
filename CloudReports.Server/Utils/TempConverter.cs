namespace CloudReports.Server.Utils
{
    public class TempConverter
    {
        public static double KelvinToCelsius(double tempKelvin)
        {
            return Math.Round(tempKelvin - 273.15, 1);
        }
    }
}
