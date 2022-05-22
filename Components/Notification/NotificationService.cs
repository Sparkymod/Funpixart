using System.Collections.ObjectModel;

namespace RDK.Components.Notification
{
    public interface INotificationService
    {
        ObservableCollection<NotificationMessage> Messages { get; }
        void Notify(NotificationMessage message);
        void Notify(NotificationType severity);
        void Notify(NotificationType severity, string content);
        void Notify(NotificationType severity, string content, string footer);
    }

    public class NotificationService : INotificationService
    {
        public ObservableCollection<NotificationMessage> Messages { get; private set; } = new ObservableCollection<NotificationMessage>();

        public void Notify(NotificationMessage message)
        {
            message ??= NotificationMessage.Default;

            if (!Messages.Contains(message))
            {
                Messages.Add(message);
            }
        }

        /// <summary>
        /// Notify with just the notification type.
        /// </summary>
        /// <param name="severity">Notification type.</param>
        public void Notify(NotificationType severity) => Notify(new NotificationMessage() { Severity = severity });

        /// <summary>
        /// Notify with notification type and a content.
        /// </summary>
        /// <param name="severity">Notification type.</param>
        /// <param name="content">Message of the notification.</param>
        public void Notify(NotificationType severity, string content) => Notify(new NotificationMessage() { Message = content, Severity = severity });

        /// <summary>
        /// Notify with notification type, content and footer.
        /// </summary>
        /// <param name="severity">Notification type.</param>
        /// <param name="content">Message of the notification.</param>
        /// <param name="footer">State or Code information about the notification prompt.</param>
        public void Notify(NotificationType severity, string content, string footer) => Notify(new NotificationMessage() { Message = content, Severity = severity, Footer = footer });

    }
}
