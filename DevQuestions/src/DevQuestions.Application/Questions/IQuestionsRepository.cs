using DevQuestion.Domain.Questions;

namespace DevQuestions.Application.Questions;

public interface IQuestionsRepository
{
    Task<Guid> AddAsync(Question question, CancellationToken cancellationToken);

    Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken);

    Task<Guid> DeleteAsync(Question question, CancellationToken cancellationToken);

    Task<Question> GetByIdAsync(Question question, CancellationToken cancellationToken);

    Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken);
}