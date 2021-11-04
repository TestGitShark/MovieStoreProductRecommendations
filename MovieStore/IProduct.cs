using System.Collections.Generic;
namespace MovieStore
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        int Year { get; set; }
        List<string> Keywords { get; set; }
        float Rating { get; set; }
        float Price { get; set; }
        int PurchaseCount { get; set; }
    }
}