using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class PositionDAL
    {
        public Position FromSqlDataReader(SqlDataReader reader)
        {
            Position p = new Position();
            if (reader["id"] is DBNull == false)
            {
                p.Id = Convert.ToInt32(reader["id"]);
            }
            if (reader["rowNum"] is DBNull == false)
            {
                p.RowNum = Convert.ToInt32(reader["rowNum"]);
            }
            if (reader["colNum"] is DBNull == false)
            {
                p.ColNum = Convert.ToInt32(reader["colNum"]);
            }
            if (reader["positionTypeId"] is DBNull == false)
            {
                p.PositionTypeId = Convert.ToByte(reader["positionTypeId"]);
            }
            if (reader["useAble"] is DBNull == false)
            {
                p.UseAble = Convert.ToBoolean(reader["useAble"]);
            }
            if (reader["layoutId"] is DBNull == false)
            {
                p.LayoutId = Convert.ToInt32(reader["layoutId"]);
            }
            if (reader["positionTypeName"] is DBNull == false)
            {
                p.PositionTypeName = Convert.ToString(reader["positionTypeName"]);
            }
            if (reader["layoutStyle"] is DBNull == false)
            {
                p.LayoutStyle = Convert.ToString(reader["layoutStyle"]);
            }
            return p;
        }

        public void DeleteBy(int layoutId)
        {
            SqlParameter parms = new SqlParameter("@id", SqlDbType.Int) { Value = layoutId };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "DELETE FROM position WHERE layoutId = @id"
                , parms
                );
        }

        public List<Position> GetAllFromSqlServer()
        {
            List<Position> positions = new List<Position>();
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                , CommandType.Text
                , "SELECT * FROM vw_position"
                );
            while (reader.Read())
            {
                positions.Add(FromSqlDataReader(reader));
            }
            return positions;
        }
        public int Insert(Position position)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                 new SqlParameter("@row", SqlDbType.Int) { Value = position.RowNum }
                ,new SqlParameter("@col", SqlDbType.Int) { Value = position.ColNum }
                ,new SqlParameter("@spTId", SqlDbType.TinyInt) { Value = position.PositionTypeId }
                ,new SqlParameter("@useAble", SqlDbType.Bit) { Value = position.UseAble  }
                ,new SqlParameter("@layId", SqlDbType.TinyInt) { Value = position.LayoutId }
            };
            object id = SqlHelper.ExecuteScalar(
                SqlHelper.ConnString
                , CommandType.Text
                , "INSERT position VALUES (@row,@col,@spTId,@useAble,@layId);SELECT SCOPE_IDENTITY()"
                , parms
                );
            return Convert.ToInt32(id);
        }
        public void Insert(List<Position> positions)
        {
            foreach (Position pos in positions)
            {
                pos.Id = Insert(pos);
            }
        }
        public void Delete(int id)
        {
            SqlParameter parms = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                ,CommandType.Text
                ,"DELETE FROM position WHERE id = @id"
                ,parms
                );
        }
        public void Update(int id, byte typeId)
        {
            SqlParameter spId = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            SqlParameter spTypeId = new SqlParameter("@typeId", SqlDbType.TinyInt) { Value = typeId };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "UPDATE Position SET positionTypeId = @typeId WHERE id = @id"
                , spId
                , spTypeId
                );
        }
        public void Update(int id, bool useAble)
        {
            SqlParameter spId = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            SqlParameter spUseAble = new SqlParameter("@userAble", SqlDbType.Bit) { Value = useAble };
            SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnString
                , CommandType.Text
                , "UPDATE Position SET useAble = @typeId WHERE id = @id"
                , spId
                , spUseAble
                );
        }
        public List<Position> Search(byte typeId)
        {
            SqlParameter sp = new SqlParameter("@typeId", SqlDbType.TinyInt) { Value = typeId };
            List<Position> positions = new List<Position>();
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                , CommandType.Text
                , "SELECT * FROM vw_position WHERE positionTypeId = @typeId"
                ,sp
                );
            while (reader.Read())
            {
                positions.Add(FromSqlDataReader(reader));
            }
            return positions;
        }
        public List<Position> Search(int layoutId)
        {
            SqlParameter sp = new SqlParameter("@layoutId", SqlDbType.TinyInt) { Value = layoutId };
            List<Position> positions = new List<Position>();
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnString
                , CommandType.Text
                , "SELECT * FROM vw_position WHERE layoutId = @layoutId"
                , sp
                );
            while (reader.Read())
            {
                positions.Add(FromSqlDataReader(reader));
            }
            return positions;
        }
    }
}
