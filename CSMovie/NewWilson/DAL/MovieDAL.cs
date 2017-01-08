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
        public Movie GetMovie(string movieId)
        {
            Movie mv = null;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText =
                    "select * from vw_movie where id = @id";
                SqlParameter par = new SqlParameter("@id", System.Data.SqlDbType.NVarChar, 36);
                par.Value = movieId;
                cmd.Parameters.Add(par);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    mv = FromSqlDataReader(reader);
            }
            return mv;
        }
        public List<Movie> GetAllFromSqlSever()
        {
            List<Movie> mos = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from vw_movie";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Movie mv = FromSqlDataReader(reader);
                    mos.Add(mv);
                }

            }
            return mos;

        }
        public List<Movie> GetAllFromSqlSever(byte movieTypeId)
        {
            List<Movie> mos = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from vw_movie";


                SqlParameter par = new SqlParameter("@movieTypeId", System.Data.SqlDbType.TinyInt);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Movie mv = FromSqlDataReader(reader);
                    mos.Add(mv);
                }

            }
            return mos;

        }

        public List<Movie> GetMovie()
        {
            List<Movie> mov = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM vw_movie";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Movie m = FromSqlDataReader(reader);
                        mov.Add(m);
                    }
                }
                return mov;
            }
        }

        public void Insert(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @" INSERT INTO movie
                                    ([id],[name],[movieTypeId],[duration])  
                                    VALUES(@id,@name,@movieTypeId,@duration);SELECT @@IDENTITY";
                SqlParameter[] pars = new SqlParameter[]
                {
                    new SqlParameter("@id",System.Data.SqlDbType.NVarChar,36),
                     new SqlParameter("@name",System.Data.SqlDbType.NVarChar,50),
                       new SqlParameter("@movieTypeId",System.Data.SqlDbType.TinyInt),
                       new SqlParameter("@duration",System.Data.SqlDbType.TinyInt)
                };

                pars[0].Value = Guid.NewGuid().ToString();
                pars[1].Value = movie.Name;
                pars[2].Value = movie.MovieTypeId;
                pars[3].Value = movie.Duration;

                cmd.Parameters.AddRange(pars);


                cmd.ExecuteNonQuery();

            }
        }


        public void Delete(string movieId)
        {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from movie where id=@idd";
                SqlParameter par = new SqlParameter("@idd", System.Data.SqlDbType.NVarChar, 36);
                par.Value = movieId;
                cmd.Parameters.Add(par);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public List<Movie> Search(byte movieTypeId)
        {
            List<Movie> mos = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from vw_movie where movieTypeId=@movieTypeId ";


                SqlParameter par = new SqlParameter("@movieTypeId", System.Data.SqlDbType.TinyInt);
                par.Value = movieTypeId;
                cmd.Parameters.Add(par);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Movie mv = FromSqlDataReader(reader);
                    mos.Add(mv);
                }

            }
            return mos;
        }
        public List<Movie> Search(string unclearName)
        {
            List<Movie> mos = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //cmd.CommandText = 
                //"select * from vw_movie where name like '@name%' ";

                cmd.CommandText =
                    "select * from vw_movie where name like @name ";
                SqlParameter par = new SqlParameter("@name", System.Data.SqlDbType.NVarChar, 50);
                par.Value = string.Format("{0}%", unclearName);
                cmd.Parameters.Add(par);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Movie mv = FromSqlDataReader(reader);
                    mos.Add(mv);
                }
            }
            return mos;
        }
        public void Update(string movieId, byte[] img)
        {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update movie set poster=@photo where id=@id";
                SqlParameter[] par = new SqlParameter[]
                {
                  new SqlParameter("@photo",System.Data.SqlDbType.VarBinary),
                  new SqlParameter ( "@id", System.Data.SqlDbType.NVarChar,36)

                };

                par[0].Value = img;
                par[1].Value = movieId;
                cmd.Parameters.AddRange(par);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void Update(Movie mv)
        {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update movie set name=@name,movieTypeId=@movieTypeId,duration=@duration where id=@id";
                SqlParameter[] pars = new SqlParameter[]
                {

                        new SqlParameter("@name",System.Data.SqlDbType.NVarChar,50),
                       new SqlParameter("@movieTypeId",System.Data.SqlDbType.TinyInt),
                       new SqlParameter("@duration",System.Data.SqlDbType.TinyInt),
                       new SqlParameter("@id",System.Data.SqlDbType.NVarChar,36)
                };


                pars[0].Value = mv.Name;
                pars[1].Value = mv.MovieTypeId;
                pars[2].Value = mv.Duration;
                pars[3].Value = mv.Id;

                cmd.Parameters.AddRange(pars);

                cmd.ExecuteNonQuery();
              
            }
        }
    }
}
