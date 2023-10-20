using App.DAL.Contracts.Repositories;
using App.DAL.Contracts.Repositories.Library;
using Base;
using Domain.Library;

namespace DAL.Repositories.Library;

public class BookRepository : EFBaseRepository<Book, AppDbContext>, IBookRepository
{
    public BookRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}