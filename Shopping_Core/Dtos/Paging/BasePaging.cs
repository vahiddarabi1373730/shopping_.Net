using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shopping_Core.Dtos.Paging;

public class BasePaging(int pageId=1, int takeEntity=10)
{
    [BindNever]
    public int PageId { get; set; } = pageId;
    [BindNever]
    public int  PageCount { get; set; }

    public int ActivePage { get; set; } = 1;
    
    public int TakeEntity { get; set; } = takeEntity;
    
    [BindNever]
    public int  SkipEntity { get; set; }
    
    [BindNever]
    public int  StartPage { get; set; }
    [BindNever]
    public int  EndPage { get; set; }
   
}