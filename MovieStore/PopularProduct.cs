using System;
using System.Collections.Generic;
using System.Linq;
namespace MovieStore
{
    public class PopularProduct
    {
        private static float goodRating = 3.5f;
        private static int noOfPopularProducts = 3;
        public static List<IProduct> GetMostPopularMovies(List<IProduct> movieList)
        {
            List<IProduct> highlySoldMovies = MostPurchasedMovie.GetMostPurchasedMovies(movieList);
            List<IProduct> highlyRatedMovies = MostRatedMovies.GetMostRatedMovies(movieList,goodRating );
            List<IProduct> highlyPopularMovies = new List<IProduct>();


            if(highlySoldMovies.Count!=0 && highlyRatedMovies.Count!=0)
            {
                //There are movies with high rating & high purchse count
                foreach (IProduct movie in highlySoldMovies)
                {
                    if (highlyRatedMovies.Contains(movie))
                    {
                        highlyPopularMovies.Add(movie);
                    }
                }
                if (highlyPopularMovies.Count == 0)
                {
                    // Movies with high rating are not among the most sold ones
                    //Popular movies = movies with max rating in the highly sold category
                    highlyPopularMovies=SoldMoviesWithMaxRating.GetMoviesWithMaxRating(highlySoldMovies);

                }     
            }

            else if(highlySoldMovies.Count == 0 && highlyRatedMovies.Count == 0)

            {
                Console.WriteLine($"No popular movies as  there are no sold movies with good rating. ");
            }
            else if (highlySoldMovies.Count == 0 && highlyRatedMovies.Count != 0)

            {
                highlyPopularMovies = ProductWithMaxRating.GetMoviesWithMaxRating(highlyRatedMovies);
            }
            else if (highlySoldMovies.Count != 0 && highlyRatedMovies.Count == 0)

            {
                //Popular movies based on sales count
                highlyPopularMovies = highlySoldMovies;
            }

            Console.WriteLine($"Popular movies");
            foreach (IProduct product in highlyPopularMovies)
            {
                Console.WriteLine($"Id-{product.Id} Movie Name-{product.Name} Sales Count-{product.PurchaseCount} Rating-{product.Rating}");
            }
            return highlyPopularMovies;
        }
    }
}
