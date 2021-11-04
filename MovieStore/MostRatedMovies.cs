using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore
{
    public class MostRatedMovies
    {
        public static List<IProduct> GetMostRatedMovies(List<IProduct> movies, float highRating)
        {
            
            List<IProduct> highlyRatedMovies = movies.FindAll(x => x.Rating >=highRating).ToList();
            if(highlyRatedMovies.Count==0)
            {
                Console.WriteLine($"There are no products with rating {highRating} or more: ");
            }
            else
            {
                Console.WriteLine($"Movies with rating {highRating} or more: ");
                foreach (IProduct product in highlyRatedMovies)
                {
                    Console.WriteLine($"Id-{product.Id}  Movie Nmae-{product.Name}  Rating-{product.Rating} ");
                }
            }
            

            return highlyRatedMovies;
        }
    }
}
