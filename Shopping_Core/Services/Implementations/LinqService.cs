using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopping_Core.Services.Interfaces;
using Shopping_Data_Layer.Entities.Product;
using Shopping_Data_Layer.Repository;

namespace Shopping_Core.Services.Implementations;

public class LinqService(IGenericRepository<ProductCategory> genericRepository,ILogger<LinqService> logger):ILinqService
{
    public async Task<List<ProductCategory>> GetAll()
    {
        var query =  genericRepository.GetEntitiesQuery();
        // 1
        //First()
         // var r1.1 = query.First();
         // var r1.2 = query.First(x=>x.Id>100);
         
         //2
         //FirstOrDefault
         // var r2.1 = query.FirstOrDefault();
         // var r2.2 = query.FirstOrDefault(x=>x.Id>100);
         
        
         //3
         //Single()
         // var r3 = query.Single(x=>x.Id==1);
         
         
         //4
         //SingleOrDefault
         // var r4 = query.SingleOrDefault(x=>x.Id==1);
         
         //5
         //Last
         var r5 = query.OrderBy(c=>c.Id).Last();
        
         //6
         //LastOrDefault
         var r6 = query.OrderByDescending(c=>c.Id).LastOrDefault();
         
         //7
         //ElementAt
         var r7 = query.ElementAt(1);
         
         //8
         //ElementAtOrDefault
         var r8 = query.ElementAtOrDefault(1);
         
         //9
         //Any
         var r9 = query.Any(x=>x.Id==0);
         var r9_1 = query.Any();
         
         
         
         //10
         //All
         var r10 = query.All(x => x.Id > 0);
         
         
         //11
         //Contains
         var r11 = query.Where(pc=>pc.Title.Contains("ور"));
         
         
         
         //12
         //Count
         var r12 = query.Count();
         
         
         //13
         //LongCount
         var r13 = query.LongCount();
         
         //14
         //Sum
         var r14 = query.Sum(pc=>pc.Id);
         
         //15
         //Average
         var r15 = query.Average(pc => pc.Id);
         
         
         //16
         //Min
         var r16=query.Min(pc => pc.Id);
         
         
         //17
         //Max
         var r17 = query.Max(pc => pc.Id);
         
         //18
         //Aggregate(مانند Reduce در Javascript)
         var r18 = query.ToList().Aggregate(0L,(prev,current)=>prev+current.Id);
         
         //19
         //ToList
         var r19 = query.ToList();
         
         //20
         //ToArray
         var r20 = query.ToArray();
         
         //21
         //ToDictionary
         var r21 = query.ToDictionary(x=>x.Id,x=>x.Title);
         
         //22
         //Aggregate
         var r22 = query.ToHashSet();
         
         //23
         //Aggregate
         var r23 = query.ToLookup(x=>x.Id,x=>x.Title);
         //24
         //Aggregate
         var r24 = query.AsEnumerable();
         //25
         //Aggregate
         var r25 = query.AsQueryable();
         
         

        var categories=await query.ToListAsync();
        return categories;
    }
}