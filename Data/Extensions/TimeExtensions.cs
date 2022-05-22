namespace RDK.Data.Extensions
{
    public static class TimeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ParseToDatabase(this DateTime date) => DateTime.Parse(string.Format("{0,4:00}-{1,2:00}-{2,2:00} {3,2:00}:{4,2:00}:{5,2:00}", date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second));
    }
}
