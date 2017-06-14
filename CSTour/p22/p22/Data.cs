using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p22
{
    public sealed class data<T> where T : class
    {
        private List<T> lst;
        private string fileName;
        private Func<T, string[]> ColumnsData;
        public data(string TName, Func<T, string[]> columnsData)
        {
            this.lst = new List<T>();
            //this.fileName = Path.Combine(Environment.CurrentDirectory, $"{nameof(T)}.txt");
            this.fileName = Path.Combine(Environment.CurrentDirectory, TName + ".dat");
            this.ColumnsData = columnsData;
        }

        public bool Add(T t, Func<T, string> key)
        {
            if (this.lst.Any(x => key(x) == key(t)))
            {
                return false;
            }
            else
            {
                this.lst.Add(t);
                return true;
            }

        }

        public void Remove(T t)
        {
            this.lst.Add(t);
        }

        public void ReadFile()
        {
            if (!File.Exists(fileName))
                return;
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                this.lst = (List<T>)formatter.Deserialize(fs);
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

        public void SaveFile()
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, this.lst);
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

        public void AddAllToListView(ListView lvw)
        {
            lvw.BeginUpdate();
            lvw.Items.Clear();
            foreach (T t in this.lst)
            {
                string[] cols = this.ColumnsData(t);
                ListViewItem item = new ListViewItem(cols[0]);
                for (int i = 1; i < cols.Length; i++)
                    item.SubItems.Add(cols[i]);
                lvw.Items.Add(item);
            }
            lvw.EndUpdate();
        }


        public void AddOneToListView(ListView lvw, T t)
        {
            string[] cols = this.ColumnsData(t);
            ListViewItem item = new ListViewItem(cols[0]);
            for (int i = 1; i < cols.Length; i++)
                item.SubItems.Add(cols[i]);
            lvw.Items.Add(item);
        }
    }
}
