using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Main_interface
{
    public partial class frmScoreByPersonTeam : Form
    {
        private DataTable UniquePlayersScoresDataTable;
        private DataTable TeamScoresDataTable;
        public frmScoreByPersonTeam()
        {
            InitializeComponent();
        }

        public DataTable CreatePersonalScoresDataTableWithDefaultColumns(bool orderByWeight = true)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("名次", typeof(string));
            dt.Columns.Add("参赛证号", typeof(string));
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("团队", typeof(string));
            for (int i = 1; i <= SharedData.TotalRounds; i++)
            {
                dt.Columns.Add(string.Format("第{0}场得分", i), typeof(string));
                string colNameFormat = orderByWeight ? "第{0}场重量" : "第{0}场尾数";
                dt.Columns.Add(string.Format(colNameFormat, i), typeof(string));
            }
            dt.Columns.Add("总得分", typeof(string));
            return dt;
        }


        public DataTable CreateTeamScoresDataTableWithDefaultColumns(bool orderByWeight = true)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("名次", typeof(string));
            dt.Columns.Add("团队", typeof(string));
            for (int i = 1; i <= SharedData.TotalRounds; i++)
            {
                string colNameFormat = orderByWeight ? "第{0}场总重量" : "第{0}场总尾数";
                dt.Columns.Add(string.Format(colNameFormat, i), typeof(string));
            }
            dt.Columns.Add("最终成绩", typeof(string));
            return dt;
        }

        private void DisplayAllPlayersBasicInfo(bool orderByWeight = true)
        {

            for (int rowIndex = 0; rowIndex < SharedData.AllUniquePlayersInfo.Count; rowIndex++)
            {
                DataRow fromRow = SharedData.AllUniquePlayersInfo[rowIndex];
                DataRow newrow = this.UniquePlayersScoresDataTable.NewRow();
                newrow[1] = fromRow[1];
                newrow[2] = fromRow[0];
                newrow[3] = fromRow[3];

                this.UniquePlayersScoresDataTable.Rows.Add(newrow);
            }

        }

        private void SortAllPlayersByScores()
        {
            DataTable copy = this.UniquePlayersScoresDataTable.Copy();

            var sortedRows = copy.Rows.OfType<DataRow>()
                  .OrderBy(x => Convert.ToDouble(x[this.UniquePlayersScoresDataTable.Columns.Count - 1])).ToArray();

            this.UniquePlayersScoresDataTable.Rows.Clear();

            for (int rowIndex = 0; rowIndex < sortedRows.Count(); rowIndex++)
            {
                DataRow row = sortedRows[rowIndex];
                row[0] = rowIndex + 1;
                this.UniquePlayersScoresDataTable.ImportRow(row);
            }
        }

        private void DisplayAllPlayersScores(Dictionary<int, Dictionary<string, double>> dicResult, bool orderByWeight = true)
        {

            for (int rowIndex = 0; rowIndex < SharedData.AllUniquePlayersInfo.Count; rowIndex++)
            {
                DataRow PlayerTotalScoresRow = this.UniquePlayersScoresDataTable.Rows[rowIndex];
                string playerName = PlayerTotalScoresRow[2].ToString();

                int sortByColumnIndex = orderByWeight ? 8 : 9;
                for (int colIndex = 4; colIndex < this.UniquePlayersScoresDataTable.Columns.Count - 1; colIndex++)
                {
                    string colName = this.UniquePlayersScoresDataTable.Columns[colIndex].ColumnName;
                    int round = -1;

                    if (colName.Contains("得分"))
                    {
                        round = Convert.ToInt32(string.Join("", colName.Where(x => char.IsDigit(x))));
                        PlayerTotalScoresRow[colIndex] = dicResult[round][playerName];
                    }
                    else if (colName.Contains("重量"))
                    {
                        round = Convert.ToInt32(string.Join("", colName.Where(x => char.IsDigit(x))));
                        DataRow player = SharedData.GetScoreDatarowsOfCertainSubArea(round, null, null).FirstOrDefault(x => x[0].ToString() == playerName);

                        if (player == null)
                        {

                            PlayerTotalScoresRow[colIndex] = "0";
                        }
                        else
                        {
                            PlayerTotalScoresRow[colIndex] = player[sortByColumnIndex].ToString();
                        }

                    }

                    else if (colName.Contains("尾数"))
                    {
                        round = Convert.ToInt32(string.Join("", colName.Where(x => char.IsDigit(x))));
                        DataRow player = SharedData.GetScoreDatarowsOfCertainSubArea(round, null, null).FirstOrDefault(x => x[0].ToString() == playerName);

                        if (player == null)
                        {

                            PlayerTotalScoresRow[colIndex] = "0";
                        }
                        else
                        {
                            PlayerTotalScoresRow[colIndex] = player[sortByColumnIndex].ToString();
                        }

                    }
                }
                PlayerTotalScoresRow[this.UniquePlayersScoresDataTable.Columns.Count - 1] = this.CalculateTotalScoreForEachPlayer(dicResult, playerName).ToString();
            }

        }

        private double CalculateTotalScoreForEachPlayer(Dictionary<int, Dictionary<string, double>> dicResult, string playerName)
        {
            double sum = 0;
            foreach (var kvRound in dicResult)
            {
                sum += kvRound.Value.First(x => x.Key == playerName).Value;
            }
            return sum;
        }

        private Dictionary<int, Dictionary<string, double>> CalculateScoreOfEachPlayerInEachRound(bool orderByWeight = true)
        {
            var dicResult = new Dictionary<int, Dictionary<string, double>>();
            int sortByColumnIndex = orderByWeight ? 8 : 9;
            int absenseScore = SharedData.PlayersCountInEachSubArea + 1;
            for (int round = 1; round <= SharedData.TotalRounds; round++)
            {
                var dicScoresInArea = new Dictionary<string, double>();
                for (int area = 1; area <= SharedData.TotalAreas; area++)
                {

                    IList<DataRow> half1 = SharedData.GetScoreDatarowsOfCertainSubArea(round, area, true);
                    this.AddScoresInSubAreaToArea(dicScoresInArea, half1, sortByColumnIndex);

                    IList<DataRow> half2 = SharedData.GetScoreDatarowsOfCertainSubArea(round, area, false);
                    this.AddScoresInSubAreaToArea(dicScoresInArea, half2, sortByColumnIndex);
                }
                foreach (string absenseName in SharedData.AllPlayersNames.Except(dicScoresInArea.Select(x => x.Key)))
                {
                    dicScoresInArea.Add(absenseName, absenseScore);
                }
                dicResult.Add(round, dicScoresInArea);
            }

            return dicResult;
        }

        private void AddScoresInSubAreaToArea(Dictionary<string, double> dicArea, IList<DataRow> DataRows, int sortByColumnIndex)
        {
            DataRows = DataRows.OrderByDescending(x => Convert.ToDouble(x[sortByColumnIndex])).ToList();
            Dictionary<int, double> dicScores = SharedData.CalculateScoreEachItem(DataRows,
                sortByColumnIndex);
            foreach (var kv in dicScores)
            {
                string name = DataRows[kv.Key][0].ToString();
                dicArea.Add(name, kv.Value);
            }
        }

        private void frmScoreByPersonTeam_Load(object sender, EventArgs e)
        {
            this.CalculateAndDisplayTeamScores(true);
        }

        private void CalculateAndDisplayPlayerScores(bool orderByWeight = true)
        {
            this.UniquePlayersScoresDataTable = this.CreatePersonalScoresDataTableWithDefaultColumns(orderByWeight);
            this.DisplayAllPlayersBasicInfo(orderByWeight);
            var dicResult = this.CalculateScoreOfEachPlayerInEachRound(orderByWeight);
            this.DisplayAllPlayersScores(dicResult, orderByWeight);
            this.SortAllPlayersByScores();
            this.dgvPeron.DataSource = this.UniquePlayersScoresDataTable;
        }


        private void btnByWeight_Click(object sender, EventArgs e)
        {
            this.CalculateAndDisplayPlayerScores(true);
        }

        private void btnByCount_Click(object sender, EventArgs e)
        {
            this.CalculateAndDisplayPlayerScores(false);
        }

        private int GetPlayerTableColumnIndexOfScoreInRound(int round)
        {
            var columnsList = this.UniquePlayersScoresDataTable.Columns.OfType<DataColumn>().ToList();
            return columnsList.IndexOf(columnsList.First(x => x.ColumnName.Contains(round.ToString())));
        }

        private IList<DataRow> GetTop30PlayersRows(DataTable uniquePlayersScoresDataTable)
        {
#if LYDEV
            return uniquePlayersScoresDataTable.Rows.OfType<DataRow>().ToList();
#endif

#if !LYDEV
            return uniquePlayersScoresDataTable.Rows.OfType<DataRow>()
                 .OrderBy(x => Convert.ToDouble(x[this.TeamScoresDataTable.Columns.Count - 1]))
                 .Take(Convert.ToInt32(this.numericUpDown1.Value)).ToList();//这里面改成30
#endif


        }

        private void CalculateAndSetTotalWeightOrCountForTeam(DataRow row, bool orderByWeight = true)
        {
            string currentOrderBy = orderByWeight ? "重量" : "尾数";
            row[this.TeamScoresDataTable.Columns.Count - 1] = this.TeamScoresDataTable.Columns.OfType<DataColumn>()
                .Where(x => x.ColumnName.Contains(currentOrderBy))
                .Sum(x => Convert.ToDouble(row[x]));
        }

        private void CalculateAndDisplayTeamScores(bool orderByWeight = true)
        {
            this.CalculateAndDisplayPlayerScores(orderByWeight);
            this.TeamScoresDataTable = this.CreateTeamScoresDataTableWithDefaultColumns(orderByWeight);

            var v = this.GetTop30PlayersRows(this.UniquePlayersScoresDataTable)
                .GroupBy(x => x[3].ToString()); ;

            foreach (var teamData in v)
            {
                DataRow newRow = this.TeamScoresDataTable.NewRow();
                newRow[0] = "order";
                newRow[1] = teamData.Key;

                for (int colIndex = 2; colIndex < this.TeamScoresDataTable.Columns.Count - 1; colIndex++)
                {
                    string colName = this.TeamScoresDataTable.Columns[colIndex].ColumnName;
                    int round = -1;
                    round = Convert.ToInt32(string.Join("", colName.Where(x => char.IsDigit(x))));
                    int playerColIndex = this.GetPlayerTableColumnIndexOfScoreInRound(round) + 1;
                    newRow[colIndex] = teamData.Sum(x => Convert.ToDouble(x[playerColIndex]));
                }
                this.CalculateAndSetTotalWeightOrCountForTeam(newRow, orderByWeight);
                this.TeamScoresDataTable.Rows.Add(newRow);
            }

            this.SortAllTeamsByScores();
            this.dgvTeam.DataSource = this.TeamScoresDataTable;
        }

        private void SortAllTeamsByScores()
        {
            DataTable copy = this.TeamScoresDataTable.Copy();

            var sortedRows = copy.Rows.OfType<DataRow>()
                  .OrderBy(x => Convert.ToDouble(x[this.TeamScoresDataTable.Columns.Count - 1])).ToArray();

            this.TeamScoresDataTable.Rows.Clear();

            for (int rowIndex = 0; rowIndex < sortedRows.Count(); rowIndex++)
            {
                DataRow row = sortedRows[rowIndex];
                row[0] = rowIndex + 1;
                this.TeamScoresDataTable.ImportRow(row);
            }
        }

        private void btnTeamWeight_Click(object sender, EventArgs e)
        {
            this.CalculateAndDisplayTeamScores(true);
        }

        private void btnTeamCount_Click(object sender, EventArgs e)
        {
            this.CalculateAndDisplayTeamScores(false);
        }
    }
}
