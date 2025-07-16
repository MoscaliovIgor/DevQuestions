namespace DevQuestion.Domain.Questions;

public class Question
{
    public Guid Id { get; set; } // ид вопроса

    public DateTime CreatedAt { get; set; } // дата создания

    public required string Title { get; set; }

    public required string Text { get; set; }

    public Guid? ScreesShotId { get; set; } // что то важное

    public required Guid UserId { get; set; } // ид того кто оставил вопрос

    public List<Answer> Answers { get; set; } = []; // список ответов

    public Answer? Solution { get; set; } // знак ? после имени типа (Answer?) означает, что свойство может быть null

    public List<Guid> Tags { get; set; } = [];

    // public List<Guid> Comments { get; set; } = []; // если большой сервис - может потребовать много ресурсов.
}