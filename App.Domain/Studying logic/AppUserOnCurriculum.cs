using Base.Domain;
using Domain.Identity;

namespace Domain.Studying_logic;

public class AppUserOnCurriculum : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public Guid CurriculumId { get; set; }
    public Curriculum? Curriculum { get; set; }

    public DateTime From { get; set; }
    public DateTime Until { get; set; }

    public ICollection<MajorTeacher>? MajorTeachers { get; set; }
    public ICollection<AppUserOnSubject>? AppUserOnSubjects { get; set; }
}