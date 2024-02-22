using translation.domain.Enum;

namespace translation.domain;

public class Message: BaseEntity
{
    public string Text { get; set; }

    public Message(string text): base()
    {
        Text = text;
    }
}
