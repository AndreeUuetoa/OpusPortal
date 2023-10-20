using Base.BLL.Contracts;
using Base.DAL.Contracts;

namespace Base.BLL;

public abstract class BaseBLL<TUOW> : IBaseBLL
    where TUOW: IBaseUOW
{
    protected readonly TUOW Uow;

    protected BaseBLL(TUOW uow)
    {
        Uow = uow;
    }

    public virtual async Task<int> SaveChanges()
    {
        return await Uow.SaveChanges();
    }
}