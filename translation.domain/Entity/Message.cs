using translation.domain.Enum;

namespace translation.domain.Entity;

public class Message: BaseEntity
{
    public string Text { get; set; }

    public Message(string text): base()
    {
        Text = text;
    }

    public override string ToString()
    {
        return Text;
    }
}
