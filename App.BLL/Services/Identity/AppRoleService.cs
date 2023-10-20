using App.BLL.Contracts.Services.Identity;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories.Identity;
using Base;
using Base.BLL;
using DomainAppRole = Domain.Identity.AppRole;
using BLLAppRole = BLL.DTO.Identity.AppRole;

namespace App.BLL.Services.Identity;

public class AppRoleService : BaseIdentityService<DomainAppRole, BLLAppRole, IAppRoleRepository>, IAppRoleService
{
    private readonly IAppUOW _uow;
    
    public AppRoleService(IAppUOW uow, IMapper<DomainAppRole, BLLAppRole> mapper) : base(uow.AppRoleRepository, mapper)
    {
        _uow = uow;
    }
}