using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore
{
    public class Product : IProduct
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<string> Keywords { get; set; }
        public float Rating { get; set; }
        public float Price { get; set; }
        public int PurchaseCount { get; set; }

        public void GetPurchaseCount(List<User> users)
        {
            foreach(User user in users)
            {
                if (user.moviesPurchased.Contains(Id))
                    ++PurchaseCount;
            }
        }
    }

}
