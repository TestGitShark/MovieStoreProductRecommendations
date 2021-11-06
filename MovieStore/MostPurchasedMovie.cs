using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore
{
    public class MostPurchasedMovie
    {
        public static List<IProduct> GetMostPurchasedMovies(List<IProduct> movies,int maxnoOfrecords)
        {


            List<IProduct> highlySoldMovies = movies.FindAll(x => x.PurchaseCount != 0);
            highlySoldMovies=highlySoldMovies.OrderByDescending(x => x.PurchaseCount).ThenByDescending(y => y.Rating).ToList();

            if (maxnoOfrecords < highlySoldMovies.Count)
            {
                highlySoldMovies = highlySoldMovies.GetRange(0, maxnoOfrecords);
            }
          
            return highlySoldMovies;
        }
    }
}
