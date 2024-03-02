using Base.BLL.Contracts;
using Base.DAL.Contracts;

namespace Base.BLL;

public abstract class BaseBLL<TUOW> : IBaseBLL
    where TUOW: IBaseDAL
{
    protected readonly TUOW Dal;

    protected BaseBLL(TUOW dal)
    {
        Dal = dal;
    }

    public virtual async Task<int> SaveChanges()
    {
        return await Dal.SaveChanges();
    }
}