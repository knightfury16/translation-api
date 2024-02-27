using translation.domain.Enum;

namespace translation.domain.Entity;

public class Message: BaseEntity
{
    public string Text { get; set; }
    public Language Language { get; set; }

    public Message(string text,Language language) : base()
    {
        Text = text;
        Language = language;
    }

    public override string ToString()
    {
        return Text;
    }
}
