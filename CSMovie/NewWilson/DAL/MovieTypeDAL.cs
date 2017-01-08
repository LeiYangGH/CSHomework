using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class MovieTypeDAL
    {
        public  MovieType ReaderMovieType(SqlDataReader reader)
        {
            MovieType mt = new MovieType();
            if (reader["id"] is DBNull == false)
            {
                mt. Id = Convert.ToByte(reader["id"]);
            }
            if (reader["name"] is DBNull == false)
            {
                mt.Name = Convert.ToString(reader["name"]);
            }
            return mt;
        }
        public List<MovieType> GetLeixi()
        {
            List<MovieType> mts = new List<MovieType>();
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM movieType ";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MovieType mt = ReaderMovieType(reader);
                    mts.Add(mt);

                }
            }
            return mts;
        }
     
}
}
