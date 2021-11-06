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
            highlyRatedMovies = highlyRatedMovies.OrderByDescending(x => x.Rating).ToList();
            
          
            

            return highlyRatedMovies;
        }
    }
}
