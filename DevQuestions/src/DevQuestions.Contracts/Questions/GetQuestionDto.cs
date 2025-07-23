namespace DevQuestions.Contracts.Questions;

public record GetQuestionDto(string Search, Guid[] TagsIds, int page);