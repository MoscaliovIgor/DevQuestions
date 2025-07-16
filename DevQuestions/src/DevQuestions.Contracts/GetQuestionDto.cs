namespace DevQuestions.Contracts;

public record GetQuestionDto(string Search, Guid[] TagsIds, int page);