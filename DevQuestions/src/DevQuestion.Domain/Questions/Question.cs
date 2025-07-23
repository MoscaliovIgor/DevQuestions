namespace DevQuestion.Domain.Questions;

public class Question
{
    public Question(
        Guid id,
        string title,
        string text,
        Guid userId,
        Guid? screenshotId,
        IEnumerable<Guid> tags) // Почему Inumerable? потому что из вне можем положить любую коллекцию
    {
        Id = id;
        Title = title;
        Text = text;
        UserId = userId;
        ScreenshotId = screenshotId;
        Tags = tags.ToList();
    }
    public Guid Id { get; set; } // ид вопроса

    public DateTime CreatedAt { get; set; } // дата создания

    public string Title { get; set; }

    public string Text { get; set; }

    public Guid? ScreesShotId { get; set; } // что то важное

    public Guid UserId { get; set; } // ид того кто оставил вопрос
    public Guid? ScreenshotId { get; }

    public List<Answer> Answers { get; set; } = []; // список ответов

    public Answer? Solution { get; set; } // знак ? после имени типа (Answer?) означает, что свойство может быть null

    public List<Guid> Tags { get; set; }

    public QuestionStatus Status { get; set; } = QuestionStatus.OPEN;

    // public List<Guid> Comments { get; set; } = []; // если большой сервис - может потребовать много ресурсов.
}

public enum QuestionStatus
{
    /// <summary>
    /// Статус открыт
    /// </summary>
    OPEN,

    /// <summary>
    /// Статус решен
    /// </summary>
    RESOLVED,
}