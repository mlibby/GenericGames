namespace GenericGames.Shared.Notifications;

public partial class Notifications_Message
{
    [Parameter]
    public NotificationMessage? Message { get; set; }

    public void Close()
    {
        if (Message is not null)
        {
            NotificationService.Messages.Remove(Message);
            Message = null;
        }
    }

    private Dictionary<NotificationSeverity, string> _iconClasses = new()
    {
        { NotificationSeverity.Error, "icon-sad-face" },
        { NotificationSeverity.Info, "icon-speech" },
        { NotificationSeverity.Success, "icon-glasses-face" },
        { NotificationSeverity.Warning, "icon-shock-face" }
    };

    private string IconClass() => _iconClasses[Message!.Severity];

    private string MessageClass() => Message!.Severity.ToString().ToLower();
}
