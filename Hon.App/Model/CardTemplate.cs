namespace Hon.Model;

public record CardTemplate
{
    public CardTemplate()
    {
        Card = new Card(){CardId = 0};
    }
    public int CardTemplateId { get; set; }
    public virtual Card Card { get; set; }

}