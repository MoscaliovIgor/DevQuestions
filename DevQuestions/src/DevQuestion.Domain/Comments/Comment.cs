namespace DevQuestion.Domain.Comments;

public class Comment
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public Comment? Parent { get; set; }
    
    public required Guid EntityId { get; set; } // это сущность для которой оставили комментарий (вопрос, ответ, видео, коммент...)
    
    // когда в логике нам нужен тип того, к чему делаем комментарий 
    // public string EntityType { get; set; } // чтобы понимать под какой сущностью мы оставили комментарий (вопрос, ответ, видео, коммент...)

    public List<Comment> Children { get; set; } = [];
}