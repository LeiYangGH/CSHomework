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
            throw new NotImplementedException();
        }
        public string AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
        public void DropMovie(string movieId)
        {
            throw new NotImplementedException();
        }
        public List<Movie> Search(byte movieTypeId)
        {
            return dal.Search(movieTypeId);
        }
        public List<Movie> Search(string unclearName)
        {
            throw new NotImplementedException();
        }
        public Movie GetMovie(string movieId)
        {
            throw new NotImplementedException();
        }
        public void ChangeMoviePoster(string movieId, byte[] poster)
        {
            throw new NotImplementedException();
        }
    }
}
