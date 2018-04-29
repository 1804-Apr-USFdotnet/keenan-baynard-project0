using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantModels.Interfaces;

namespace RestaurantModels
{
    public class Review : IReview
    {
        public string ReviewerName { get; set; }
        public string ReviewComment { get; set; }
        public double ReviewRating { get; set; }
        public int RestaurantID { get; set; }


        public DateTime DateSubmitted => DateTime.Now;

        public string GetFormattedReview()
        {
            string formatted =
                "Reviewer Name: "+ReviewerName + ": \n\t" +
                "Written Review: ("+ReviewRating+") "+ReviewComment;
            return formatted;
        }
    }
}
