using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore
{
    public class CreateUserList
    {
        public static List<User> GetUserList(List<string> linesFromUserFile)
        {
            List<User> users = new List<User>();
            foreach (string line in linesFromUserFile)
            {
                String[] items = line.Split(',');
                int userId;
                if (int.TryParse(items[0], out userId))
                {
                    List<string> viewedMovies = new List<string>();
                    List<int> viewedMovieIds = new List<int>();
                    viewedMovies = items[2].Split(';').ToList();
                    foreach (string m in viewedMovies)
                    {
                        viewedMovieIds.Add(int.Parse(m));
                    }

                    List<string> purchasedMovies = new List<string>();
                    List<int> purchasedMovieIds = new List<int>();
                    purchasedMovies = items[3].Split(';').ToList();

                    foreach (string m in purchasedMovies)
                    {
                        purchasedMovieIds.Add(int.Parse(m));
                    }

                    User u = new User() { Id=userId, Name= items[1] , moviesViewed=viewedMovieIds, moviesPurchased=purchasedMovieIds};
                    users.Add(u);
                }

            }
            return users;
        }
    }
}
//{}    []