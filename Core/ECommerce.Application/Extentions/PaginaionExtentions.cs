namespace ECommerce.Application.Extentions;

public static class PaginaionExtentions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int pageSize=10)
    {
        return query.Skip(page * pageSize).Take(pageSize);
    }

    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> query, int page, int pageSize=10)
    {
        return query.Skip(page * pageSize).Take(pageSize);
    }
}
