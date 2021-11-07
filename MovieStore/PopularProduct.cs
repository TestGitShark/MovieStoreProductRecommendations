using System;
using System.Collections.Generic;
using System.Linq;
namespace MovieStore
{
    public class PopularProduct
    {
     
        private static int noOfPopularProducts = 4;
        private static float goodRating = 4f;
        // if you take more records compared to noOfPopularProducts then you will get popular products with mostly sold items
        // if less then mostly based on rating
        private static int noOfRecords = 4; 
        public static List<IProduct> GetMostPopularMovies(List<IProduct> movieList)
        {

            List<IProduct> highlySoldMovies = MostPurchasedMovie.GetMostPurchasedMovies(movieList, noOfRecords);

            MessageService.PrintMessage($"PRINTING MOVIES WITH GOOD RATING & HIGH PURCHASE COUNT FOR EASY ANALYSIS");
            MessageService.PrintMessage("***************************************************************************");
            MessageService.PrintMessage($"Highly sold Movies");
            MessageService.PrintProductDetails(highlySoldMovies);

            List <IProduct> highlyRatedMovies = MostRatedMovies.GetMostRatedMovies(movieList, goodRating);
             MessageService.PrintMessage($"Movies with rating {goodRating} or more: ");
             MessageService.PrintProductDetails(highlyRatedMovies);
            MessageService.PrintMessage("*****************************************************************************");
            List<IProduct> highlyPopularMovies = new List<IProduct>();


            if (highlySoldMovies.Count != 0)
            {
                //popular movie= high selling rate & good rating
                highlyPopularMovies = MostRatedMovies.GetMostRatedMovies(highlySoldMovies, goodRating);
                highlyPopularMovies = highlyPopularMovies.OrderByDescending(x => x.PurchaseCount).ThenByDescending(y => y.Rating).ToList();
                //If number of popular movies is less than required number ,
                //add movies with high rating (that are already not there) to the list

                if (highlyPopularMovies.Count < noOfPopularProducts)
                {
                    for (int i = 0; i < highlyRatedMovies.Count; i++)
                    {
                        if (!highlyPopularMovies.Contains(highlyRatedMovies[i]))
                        {
                            highlyPopularMovies.Add(highlyRatedMovies[i]);
                            if (highlyPopularMovies.Count == noOfPopularProducts)
                                break;
                        }
                    }
                    //check if the count is still less than required no
                    // then add from highly sold list

                }
                else if (highlyPopularMovies.Count > noOfPopularProducts)
                {
                    //select the first n products
                    highlyPopularMovies = highlyPopularMovies.GetRange(0, noOfPopularProducts);
                }




            }
            else
            {
                //No Sold movies
                if (highlyRatedMovies.Count > 0)
                {
                    //popular movies = highly rated movies
                    if (highlyRatedMovies.Count > noOfPopularProducts)
                    {
                        //first n highly rated products
                        highlyPopularMovies = highlyRatedMovies.GetRange(0, noOfPopularProducts);
                    }
                    else
                    {
                        //existing highly rated products
                        highlyPopularMovies = highlyRatedMovies;
                    }

                }
                else
                {
                    Console.WriteLine($"No popular movie as no movies with rating  {goodRating}  or more & no sold movies");
                }

            }

            MessageService.PrintMessage("POPULAR MOVIES");
            MessageService.PrintMessage("*****************************************************************************");
            MessageService.PrintProductDetails(highlyPopularMovies);
            return highlyPopularMovies;

          

              }





        }
    }






// {}   []


 