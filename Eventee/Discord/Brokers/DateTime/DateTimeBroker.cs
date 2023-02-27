namespace ProfileAPI.Brokers.DateTime;

public class DateTimeBroker : IDateTimeBroker
{
    public System.DateTime GetCurrentTimeUtc() => System.DateTime.UtcNow;
}