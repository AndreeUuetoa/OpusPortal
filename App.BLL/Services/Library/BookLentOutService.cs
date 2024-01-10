using App.BLL.Contracts.Services.Library;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories.Library;
using Base;
using Base.BLL;
using DomainBookLentOut = Domain.Library.BookLentOut;
using BLLBookLentOut = BLL.DTO.Library.BookLentOut;

namespace App.BLL.Services.Library;

public class BookLentOutService : BaseEntityService<DomainBookLentOut, BLLBookLentOut, IBookLentOutRepository>, IBookLentOutService
{
    private readonly IAppUOW _uow;

    public BookLentOutService(IAppUOW uow, IMapper<DomainBookLentOut, BLLBookLentOut> mapper) : base(uow.BookLentOutRepository, mapper)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<BLLBookLentOut>> AllWithUserId(Guid id)
    {
        return (await _uow.BookLentOutRepository.AllWithUserId(id)).Select(e => Mapper.Map(e));
    }
}