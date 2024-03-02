namespace Base.DAL.Contracts;

public interface IBaseDAL
{
    Task<int> SaveChanges();
}