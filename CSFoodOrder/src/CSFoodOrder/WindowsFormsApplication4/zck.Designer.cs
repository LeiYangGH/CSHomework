namespace WindowsFormsApplication4
{
    partial class zck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menus = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.qtcddh = new System.Windows.Forms.TabControl();
            this.cp1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cp2 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.spzltab = new System.Windows.Forms.TabPage();
            this.xgbtn = new System.Windows.Forms.Button();
            this.xzbtn = new System.Windows.Forms.Button();
            this.spzlcxtext = new System.Windows.Forms.TextBox();
            this.select = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splbtab = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnShowMenu = new System.Windows.Forms.Button();
            this.menus.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.qtcddh.SuspendLayout();
            this.cp1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.spzltab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menus
            // 
            this.menus.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.menus.Controls.Add(this.tabPage1);
            this.menus.Controls.Add(this.tabPage2);
            this.menus.Controls.Add(this.tabPage3);
            this.menus.Controls.Add(this.tabPage4);
            this.menus.Controls.Add(this.tabPage5);
            this.menus.Controls.Add(this.tabPage6);
            this.menus.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.menus.ItemSize = new System.Drawing.Size(40, 100);
            this.menus.Location = new System.Drawing.Point(0, 0);
            this.menus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.menus.Multiline = true;
            this.menus.Name = "menus";
            this.menus.Padding = new System.Drawing.Point(0, 0);
            this.menus.SelectedIndex = 0;
            this.menus.Size = new System.Drawing.Size(1514, 1005);
            this.menus.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.menus.TabIndex = 0;
            this.menus.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.menus_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnShowMenu);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.qtcddh);
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 8, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1406, 997);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "前台系统";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(207, 157);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(495, 553);
            this.dataGridView2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(838, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "前台菜单导航";
            // 
            // qtcddh
            // 
            this.qtcddh.Controls.Add(this.cp1);
            this.qtcddh.Controls.Add(this.cp2);
            this.qtcddh.Location = new System.Drawing.Point(842, 33);
            this.qtcddh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.qtcddh.Name = "qtcddh";
            this.qtcddh.SelectedIndex = 0;
            this.qtcddh.Size = new System.Drawing.Size(510, 965);
            this.qtcddh.TabIndex = 0;
            // 
            // cp1
            // 
            this.cp1.Controls.Add(this.flowLayoutPanel1);
            this.cp1.Location = new System.Drawing.Point(4, 29);
            this.cp1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cp1.Name = "cp1";
            this.cp1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cp1.Size = new System.Drawing.Size(502, 932);
            this.cp1.TabIndex = 0;
            this.cp1.Text = "红烧系列";
            this.cp1.UseVisualStyleBackColor = true;
            this.cp1.Click += new System.EventHandler(this.cp1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 5);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(494, 922);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // cp2
            // 
            this.cp2.Location = new System.Drawing.Point(4, 29);
            this.cp2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cp2.Name = "cp2";
            this.cp2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cp2.Size = new System.Drawing.Size(502, 932);
            this.cp2.TabIndex = 1;
            this.cp2.Text = "烧烤系列";
            this.cp2.UseVisualStyleBackColor = true;
            this.cp2.Click += new System.EventHandler(this.cp2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(104, 4);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1406, 997);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "基础资料";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.spzltab);
            this.tabControl2.Controls.Add(this.splbtab);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1358, 992);
            this.tabControl2.TabIndex = 0;
            // 
            // spzltab
            // 
            this.spzltab.Controls.Add(this.xgbtn);
            this.spzltab.Controls.Add(this.xzbtn);
            this.spzltab.Controls.Add(this.spzlcxtext);
            this.spzltab.Controls.Add(this.select);
            this.spzltab.Controls.Add(this.dataGridView1);
            this.spzltab.Location = new System.Drawing.Point(4, 29);
            this.spzltab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.spzltab.Name = "spzltab";
            this.spzltab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.spzltab.Size = new System.Drawing.Size(1350, 959);
            this.spzltab.TabIndex = 0;
            this.spzltab.Text = "商品资料";
            this.spzltab.UseVisualStyleBackColor = true;
            // 
            // xgbtn
            // 
            this.xgbtn.Location = new System.Drawing.Point(272, 12);
            this.xgbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xgbtn.Name = "xgbtn";
            this.xgbtn.Size = new System.Drawing.Size(150, 42);
            this.xgbtn.TabIndex = 4;
            this.xgbtn.Text = "修改";
            this.xgbtn.UseVisualStyleBackColor = true;
            this.xgbtn.Click += new System.EventHandler(this.xgbtn_Click);
            // 
            // xzbtn
            // 
            this.xzbtn.Location = new System.Drawing.Point(63, 12);
            this.xzbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xzbtn.Name = "xzbtn";
            this.xzbtn.Size = new System.Drawing.Size(150, 38);
            this.xzbtn.TabIndex = 3;
            this.xzbtn.Text = "新增";
            this.xzbtn.UseVisualStyleBackColor = true;
            this.xzbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // spzlcxtext
            // 
            this.spzlcxtext.Location = new System.Drawing.Point(807, 12);
            this.spzlcxtext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.spzlcxtext.Name = "spzlcxtext";
            this.spzlcxtext.Size = new System.Drawing.Size(217, 26);
            this.spzlcxtext.TabIndex = 2;
            this.spzlcxtext.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(1035, 7);
            this.select.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(148, 45);
            this.select.TabIndex = 1;
            this.select.Text = "查询";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 110);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1342, 802);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // splbtab
            // 
            this.splbtab.Location = new System.Drawing.Point(4, 29);
            this.splbtab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splbtab.Name = "splbtab";
            this.splbtab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splbtab.Size = new System.Drawing.Size(1350, 959);
            this.splbtab.TabIndex = 1;
            this.splbtab.Text = "商品类别";
            this.splbtab.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(104, 4);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(1406, 997);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "销售分析";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(104, 4);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Size = new System.Drawing.Size(1406, 997);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "库存管理";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(104, 4);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage5.Size = new System.Drawing.Size(1406, 997);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "系统设置";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(104, 4);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage6.Size = new System.Drawing.Size(1406, 997);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnShowMenu
            // 
            this.btnShowMenu.Location = new System.Drawing.Point(1033, 9);
            this.btnShowMenu.Name = "btnShowMenu";
            this.btnShowMenu.Size = new System.Drawing.Size(110, 37);
            this.btnShowMenu.TabIndex = 3;
            this.btnShowMenu.Text = "显示菜单";
            this.btnShowMenu.UseVisualStyleBackColor = true;
            this.btnShowMenu.Click += new System.EventHandler(this.btnShowMenu_Click);
            // 
            // zck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 1003);
            this.Controls.Add(this.menus);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "zck";
            this.Text = "软件主窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.zck_FormClosing);
            this.Load += new System.EventHandler(this.zck_Load);
            this.menus.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.qtcddh.ResumeLayout(false);
            this.cp1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.spzltab.ResumeLayout(false);
            this.spzltab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl menus;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabControl qtcddh;
        private System.Windows.Forms.TabPage cp1;
        private System.Windows.Forms.TabPage cp2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage spzltab;
        private System.Windows.Forms.TabPage splbtab;
        private System.Windows.Forms.DataGridView dataGridView1;
        //private ceshiDataSet2 ceshiDataSet2;
        //private System.Windows.Forms.BindingSource spzlBindingSource;
        //private ceshiDataSet2TableAdapters.spzlTableAdapter spzlTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn hHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zJMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn llbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ggDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dWDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jJDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsjDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bzDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox spzlcxtext;
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.Button xzbtn;
        private System.Windows.Forms.Button xgbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnShowMenu;
    }
}