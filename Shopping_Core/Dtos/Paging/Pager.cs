namespace Shopping_Core.Dtos.Paging;

public class Pager
{
    public static BasePaging Build(int pageCount, int takeEntity, int activePage)
    {
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