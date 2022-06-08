namespace ConceptsCSharp_And_ASPNetCore.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime Tomorrow(this DateTime date)
        {
            return date.AddDays(1);
        }
    }
}
