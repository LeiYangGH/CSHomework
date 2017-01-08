using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public  class MovieTypeBLL
    {
        MovieTypeDAL dal = new MovieTypeDAL();
        public List<MovieType> GetAllMovieType()
        {
            return GetLeixi();
        }
        public List<MovieType> GetLeixi()
        {
            return dal.GetLeixi();
        }
       
    }
}
