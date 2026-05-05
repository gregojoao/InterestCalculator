using InterestCalculator.Domain.Notifications.Contracts;
using InterestCalculator.Domain.Notifications.Entities;

namespace InterestCalculator.Domain.Notifications;

public abstract class Notifiable : INotifiable
{
    public IReadOnlyCollection<Notification> Notifications => _notifications.ToArray();
    private readonly List<Notification> _notifications = new();

    public bool IsInvalid => Notifications.Any();
    public bool IsValid => !IsInvalid;

    public void AddNotification(Notification notification)
    {
        if (notification != null)
            _notifications.Add(notification);
    }

    public void AddNotifications(IEnumerable<Notification> notifications)
    {
        foreach (var notification in notifications)
            AddNotification(notification);
    }

    public string NotificationsMessage() =>
        string.Join("; ", Notifications.Select(x => x.Message)) + ";";
}