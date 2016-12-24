using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Main_interface
{
    public partial class score : Form
    {
        private IList<DataRow> currentSubAreaDataRows;
        private int sortByColumnIndex = 0;
        const int scoreIndex = 11;

        public score()
        {
            InitializeComponent();
        }

        private void AddSitesInfoToComboboxes()
        {
            this.cboRound.DataSource = Enumerable.Range(1, SharedData.TotalRounds).ToArray();
            this.cboArea.DataSource = Enumerable.Range(1, SharedData.TotalAreas).ToArray();
            this.cboSubArea.DataSource = Enumerable.Range(1, 2).ToArray();
        }

        private void score_Load(object sender, EventArgs e)
        {
            this.AddSitesInfoToComboboxes();
            this.cboRound.Text = "1";
            this.cboArea.Text = "1";
            this.cboSubArea.Text = "1";
            GetSelectedSubAreaDataRowsAndToListView();
        }

        private void GetSelectedSubAreaDataRowsAndToListView()
        {
            int round = Convert.ToInt32(this.cboRound.Text);
            int area = Convert.ToInt32(this.cboArea.Text);
            int subArea = Convert.ToInt32(this.cboSubArea.Text);

            this.currentSubAreaDataRows = SharedData.GetScoreDatarowsOfCertainSubArea(round, area, subArea == 1);
            SharedData.ShowDataRowsToListView(this.listView1, this.currentSubAreaDataRows);
        }

        //确定按钮，显示数据
        private void button2_Click(object sender, EventArgs e)
        {
            GetSelectedSubAreaDataRowsAndToListView();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.sortByColumnIndex = 8;
            this.SortItemsColumnByIndex();
            var dic = SharedData.CalculateScoreEachItem(this.currentSubAreaDataRows, this.sortByColumnIndex);
            this.ShowScoresForEachItem(dic);
        }




        /// <summary>
        /// 计算并显示成绩
        /// </summary>
        private void ShowScoresForEachItem(Dictionary<int, double> dicScores)
        {

            for (int i = 0; i < this.currentSubAreaDataRows.Count; i++)
            {
                this.currentSubAreaDataRows[i][11] = dicScores[i];
            }
            SharedData.ShowDataRowsToListView(this.listView1, this.currentSubAreaDataRows);

        }

        /// <summary>
        /// 根据当前选择的列来排序
        /// </summary>
        private void SortItemsColumnByIndex()
        {
            this.currentSubAreaDataRows = this.currentSubAreaDataRows
                .OrderByDescending(x =>
                 Convert.ToDouble(x[this.sortByColumnIndex])).ToList();
            SharedData.ShowDataRowsToListView(this.listView1, this.currentSubAreaDataRows);

        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.sortByColumnIndex = 9;
            this.SortItemsColumnByIndex();
            var dic = SharedData.CalculateScoreEachItem(this.currentSubAreaDataRows, this.sortByColumnIndex);
            this.ShowScoresForEachItem(dic);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {


        }



        private void btnTotalScores_Click(object sender, EventArgs e)
        {
            frmScoreByPersonTeam frm = new frmScoreByPersonTeam();
            frm.Show();
        }

    }
}
