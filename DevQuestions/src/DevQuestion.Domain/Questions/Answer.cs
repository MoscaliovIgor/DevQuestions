namespace DevQuestion.Domain.Questions;

public class Answer
{
    public Guid Id { get; set; } // id ответа

    public DateTime CreatedAt { get; set; } // дата создания

    public required Guid UserId { get; set; } // ид того кто оставил ответ

    public required string Text { get; set; } // текст ответа

    public required Question Question { get; set; }

    public required Answer Parent { get; set; }

    public List<Guid> Tags { get; set; } = []; // список тегов
}