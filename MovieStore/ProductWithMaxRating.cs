using System;
using System.Collections.Generic;
using System.Linq;


namespace MovieStore
{
    public class ProductWithMaxRating
    {
        public static List<IProduct> GetMoviesWithMaxRating(List<IProduct> movies)
        {
            float maxRating = movies.Max(x => x.Rating);
            List<IProduct> moviesWithMaxRating = new List<IProduct>();
            moviesWithMaxRating = movies.FindAll(x => x.Rating == maxRating);
            return moviesWithMaxRating;
        }
    }
}
