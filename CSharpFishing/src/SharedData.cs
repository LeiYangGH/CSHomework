using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Main_interface
{
    public static class SharedData
    {
        static SharedData()
        {
            SharedData.ReadSitesInfo();
            SharedData.ReadAllSoresFileToDataRows();
            SharedData.GetUniquePlayersInfo();
        }

        public static int TotalRounds { get; set; }
        public static int TotalAreas { get; set; }
        public static int PlayersCountInEachSubArea { get; set; }
        public static IList<DataRow> AllScoresDatarows { get; set; }

        public const int RoundColumnIndex = 5;
        public const int AreaColumnIndex = 6;
        public const int TotalColumnsCountIncludingScore = 12;
        public static string[] AllPlayersNames;
        public static IList<DataRow> AllUniquePlayersInfo;
        public static void ReadSitesInfo()
        {
            string sitesInfoFileName = @"site.txt";
            string line0 = File.ReadLines(sitesInfoFileName).First();
            string[] ss = line0.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            SharedData.TotalRounds = Convert.ToInt32(ss[0]);
            SharedData.TotalAreas = Convert.ToInt32(ss[1]);
            SharedData.PlayersCountInEachSubArea = Convert.ToInt32(ss[3]);
        }

        public static DataTable CreateScoresDataTableWithDefaultColumns()
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < SharedData.TotalColumnsCountIncludingScore; i++)
            {
                string colName = "Col" + i.ToString();
                dt.Columns.Add(colName, typeof(string));
            }
            return dt;
        }

        public static DataRow SplitScoreLineToRow(DataTable dt, string line)
        {
            DataRow dr = dt.NewRow();
            string[] ss = line.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < SharedData.TotalColumnsCountIncludingScore - 1; i++)
            {
                dr[i] = ss[i];
            }
            dr[11] = "";//score
            return dr;
        }

        public static IList<DataRow> ReadOneSoresFileToDataRows(string txtFileName)
        {
            DataTable dt = SharedData.CreateScoresDataTableWithDefaultColumns();
            List<DataRow> lst = new List<DataRow>();
            foreach (string line in File.ReadLines(txtFileName,
                Encoding.GetEncoding("gb2312")))
            {
                lst.Add(SharedData.SplitScoreLineToRow(dt, line));
            }
            return lst;
        }


        public static void ReadAllSoresFileToDataRows()
        {
            Regex reg = new Regex(@"录入成绩\d#\d.txt");
            DataTable dt = SharedData.CreateScoresDataTableWithDefaultColumns();
            List<DataRow> lst = new List<DataRow>();
            foreach (string scoreFileName in
                Directory.GetFiles(Environment.CurrentDirectory, "*.txt")
                .Where(x => reg.IsMatch(x)))
            {
                foreach (var row in SharedData.ReadOneSoresFileToDataRows(scoreFileName))
                    lst.Add(row);
            }
            SharedData.AllScoresDatarows = lst;
        }

        public static IList<DataRow> GetScoreDatarowsOfCertainSubArea(int round, int? area, bool? firstHalf)
        {
            var areaRows = SharedData.AllScoresDatarows.Where(x =>
            Convert.ToInt32(x[SharedData.RoundColumnIndex]) == round);

            if (area != null)
                areaRows = areaRows.Where(x =>
  Convert.ToInt32(x[SharedData.AreaColumnIndex]) == area.Value);

            int count = areaRows.Count();
            int halfCount = (int)Math.Ceiling(count / 2.0d);
            var halfRows = areaRows.ToList();
            if (firstHalf != null)
            {
                if (firstHalf.Value)
                {
                    halfRows = halfRows.Take(halfCount).ToList();
                }
                else
                {
                    halfRows = halfRows.Skip(halfCount).ToList();
                }
            }
            return halfRows;
        }

        public static Dictionary<int, double> CalculateScoreEachItem(IList<DataRow> DataRows, int sortByColumnIndex)
        {
            double[] displayNums = DataRows.Select(x =>
            Convert.ToDouble(x[sortByColumnIndex])).ToArray();
            Dictionary<double, int> timesDic = displayNums.Distinct().Select(x =>
                new
                {
                    k = x,
                    c = displayNums.Count(y => y == x)
                }).ToDictionary(x => x.k, x => x.c);

            int toFillIndex = 0;
            Dictionary<int, double> dicScores = new Dictionary<int, double>();
            foreach (var kv in timesDic)
            {
                int cnt = kv.Value;
                int toFillIndexStart = toFillIndex;
                double ave = Enumerable.Range(toFillIndexStart + 1, cnt).Sum() / (double)cnt;
                for (int i = 0; i < cnt; i++)
                    dicScores.Add(toFillIndex++, ave);
            }
            return dicScores;
        }

        public static void ShowDataRowsToListView(ListView lvw, IEnumerable<DataRow> rows)
        {
            lvw.Items.Clear();
            lvw.BeginUpdate();
            foreach (DataRow row in rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < row.Table.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                lvw.Items.Add(item);
            }
            lvw.EndUpdate();
        }

        public static void GetUniquePlayersInfo()
        {
            SharedData.AllPlayersNames = SharedData.AllScoresDatarows
              .Select(x => x[0].ToString()).Distinct().ToArray();

            SharedData.AllUniquePlayersInfo = SharedData.AllPlayersNames
                .Select(x => SharedData.AllScoresDatarows.First(y =>
                  y[0].ToString() == x)).ToArray();
        }

    }
}
