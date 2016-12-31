using Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class OriginPriceBLL
    {
        public List<OriginPrice> GetAllOriginPrice()
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
        public void AddOriginPrice(OriginPrice originPrice)
        {
            throw new NotFiniteNumberException();
        }
        /// <summary>
        /// 删除某一个场次某一个位置类型的原价
        /// </summary>
        /// <param name="playId"></param>
        /// <param name="positionTypeId"></param>
        public void DropOriginPrice(string playId, byte positionTypeId)
        {
            throw new NotFiniteNumberException();
        }
        public void ResetOriginPrice(OriginPrice originPrice)
        {
            throw new NotImplementedException();
        }
    }
}
