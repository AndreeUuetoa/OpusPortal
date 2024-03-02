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
    private readonly IAppDAL _dal;

    public BookLentOutService(IAppDAL dal, IMapper<DomainBookLentOut, BLLBookLentOut> mapper) : base(dal.BookLentOutRepository, mapper)
    {
        _dal = dal;
    }

    public async Task<IEnumerable<BLLBookLentOut>> AllWithUserId(Guid id)
    {
        return (await _dal.BookLentOutRepository.AllWithUserId(id)).Select(e => Mapper.Map(e));
    }
}