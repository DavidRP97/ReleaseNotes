namespace ReleaseNotes.Service.Utils
{
    public enum FeedbackFrom
    {
        PDV = 1,
        PowerServer = 2
    }
    public enum Priority
    {
        None = 0,
        High = 1,
        Medium = 2,
        Low = 3,

    }
    public enum Status
    {
        None = 0,
        Resolved = 1,
        Waiting = 2
    }

    public enum Filters
    {
        None = 0,
        PriorityHigh = 1,
        PriorityMedium = 2,
        PriorityLow = 3,
        OrderByClientName = 4,
        StatusWaiting = 5,
        StatusResolved = 6
    }
}
