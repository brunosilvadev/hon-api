namespace Hon.Model;

public record Card
{
    public int CardId { get; set; }
    public int? CategoryId { get; init; } 
    public string? CardName { get; set;}
    public string? CardContent { get; set; }
    public virtual Category? Category{ get; set; }
}