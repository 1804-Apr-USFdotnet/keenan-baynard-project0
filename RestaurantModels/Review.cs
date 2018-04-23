using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantModels.Interfaces;

namespace RestaurantModels
{
    public class Review : IReview
    {
        public string ResturuantName { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewComment { get; set; }
        public double ReviewRating { get; set; }

        public DateTime DateSubmitted => DateTime.Now;

        public string GetFormattedReview()
        {
            string formatted =
                "Restaurant Name: "+ResturuantName + ": \n\t" +
                "Reviewer Name: "+ReviewerName + ": \n\t" +
                "Written Review: ("+ReviewRating+") "+ReviewComment;
            return formatted;
        }
    }
}
