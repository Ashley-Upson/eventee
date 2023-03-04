namespace ProfileAPI.Brokers.DateTime;

public interface IDateTimeBroker
{
    System.DateTime GetCurrentTimeUtc();
}