using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P23
{
    public static class Repository
    {
        public static List<Ticket> lstTickets = new List<Ticket>();
        private const string ticketsFileName = "tickets.dat";

        public static void SaveTickets()
        {
            FileStream fs = new FileStream(ticketsFileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, lstTickets);
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

        public static void ReadTickets()
        {
            if (!File.Exists(ticketsFileName))
                return;
            FileStream fs = new FileStream(ticketsFileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                lstTickets = (List<Ticket>)formatter.Deserialize(fs);
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


        public static List<Passenger> lstPassengers = new List<Passenger>();
        private const string PassengersFileName = "Passengers.dat";

        public static void SavePassengers()
        {
            FileStream fs = new FileStream(PassengersFileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, lstPassengers);
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

        public static void ReadPassengers()
        {
            if (!File.Exists(PassengersFileName))
                return;
            FileStream fs = new FileStream(PassengersFileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                lstPassengers = (List<Passenger>)formatter.Deserialize(fs);
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
}
