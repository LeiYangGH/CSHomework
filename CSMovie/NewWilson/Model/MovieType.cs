using System;
using System.Data.SqlClient;
namespace Model
{
    public class MovieType
    {
        public byte Id { get; set; } 
        public string Name { get; set; }
        public MovieType() { }
        public MovieType(SqlDataReader reader)
        {
            if (reader["id"] is DBNull == false)
            {
                Id = Convert.ToByte(reader["id"]);
            }
            if (reader["name"] is DBNull == false)
            {
                Name = Convert.ToString(reader["name"]);
            }
        }
    }
}
