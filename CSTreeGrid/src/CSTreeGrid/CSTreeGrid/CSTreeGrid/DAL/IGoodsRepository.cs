using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTreeGrid.DAL
{
    /// <summary>
    /// 接口，作用是兼容不同的数据贴提供程序，比如xml、文本文件、sqlserver等
    /// 实现了此接口就可以做数据存储
    /// </summary>
    public interface IGoodsRepository
    {
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        bool AddGoods(Goods goods);

        /// <summary>
        /// 根据id删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteGoods(int id);

        /// <summary>
        /// 根据id，修改商品（除id的属性修改为与newGoods相同）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newGoods"></param>
        /// <returns></returns>
        bool EditGoods(int id, Goods newGoods);

        /// <summary>
        /// 查看商品
        /// </summary>
        /// <param name="isSpecial">是否特价
        /// 如果为null，返回全部
        /// 如果true或false，分别返回特价和正价
        /// </param>
        /// <returns></returns>
        IList<Goods> ViewGoods(bool? isSpecial);
    }
}
