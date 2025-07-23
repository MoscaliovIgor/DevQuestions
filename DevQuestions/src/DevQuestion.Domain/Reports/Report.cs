namespace DevQuestion.Domain.Reports;

public class Report
{
    public Guid Id { get; set; }

    public required Guid UserId { get; set; } // какой пользователь оставил жалобу

    public required Guid ReportedUserId { get; set; } // на какого пользователя была жалоба

    public required string Reason { get; set; } // причина жалобы

    public required string ReasonDescription { get; set; } // описание жалобы

    public DateTime CreatedAt { get; set; } // дата создания жалобы

    public DateTime? UpdatedAt { get; set; }

    public Guid ResolvedByUserId { get; set; } // кем закрыта

    public ReportStatus ReportStatus { get; set; } = ReportStatus.OPEN; // статус по умолчанию опен
}