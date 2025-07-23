namespace DevQuestions.Contracts.Questions;

public record CreateQuestionDto(string Title, string Text, Guid UserId, Guid[] TagsIds); // record => get init