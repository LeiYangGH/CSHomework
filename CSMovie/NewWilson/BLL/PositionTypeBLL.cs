using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class PositionTypeBLL
    {
        private PositionTypeDAL dal = new PositionTypeDAL();
        public List<PositionType> GetALLPositionType()
        {
            return dal.GetALL();
        }
        public byte AddNewPositionType(PositionType pType)
        {
            return dal.Insert(pType);
        }
        public void RemovePositionTypeById(byte id)
        {
            dal.Delete(id);
        }
        public void UpdatePositionTypeName(int id, string name)
        {
            dal.Update(id, name);
        }
        public void ResetPosition(PositionType positionType)
        {
            dal.Update(positionType);
        }
        public List<PositionType> Search(string unclearName)
        {
            return dal.Search(unclearName);
        }
    }
}
