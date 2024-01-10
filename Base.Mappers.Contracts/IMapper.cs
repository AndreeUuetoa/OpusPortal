namespace Base;

public interface IMapper<TSource, TDestination>
{
    TSource? Map(TDestination? book);
    TDestination? Map(TSource? book);
}