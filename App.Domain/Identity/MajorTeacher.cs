using Base.Domain;
using Domain.Studying_logic;

namespace Domain.Identity;

public class MajorTeacher : DomainEntityId
{
    public Guid TeacherId { get; set; }
    public SubjectTeacher? Teacher { get; set; }
    
    public Guid StudentId { get; set; }
    public AppUserOnCurriculum? Student { get; set; }

    public DateTime From { get; set; }
    public DateTime? Until { get; set; }
}