using AutoMapper;
using Base.Mappers;
using DomainJuryMember = Domain.Competitions.JuryMember;
using BLLJuryMember = BLL.DTO.Competitions.JuryMember;

namespace App.BLL.Mappers.Competitions;

public class JuryMemberMapper : BaseMapper<DomainJuryMember, BLLJuryMember>
{
    public JuryMemberMapper(IMapper mapper) : base(mapper)
    {
    }
}