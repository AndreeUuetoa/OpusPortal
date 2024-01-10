using AutoMapper;
using BLL.DTO.Competitions;
using BLL.DTO.Concerts;
using BLL.DTO.Identity;
using BLL.DTO.Library;
using BLL.DTO.Rooms;

namespace App.BLL.Mappers;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Domain.Identity.AppRole, AppRole>().ReverseMap();
        CreateMap<Domain.Identity.AppUser, AppUser>().ReverseMap();
        CreateMap<Domain.Library.Book, Book>().ReverseMap();
        CreateMap<Domain.Competitions.Competition, Competition>().ReverseMap();
        CreateMap<Domain.Concerts.Concert, Concert>().ReverseMap();
        CreateMap<Domain.Library.BookLentOut, BookLentOut>().ReverseMap();
        CreateMap<Domain.Rooms.Room, Room>().ReverseMap();
    }
}