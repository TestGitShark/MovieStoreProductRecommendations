using System;
using System.Collections.Generic;
using System.Linq;
namespace MovieStore
{
    public class CurrentUserSession
    {
        public int   UserId { get; set; }
        public int ViewingMovieId { get; set; }
        private static int noOfRecommendations = 3;

        //Recommended Movies= movies with maximum matching keywords
        //&& movies not already bought by the user
        public List<IProduct> GetRecommendedMovies(List<IProduct> movieList,List<int>alreadyBoughtmovies)
        {
            int noOfMatchingKeyWords;
            List<IProduct> moviesWithSimilarKw = new List<IProduct>();
            IProduct viewingProduct = movieList.Find(x => x.Id == ViewingMovieId);
            noOfMatchingKeyWords = viewingProduct.Keywords.Count;

            List<IProduct> copyOfMovieList = movieList.ToList();
            copyOfMovieList.Remove(viewingProduct);
            foreach (int i in alreadyBoughtmovies)
            {
                //remove already bought movies from recommendations
                copyOfMovieList.Remove(copyOfMovieList.Find(x => x.Id == i));
            }
            //Find movies with most matching keywords as recommendation
            do
            {
                for(int i=0;i< copyOfMovieList.Count;i++)
                {
                    //movies with same keywords added to recommendations 
                    List<string> commonKeyWords = new List<string>();
                    commonKeyWords = viewingProduct.Keywords.Intersect(copyOfMovieList[i].Keywords, StringComparer.InvariantCultureIgnoreCase).ToList();
                    if (commonKeyWords.Count == noOfMatchingKeyWords)
                    {
                        moviesWithSimilarKw.Add(copyOfMovieList[i]);   
                    }
                    if (moviesWithSimilarKw.Count == noOfRecommendations)
                        break;
                    
                }
                --noOfMatchingKeyWords;
               } while (moviesWithSimilarKw.Count< noOfRecommendations && noOfMatchingKeyWords >0);

          
            MessageService.PrintMessage($"USER ID-{UserId}  Viewing Movie Id-{ViewingMovieId}  Viewing Movie-{viewingProduct.Name}");
           
            foreach (string kw in viewingProduct.Keywords)
            {
                Console.WriteLine($"{kw}");
            }

            MessageService.PrintMessage("YOU MAY ALSO LIKE...");
            MessageService.PrintProductDetailsWithKeyWords(moviesWithSimilarKw);
           
            return moviesWithSimilarKw;
        }

    }
}
