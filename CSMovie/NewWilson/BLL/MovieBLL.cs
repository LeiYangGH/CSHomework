using DAL;
using Model;
using System;
using System.Collections.Generic;

namespace BLL
{

    public class MovieBLL
    {

        private MovieDAL dal = new MovieDAL();

        public List<Movie> GetAllMovie()
        {
            return dal.GetAllFromSqlSever();
        }
        public void Insert(Movie movie)
        {

            dal.Insert(movie);
        }
        public void Delete(string movieId)
        {
            dal.Delete(movieId);
        }
        public List<Movie> Search(byte movieTypeId)
        {
            return dal.Search(movieTypeId);
        }
        public List<Movie> Search(string unclearName)
        {
            return dal.Search(unclearName);
        }
        public void Update(Movie mv)
        {
            dal.Update(mv);
        }
        public void Update(string movieId, byte[] img)
        {
             dal.Update(movieId,img);
        }

        public List<Movie> SearchA(byte movieTypeId)
        {
            return dal.Search(movieTypeId);
        }

        public Movie GetMovie(string movieId)
        {
            return dal.GetMovie(movieId);
        }
    }
}
