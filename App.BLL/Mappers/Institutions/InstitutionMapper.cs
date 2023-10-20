using AutoMapper;
using Base.Mappers;
using DomainInstitution = Domain.Competitions.Institution;
using BLLInstitution = BLL.DTO.Institutions.Institution;

namespace App.BLL.Mappers.Institutions;

public class InstitutionMapper : BaseMapper<DomainInstitution, BLLInstitution>
{
    public InstitutionMapper(IMapper mapper) : base(mapper)
    {
    }
}