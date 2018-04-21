using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantModels.Interfaces
{
    interface IReview
    {
        string ResturuantName { get; set; }
        double ReviewNumber { get; set; }
        string ReviewerName { get; set; }
        string ReviewComment { get; set; }
        DateTime DateSubmitted { get; }
        string GetFormattedReview();
    }
}
