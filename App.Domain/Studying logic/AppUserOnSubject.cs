using Base.Domain;
using Domain.Identity;

namespace Domain.Studying_logic;

public class AppUserOnSubject : DomainEntityId
{
    public Guid AppUserOnCurriculumId { get; set; }
    public AppUserOnCurriculum? AppUserOnCurriculum { get; set; }

    public Guid SubjectInCurriculumId { get; set; }
    public SubjectInCurriculum? SubjectInCurriculum { get; set; }

    public DateTime From { get; set; }
    public DateTime Until { get; set; }
}