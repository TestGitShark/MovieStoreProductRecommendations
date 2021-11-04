using System;
using System.Collections.Generic;

namespace MovieStore
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int>moviesViewed { get; set; }
        public List<int>moviesPurchased { get; set; }
       
    }
}
