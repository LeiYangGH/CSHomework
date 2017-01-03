using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public  class MovieTypeBLL
    {
        MovieTypeDAL dal = new MovieTypeDAL();
        public List<MovieType> GetLeixi()
        {
            return dal.GetLeixi();
        }
    }
}
