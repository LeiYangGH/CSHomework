using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTreeGrid.DAL
{
    /// <summary>
    /// MSSql数据提供程序，实现了IGoodsRepository接口
    /// 类似地，可以写个针对Oracle的提供程序
    /// 打开Program.cs就可以看到如何调用
    /// 注意当前的代码要求数据库与script_allcolumns.sql的表结构完全一致
    /// </summary>
    public class MSSqlGoodsRepository : IGoodsRepository
    {
        /// <summary>
        /// 把数据库对象转换为Goods
        /// </summary>
        /// <param name="newShop"></param>
        /// <returns></returns>
        private Goods ConvertEntityToGoods(NewShop newShop)
        {
            Goods goods = new Goods();
            goods.Id = newShop.ShopID;
            goods.Name = newShop.ShopName;
            goods.Category = newShop.ShopLei;
            goods.Price = newShop.ShopMoney;
            goods.PrePrice = newShop.ShopPreMoney;
            goods.isSpecial = newShop.IsSpecial;
            return goods;
        }

        /// <summary>
        /// 把Goods转换为数据库对象
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        private NewShop ConvertGoodsToEntity(Goods goods)
        {
            NewShop newShop = new NewShop();
            newShop.ShopName = goods.Name;
            newShop.ShopLei = goods.Category;
            newShop.ShopMoney = goods.Price;
            newShop.ShopPreMoney = goods.PrePrice;
            newShop.IsSpecial = goods.isSpecial;
            return newShop;
        }

        public bool AddGoods(Goods goods)
        {
            NewShop newShop = this.ConvertGoodsToEntity(goods);
            try
            {
                using (ShopPingEntities en = new ShopPingEntities())
                {
                    en.NewShops.Add(newShop);
                    en.SaveChanges();
                }
                return true;
            }
            //数据库操作如果失败，
            //可以想办法获取ex.Message并传到外部，
            //这里简单屏蔽掉了
            //下同
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteGoods(int id)
        {
            try
            {
                using (ShopPingEntities en = new ShopPingEntities())
                {
                    NewShop newShop = en.NewShops.First(x => x.ShopID == id);
                    en.NewShops.Remove(newShop);
                    en.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditGoods(int id, Goods newGoods)
        {
            try
            {
                using (ShopPingEntities en = new ShopPingEntities())
                {
                    NewShop newShop = en.NewShops.First(x => x.ShopID == id);
                    newShop.ShopName = newGoods.Name;
                    newShop.ShopLei = newGoods.Category;
                    newShop.ShopMoney = newGoods.Price;
                    newShop.ShopPreMoney = newGoods.PrePrice;
                    newShop.IsSpecial = newGoods.isSpecial;
                    en.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IList<Goods> ViewGoods(bool? isSpecial)
        {
            using (ShopPingEntities en = new ShopPingEntities())
            {
                IList<NewShop> lst;
                if (isSpecial == null)
                    lst = en.NewShops.ToList();
                else
                    lst = en.NewShops.Where(x => x.IsSpecial != isSpecial).ToList();
                return lst.Select(x => this.ConvertEntityToGoods(x)).ToList();
            }
        }
    }
}
