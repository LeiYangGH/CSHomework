using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;

namespace DAL
{
    public class MovieDAL
    {
        public Movie FromSqlDataReader(SqlDataReader reader)
        {
            Movie obj = new Movie();
            if (reader["id"] is DBNull == false)
            {
                obj.Id = Convert.ToString(reader["id"]);
            }
            if (reader["name"] is DBNull == false)
            {
                obj.Name = Convert.ToString(reader["name"]);
            }
            if (reader["movieTypeId"] is DBNull == false)
            {
                obj.MovieTypeId = Convert.ToByte(reader["movieTypeId"]);
            }
            if (reader["duration"] is DBNull == false)
            {
                obj.Duration = Convert.ToByte(reader["duration"]);
            }
            if (reader[4] is DBNull == false)
            {
                SqlBytes bytes = reader.GetSqlBytes(4);
                obj.Poster = Image.FromStream(bytes.Stream);
            }
            if (reader["movieTypeName"] is DBNull == false)
            {
                obj.MovieTypeName = Convert.ToString(reader["movieTypeName"]);
            }
            return obj;
        }

        public List<Movie> GetAllFromSqlSever()
        {
            throw new NotImplementedException();
        }
        public string Insert(Movie movie)
        {
            throw new NotImplementedException();
        }
        public void Delete(string movieId)
        {
            throw new NotImplementedException();
        }
        public List<Movie> Search(byte movieTypeId)
        {
            throw new NotImplementedException();
        }
        public List<Movie> Search(string unclearName)
        {
            throw new NotImplementedException();
        }
        public Movie GetMovie(string movieId)
        {
            throw new NotImplementedException();
        }
        public void Update(string movieId, byte[] img)
        {
            throw new NotImplementedException();
        }
    }
}
