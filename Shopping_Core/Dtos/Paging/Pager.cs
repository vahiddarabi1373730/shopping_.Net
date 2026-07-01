namespace Shopping_Core.Dtos.Paging;

public class Pager
{
    public static BasePaging BuildBasePaging<T>(IQueryable<T> query,int takeEntity, int activePage)
    {
        var pageCount = (int)Math.Ceiling(query.Count() / (decimal)takeEntity);
        return new BasePaging
        {
            PageId = activePage,
            PageCount = pageCount,
            ActivePage = activePage,
            TakeEntity = takeEntity,
            EndPage = activePage + 3 > pageCount ? pageCount : activePage + 3,
            StartPage = activePage - 3 <= 1 ? 1 : activePage - 3,
            SkipEntity = (activePage - 1) <=0 ? 0 : (activePage - 1)* takeEntity,
        };
    }
}