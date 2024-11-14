namespace knowledge.common.helpers
{
    public class DateTimeHelper
    {
        public static DateOnly DateTimeToDateOnly(DateTime date)
            => DateOnly.Parse(date.ToString("yyyy-MM-dd"));

        public static DateTime DateOnlyToDateTime(DateOnly dateOnly)
            => new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);        
    }
}