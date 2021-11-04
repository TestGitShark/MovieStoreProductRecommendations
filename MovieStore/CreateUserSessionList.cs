using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore
{
    public class CreateUserSessionList
    {
        public static List<CurrentUserSession> GetUserSessionList(List<string> linesFromUserFile)
        {
            List<CurrentUserSession> userSessionList = new List<CurrentUserSession>();
            foreach (string line in linesFromUserFile)
            {
                String[] items = line.Split(',');
                int userId,movieId;
                if (int.TryParse(items[0], out userId)  && int.TryParse(items[1], out movieId))
                {
                    userSessionList.Add(new CurrentUserSession() { UserId = userId, ViewingMovieId = movieId });
                }

            }

            //foreach(CurrentUserSession userSession in userSessionList)
            //{
            //    Console.WriteLine($"{userSession.UserId}  {userSession.ViewingMovieId}");
            //}
            return userSessionList;
        }
    }
}
