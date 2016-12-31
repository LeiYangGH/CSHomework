using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class LayoutBLL
    {
        private LayoutDAL dal = new LayoutDAL();
        public List<Layout> GetAllLayout()
        {
            return dal.GetAllFromSqlServer();
        }
        public int AddLayout(Layout layout)
        {
            return dal.Insert(layout);
        }
        public void DropLayout(int layoutId)
        {
            dal.Delete(layoutId);
        }
        public void ResetLayout(Layout layout)
        {
            dal.Update(layout);
        }
        public void ChangeLayoutStypeName(int layoutId, string  layoutStyle)
        {
            dal.Update(layoutId,layoutStyle);
        }
        public List<Layout> Search(string unclearName)
        {
            return dal.Search(unclearName);
        }
    }
}
