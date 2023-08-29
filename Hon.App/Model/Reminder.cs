namespace Hon.Model;

public record Reminder
{
    public int ReminderId { get; set; }
    public string? ReminderName { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateTime{ get; set; } = DateTime.UtcNow;
}