using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class HallBLL
    {
        private HallDAL dal = new HallDAL();
        public List<Hall> GetAllHall()
        {
            return dal.GetAllFromSqlServer();
        }
        public short AddHall(Hall hall)
        {
            return dal.Insert(hall);
        }
        public void DropHall(short id)
        {
            dal.Delete(id);
        }
        public void ResetHall(Hall hall)
        {
            dal.Update(hall);
        }
        public void ChangeHallTheme(short id, string theme)
        {
            dal.Update(id, theme);
        }
        public void ChangeHallLayout(short id, int layoutId)
        {
            dal.Update(id, layoutId);
        }
        public List<Hall> Search(string unclearThemeName)
        {
            return dal.Search(unclearThemeName);
        }
        public List<Hall> Search(int layoutId)
        {
            return dal.Search(layoutId);
        }
        public List<Hall> Search(int layoutId, string theme)
        {
            return dal.Search(layoutId, theme);
        }
    }
}
