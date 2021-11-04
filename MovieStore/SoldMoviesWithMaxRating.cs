using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore
{
    public class SoldMoviesWithMaxRating
    {
        public static List<IProduct> GetMoviesWithMaxRating(List<IProduct> highlySoldMovies)
        {

            List<IProduct> soldMoviesWithmaxRating = new List<IProduct>();
            float maxRatingInSoldMovieList = highlySoldMovies.Max(x => x.Rating);
            soldMoviesWithmaxRating = highlySoldMovies.FindAll(x => x.Rating == maxRatingInSoldMovieList);
            return soldMoviesWithmaxRating;

        }

    }
}
