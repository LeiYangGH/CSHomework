using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OriginPriceDAL
    {
        public OriginPrice FromSqlDataReader(SqlDataReader reader)
        {
            OriginPrice obj = new OriginPrice();
            if (reader["priceTempletId"] is DBNull == false)
            {
                obj.PriceTempletId = Convert.ToInt32(reader["priceTempletId"]);
            }
            if (reader["positionTypeId"] is DBNull == false)
            {
                obj.PositionTypeId = Convert.ToByte(reader["positionTypeId"]);
            }
            if (reader["playId"] is DBNull == false)
            {
                obj.PlayId = Convert.ToString(reader["playId"]);
            }
            if (reader["priceTempletName"] is DBNull == false)
            {
                obj.PriceTempletName = Convert.ToString(reader["priceTempletName"]);
            }
            if (reader["priceTempletValue"] is DBNull == false)
            {
                obj.PriceTempletValue = Convert.ToDecimal(reader["priceTempletValue"]);
            }
            if (reader["positionTypeName"] is DBNull == false)
            {
                obj.PositionTypeName = Convert.ToString(reader["positionTypeName"]);
            }
            return obj;
        }

        public List<OriginPrice> GetAllFromSqlSever()
        {
            throw new NotFiniteNumberException();
        }
        /// <summary>
        /// 按座位类型获取原价列表
        /// </summary>
        /// <param name="positionTypeId"></param>
        /// <returns></returns>
        public List<OriginPrice> Search(byte positionTypeId)
        {
            throw new NotFiniteNumberException();
        }
        /// <summary>
        /// 获取某一场次的原价
        /// </summary>
        /// <param name="playId"></param>
        /// <returns></returns>
        public List<OriginPrice> Search(string playId)
        {
            throw new NotFiniteNumberException();
        }
        /// <summary>
        /// 按场次与座位获取某一场次原价信息
        /// </summary>
        /// <param name="playId"></param>
        /// <param name="positionTypeId"></param>
        /// <returns></returns>
        public OriginPrice Search(string playId, byte positionTypeId)
        {
            throw new NotFiniteNumberException();
        }
        public void Insert(OriginPrice originPrice)
        {
            throw new NotFiniteNumberException();
        }
        /// <summary>
        /// 删除某一个场次某一个位置类型的原价
        /// </summary>
        /// <param name="playId"></param>
        /// <param name="positionTypeId"></param>
        public void Delete(string playId, byte positionTypeId)
        {
            throw new NotFiniteNumberException();
        }
        public void Update(OriginPrice originPrice)
        {
            throw new NotImplementedException();
        }
    }
}
