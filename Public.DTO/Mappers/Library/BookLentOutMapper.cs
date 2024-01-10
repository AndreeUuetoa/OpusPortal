using AutoMapper;
using Base.Mappers;
using BLLBookLentOut = BLL.DTO.Library.BookLentOut;
using PublicBookLentOut = Public.DTO.v1._0.Library.BookLentOut;

namespace Public.DTO.Mappers.Library;

public class BookLentOutMapper : BaseMapper<BLLBookLentOut, PublicBookLentOut>
{
    private readonly BookMapper _bookMapper;
    
    public BookLentOutMapper(IMapper mapper) : base(mapper)
    {
        _bookMapper = new BookMapper(mapper);
    }

    public override BLLBookLentOut? Map(PublicBookLentOut? publicBookLentOut)
    {
        if (publicBookLentOut == null)
        {
            return null;
        }
        
        return new BLLBookLentOut
        {
            BookId = publicBookLentOut.BookId,
            Book = _bookMapper.Map(publicBookLentOut.Book),
            AppUserId = publicBookLentOut.AppUserId,
            LentAt = DateTime.UtcNow,
            ReturnAt = DateTime.UtcNow.AddDays(publicBookLentOut.Days)
        };
    }

    public override PublicBookLentOut? Map(BLLBookLentOut? bllBookLentOut)
    {
        if (bllBookLentOut == null)
        {
            return null;
        }

        return new PublicBookLentOut
        {
            BookId = bllBookLentOut.BookId,
            AppUserId = bllBookLentOut.AppUserId,
            Days = bllBookLentOut.ReturnAt.Subtract(bllBookLentOut.LentAt).Days
        };
    }
}