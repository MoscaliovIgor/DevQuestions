using DevQuestion.Domain.Questions;
using DevQuestions.Contracts;
using DevQuestions.Contracts.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DevQuestions.Application.Questions;

public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository _questionsRepository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;

    // конструктор
    public QuestionsService(
        IQuestionsRepository questionsRepository,
        IValidator<CreateQuestionDto> validator,
        ILogger<QuestionsService> logger)
    {
        _questionsRepository = questionsRepository;
        _validator = validator;
        _logger = logger;
    }

    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        // валидация входных данных
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // валидация бизнес логики
        int openUserQuestionsCount = await _questionsRepository
            .GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);

        if (openUserQuestionsCount > 3)
        {
            throw new Exception("Пользователь не может открыть больше трех вопросов");
        }

        // создание сущности question
        var questionId = Guid.NewGuid();

        var question = new Question(
            questionId,
            questionDto.Title,
            questionDto.Text,
            questionDto.UserId,
            null,
            questionDto.TagsIds);

        // сохранение сущности Question в бд
        await _questionsRepository.AddAsync(question, cancellationToken);

        // логирование об успешном или не успешном сохранении
        _logger.LogInformation("Question created with id: {questionId}", questionId);

        return questionId;
    }

    // public async Task Update(
    //     Guid questionId,
    //     UpdateQuestionDto request,
    //     CancellationToken cancellationToken)
    // {
    // }
    //
    // public async Task Delete(Guid questionId, CancellationToken cancellationToken)
    // {
    // }
    //
    // public async Task SelectSolution(
    //     Guid questionId,
    //     Guid answerId,
    //     CancellationToken cancellationToken)
    // {
    // }
    //
    // public async Task AddAnswer(
    //     Guid questionId,
    //     AddAnswerDto request,
    //     CancellationToken cancellationToken)
    // {
    // }
}