using System;
using System.Collections.Generic;
using System.Linq;
namespace MovieStore
{
    public class CreateProductList
    {
        public static List<IProduct>GetProductList(List<string> linesFromProductsFile)
        {
            List<IProduct> movieList = new List<IProduct>();
            foreach (string line in linesFromProductsFile)
            {
                int movieId = 0, year = 0;
                float rating = 0, price = 0;

                List<string> keyWords = new List<string>();

                String[] items = line.Split(',');
                if (int.TryParse(items[0], out movieId))
                {
                    //Valid movie Id
                    int.TryParse(items[2], out year);
                    float.TryParse(items[8], out rating);
                    float.TryParse(items[9], out price);
                    if(!string.IsNullOrEmpty(items[3].Trim()))
                        keyWords.Add(items[3].Trim());
                    if (!string.IsNullOrEmpty(items[4].Trim()))
                        keyWords.Add(items[4].Trim());
                    if (!string.IsNullOrEmpty(items[5].Trim()))
                        keyWords.Add(items[5].Trim());
                    if (!string.IsNullOrEmpty(items[6].Trim()))
                        keyWords.Add(items[6].Trim());
                    if (!string.IsNullOrEmpty(items[7].Trim()))
                        keyWords.Add(items[7].Trim());
                    movieList.Add(new Product
                    {
                        Id = movieId,
                        Name = items[1],
                        Year = year,
                        Keywords=keyWords ,
                        Rating = rating,
                        Price = price,
                        PurchaseCount = 0
                    }); 
                }
            }

            return movieList;
        }

    }
}
