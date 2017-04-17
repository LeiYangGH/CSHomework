using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
namespace CSWarehouse
{
    public static class DAL
    {
        public static bool AddInOut(InOut inOut)
        {
            try
            {
                using (WareHouseEntities en = new WareHouseEntities())
                {
                    en.InOuts.Add(inOut);
                    en.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public static List<Material> GetAllMaterials()
        {
            try
            {
                using (WareHouseEntities en = new WareHouseEntities())
                {
                    return en.Materials.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Material>();
            }

        }

        public static InOut GetInOutByVIn(VIn vIn)
        {
            try
            {
                using (WareHouseEntities en = new WareHouseEntities())
                {
                    return en.InOuts.Include(p => p.Material).First(x =>
                    x.IsIn
                    && x.Material.Name == vIn.Name
                    && x.Quantity == vIn.Quantity
                    && x.Date == vIn.Date);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public static bool EditInOut(int oldInOutID, InOut newInOut)
        {
            try
            {
                using (WareHouseEntities en = new WareHouseEntities())
                {
                    InOut inOut = en.InOuts.First(x => x.ID == oldInOutID);
                    inOut.MID = newInOut.MID;
                    inOut.Quantity = newInOut.Quantity;
                    inOut.Date = newInOut.Date;
                    en.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public static bool DeleteInOut( InOut  InOut)
        {
            try
            {
                using (WareHouseEntities en = new WareHouseEntities())
                {
                    InOut inOut = en.InOuts.First(x => x.ID == InOut.ID);
                    en.InOuts.Remove(inOut);
                    en.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
    }
}
