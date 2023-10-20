using AutoMapper;
using Base.Mappers;
using Domain.Studying_logic;
using BLLPersonOnSubject = BLL.DTO.Studying_logic.PersonOnSubject;

namespace App.BLL.Mappers.Studying_logic;

public class PersonOnSubjectMapper : BaseMapper<AppUserOnSubject, BLLPersonOnSubject>
{
    public PersonOnSubjectMapper(IMapper mapper) : base(mapper)
    {
    }
}