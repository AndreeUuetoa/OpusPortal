using App.BLL.Contracts.Services.Identity;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using App.DAL.Contracts.Repositories.Identity;
using Base;
using Base.BLL;
using DomainAppUser = Domain.Identity.AppUser;
using BLLAppUser = BLL.DTO.Identity.AppUser;

namespace App.BLL.Services.Identity;

public class AppUserService : BaseIdentityService<DomainAppUser, BLLAppUser, IAppUserRepository>, IAppUserService
{
    private readonly IAppDAL _dal;
    
    public AppUserService(IAppDAL dal, IMapper<DomainAppUser, BLLAppUser> mapper) : base(dal.AppUserRepository, mapper)
    {
        _dal = dal;
    }
}