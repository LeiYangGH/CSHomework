using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSBike
{
    public static class BikesHistory
    {
        public static List<History> lstHistory = new List<History>();
        const string bikeFileName = "Bikes.dat";
        private static bool CanBorrow(string bike)
        {
            return !lstHistory.Any(x => x.BikeNO == bike)
                || !lstHistory.Where(x => x.BikeNO == bike).OrderBy(x => x.Date)
                .Last().ToBorrow;
        }
        public static bool Borrow(string bike, string user)
        {
            if (CanBorrow(bike))
            {
                lstHistory.Add(new History(bike, user, true, DateTime.Now));
                return true;
            }
            else
                return false;
        }

        private static bool CanReturn(string bike)
        {
            return lstHistory.Any(x => x.BikeNO == bike)
                && lstHistory.Where(x => x.BikeNO == bike).OrderBy(x => x.Date)
                .Last().ToBorrow;
        }
        public static bool Return(string bike)
        {
            string user = lstHistory.Where(x => x.BikeNO == bike).OrderBy(x => x.Date)
                .Last().UserName;
            if (CanReturn(bike))
            {
                lstHistory.Add(new History(bike, user, false, DateTime.Now));
                return true;
            }
            else
                return false;
        }


        public static void ReadHistory()
        {
            if (!File.Exists(bikeFileName))
                return;
            FileStream fs = new FileStream(bikeFileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                lstHistory = (List<History>)formatter.Deserialize(fs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }



        public static void SaveHistory()
        {
            FileStream fs = new FileStream(bikeFileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, lstHistory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }

    [Serializable]
    public class History
    {
        public History(string bikeNO, string userName, bool toBorrow, DateTime date)
        {
            this.BikeNO = bikeNO;
            this.UserName = userName;
            this.ToBorrow = toBorrow;
            this.Date = date;
        }
        public string BikeNO { get; set; }
        public string UserName { get; set; }
        public bool ToBorrow { get; set; }
        public DateTime Date { get; set; }
    }
}
