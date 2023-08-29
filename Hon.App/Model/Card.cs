namespace Hon.Model;

public record Card
{
    public int CardId { get; set; }
    public int? CategoryId { get; init; } 
    public string? CardName { get; set;}
    public string? CardContent { get; set; }
    public int? ReminderId { get; set; }
    public virtual Reminder? Reminder{ get; set; }
    public virtual Category? Category{ get; set; }
}