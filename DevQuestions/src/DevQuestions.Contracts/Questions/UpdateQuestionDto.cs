namespace DevQuestions.Contracts.Questions;

public record UpdateQuestionDto(string Title, string Body, Guid UserId, Guid[] TagsIds);