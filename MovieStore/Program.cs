using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieStore
{
    
    class Program
    {
        private static  string productFilePath = @"/Users/Reenu/Projects/MovieStore/MovieStore/Data/Products.txt";
        private static string userFilePath = @"/Users/Reenu/Projects/MovieStore/MovieStore/Data/Users.txt";
        private static string userSessionPath = @"/Users/Reenu/Projects/MovieStore/MovieStore/Data/CurrentUserSession.txt";

        static void Main(string[] args)
        {


            try
            {
                 //Read Products.txt and create a movieList
                List<IProduct> movieList = new List<IProduct>();
                movieList = CreateProductList.GetProductList(FileReader.GetLinesFromFile(productFilePath));


                //Read users.txt and create a userList
                List<User> users = new List<User>();
                users = CreateUserList.GetUserList(FileReader.GetLinesFromFile(userFilePath));


                //movie sale count
                foreach (Product product in movieList)
                {
                    product.GetPurchaseCount(users);
                }

                List<IProduct> highlyPopularMovies = PopularProduct.GetMostPopularMovies(movieList);



                //Read CurrentUserSession.txt and create a user session list
                List<CurrentUserSession> currentUsers = CreateUserSessionList.GetUserSessionList(FileReader.GetLinesFromFile(userSessionPath));


                MessageService.PrintMessage("RECOMMENDATIONS FOR INDIVIDUAL USERS");
                MessageService.PrintMessage("**************************************************");
                foreach (CurrentUserSession currentUser in currentUsers)
                {
                    // recommended movies with matching keywords
                    List<int> moviesAlreadyBought = users.Find(x => x.Id == currentUser.UserId).moviesPurchased;

                    List<IProduct> recommendedMovies = currentUser.GetRecommendedMovies(movieList, moviesAlreadyBought);
                    List<OftenBoughtTogether> productsBoughtTogether = BoughtTogetherProcessor.GetBoughtTogetherProductList(currentUser.ViewingMovieId,users );
                    if(productsBoughtTogether.Count >0)
                    {
                        MessageService.PrintMessage("PEOPLE WHO BOUGHT THIS ALSO BOUGHT....");
                        foreach(OftenBoughtTogether oftenBought in productsBoughtTogether)
                        {
                            MessageService.PrintSingleMovieDetails(movieList.Find(x => x.Id == oftenBought.BoughtTogetherProduct));
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                MessageService.PrintMessage(ex.Message);
                MessageService.PrintMessage(ex.StackTrace);
            }
            

        }



    }

}
// {}   []

