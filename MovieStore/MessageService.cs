using System;
using System.Collections.Generic;
namespace MovieStore
{
    public class MessageService
    {
        public  static void PrintProductDetailsWithKeyWords(List<IProduct>movieList)
        {
            foreach(IProduct movie in movieList )
            {
                Console.WriteLine($"Id-{movie.Id}  Movie Nmae-{movie.Name}  Rating-{movie.Rating} Sold-{movie.PurchaseCount}");
                foreach(string keyWord in movie.Keywords)
                {
                    Console.WriteLine($"{keyWord}");
                }

            }
        }
        public static void PrintProductDetails(List<IProduct> movieList)
        {
            foreach (IProduct movie in movieList)
            {
                Console.WriteLine($"Id-{movie.Id}  Movie Nmae-{movie.Name}  Rating-{movie.Rating} Sold-{movie.PurchaseCount}");
               
            }
        }
        public static void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void PrintSingleMovieDetails(IProduct movie)
        {
            Console.WriteLine($"Movie Id-{movie.Id}  Viewing Movie-{movie.Name}");
            foreach (string kw in movie.Keywords)
            {
                Console.WriteLine($"{kw}");
            }
           
        }

    }
}
