using AutoMapper;
using Base.Mappers;
using Domain.Studying_logic;
using BLLPersonOnCurriculum = BLL.DTO.Studying_logic.PersonOnCurriculum;

namespace App.BLL.Mappers.Studying_logic;

public class PersonOnCurriculumMapper : BaseMapper<AppUserOnCurriculum, BLLPersonOnCurriculum>
{
    public PersonOnCurriculumMapper(IMapper mapper) : base(mapper)
    {
    }
}