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
    private readonly IAppDAL _dal;
    
    public AppRoleService(IAppDAL dal, IMapper<DomainAppRole, BLLAppRole> mapper) : base(dal.AppRoleRepository, mapper)
    {
        _dal = dal;
    }
}