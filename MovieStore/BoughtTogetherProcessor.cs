using System;
using System.Collections.Generic;
using System.Linq;
namespace MovieStore
{
    public class BoughtTogetherProcessor
    {
        public static List<OftenBoughtTogether> GetBoughtTogetherProductList(int movieId, List<User> users)
        {
            List<OftenBoughtTogether> productsBoughtTogether = new List<OftenBoughtTogether>();

            foreach (User user in users)
            {
                if (user.moviesPurchased.Contains(movieId))
                {
                    List<int> purchaseList = user.moviesPurchased;
                    purchaseList.Remove(movieId);
                    foreach(int product in purchaseList )
                    {
                        OftenBoughtTogether item = new OftenBoughtTogether();
                        item = productsBoughtTogether.Find(x => x.BoughtTogetherProduct == product);
                        if(item ==null)
                        {
                            //new entry to the list
                            
                            productsBoughtTogether.Add(new OftenBoughtTogether { BoughtTogetherProduct= product, NoOfCustomers=1 });
                        }
                        else
                        {
                            ++(productsBoughtTogether.Find(x => x.BoughtTogetherProduct == product).NoOfCustomers);
                        }

                    }
                    //productsBoughtTogether = user.moviesPurchased;
                    //productsBoughtTogether.Remove(movieId);
                }
            }

            productsBoughtTogether= productsBoughtTogether.OrderByDescending(x => x.NoOfCustomers).ToList ();
            
            return productsBoughtTogether;
        }
    }
}
