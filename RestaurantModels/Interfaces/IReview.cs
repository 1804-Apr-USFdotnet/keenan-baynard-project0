using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantModels.Interfaces
{
    interface IReview
    {
        double ReviewRating { get; set; }
        string ReviewerName { get; set; }
        string ReviewComment { get; set; }
        DateTime DateSubmitted { get; }
        string GetFormattedReview();
        int RestaurantID { get; set; }

    }
}
