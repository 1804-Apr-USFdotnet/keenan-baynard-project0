using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantModels.Interfaces
{
    interface IRestaurant
    {
        string City { get; set; }
        string State { get; set; }
        string GetLocation();
    }
}
