using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore
{
    public class MostPurchasedMovie
    {
        public static List<IProduct> GetMostPurchasedMovies(List<IProduct> movies)
        {
            int maxSaleCount = movies.Max(x => x.PurchaseCount);
            List<IProduct> highlySoldMovies = new List<IProduct>();
            if (maxSaleCount==0)
            {
                Console.WriteLine($"No products sold yet");
                
            }
            else
            {
                highlySoldMovies = movies.FindAll(x => x.PurchaseCount == maxSaleCount).ToList();

                Console.WriteLine($"Highly sold movies");

                foreach (IProduct product in highlySoldMovies)
                {
                    Console.WriteLine($"Id-{product.Id} Movie Name-{product.Name} Sales count-{product.PurchaseCount} Rating-{product.Rating}");
                }
               
            }


            return highlySoldMovies;
        }
    }
}
