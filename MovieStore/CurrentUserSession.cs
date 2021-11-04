using System;
using System.Collections.Generic;
using System.Linq;
namespace MovieStore
{
    public class CurrentUserSession
    {
        public int   UserId { get; set; }
        public int ViewingMovieId { get; set; }
        private static int noOfMatchingKeyWords = 3;
        public List<IProduct> GetRecommendedMovies(List<IProduct> movieList)
        {
            List<IProduct> moviesWithSimilarKw = new List<IProduct>();

            IProduct viewingProduct = movieList.Find(x => x.Id == ViewingMovieId);
            movieList.Remove(viewingProduct);
            foreach (IProduct movie in movieList)
            {
                //movies with 3 or more same keywords added to recommendations 
                List<string> commonKeyWords = new List<string>();
                commonKeyWords = viewingProduct.Keywords.Intersect(movie.Keywords, StringComparer.InvariantCultureIgnoreCase).ToList();
                commonKeyWords.RemoveAll(x => string.IsNullOrEmpty(x));
                if (commonKeyWords.Count >= noOfMatchingKeyWords)
                {
                    moviesWithSimilarKw.Add(movie);

                }
            }

            Console.WriteLine($"UserId-{UserId}  Viewing Movie Id-{ViewingMovieId}");
            foreach (string kw in viewingProduct.Keywords)
            {
                Console.WriteLine($"{kw}");
            }

            Console.WriteLine($"Recommended Movies");
            foreach (IProduct movie in moviesWithSimilarKw)
            {
                Console.WriteLine($"MovieId-{movie.Id} MovieName-{movie.Name} ");
                foreach(string kw in movie.Keywords)
                {
                    Console.WriteLine($"{kw}");
                }
            }

            return moviesWithSimilarKw;
        }

    }
}
