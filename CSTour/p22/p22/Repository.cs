using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p22
{
    public static class Repository
    {
        public static data<Tourist> dataTourist = new data<Tourist>("btn1",
          (x) =>
          {
              return new string[] {
                        x.Name,
                        x.Gender,
                        x.Id,
                        x.Tel
          };
          });
        public static data<Route> dataRoute = new data<Route>("Route",
           (x) =>
           {
               return new string[] {
                        x.Descriptions,
                        x.Date.ToString(),
                        x.Price.ToString()
           };
           });
        public static data<Activity> dataActivity = new data<Activity>("Activity",
           (x) =>
           {
               return new string[] {
                        x.TouristName,
                        x.RouteDescriptions
           };
           });
        public static Tourist GetTouristByName(string n)
        {
            return dataTourist.lst.First(x => x.Name == n);
        }

        public static Route GetRouteByDesc(string d)
        {
            return dataRoute.lst.First(x => x.Descriptions == d);
        }

        //public static bool TouristUsed(string name)
        //{
        //    return dataActivity.lst.Any(x => x.TouristName == name);
        //}
        //public static bool RouteUsed(string des)
        //{
        //    return dataActivity.lst.Any(x => x.RouteDescriptions == des);
        //}
    }
}
