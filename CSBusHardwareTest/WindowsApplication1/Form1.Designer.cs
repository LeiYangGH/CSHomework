namespace WindowsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_devtype = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_Time1 = new System.Windows.Forms.TextBox();
            this.txt_AccMask = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_Mode = new System.Windows.Forms.ComboBox();
            this.cbo_Filter = new System.Windows.Forms.ComboBox();
            this.txt_Time0 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_AccCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_CANIndex = new System.Windows.Forms.ComboBox();
            this.cbo_DevIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnStartCAN = new System.Windows.Forms.Button();
            this.btnStopCAN = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbo_FrameFormat = new System.Windows.Forms.ComboBox();
            this.cbo_FrameType = new System.Windows.Forms.ComboBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Data = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lb_Info = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_devtype);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbo_CANIndex);
            this.groupBox1.Controls.Add(this.cbo_DevIndex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(638, 230);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备参数";
            // 
            // cbo_devtype
            // 
            this.cbo_devtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_devtype.FormattingEnabled = true;
            this.cbo_devtype.Items.AddRange(new object[] {
            "3",
            "4"});
            this.cbo_devtype.Location = new System.Drawing.Point(76, 32);
            this.cbo_devtype.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_devtype.MaxDropDownItems = 15;
            this.cbo_devtype.Name = "cbo_devtype";
            this.cbo_devtype.Size = new System.Drawing.Size(180, 28);
            this.cbo_devtype.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 38);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 20);
            this.label14.TabIndex = 4;
            this.label14.Text = "类型:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_Time1);
            this.groupBox2.Controls.Add(this.txt_AccMask);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbo_Mode);
            this.groupBox2.Controls.Add(this.cbo_Filter);
            this.groupBox2.Controls.Add(this.txt_Time0);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_AccCode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(15, 83);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(608, 128);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "初始化CAN参数";
            // 
            // txt_Time1
            // 
            this.txt_Time1.Location = new System.Drawing.Point(327, 77);
            this.txt_Time1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Time1.Name = "txt_Time1";
            this.txt_Time1.Size = new System.Drawing.Size(40, 26);
            this.txt_Time1.TabIndex = 1;
            // 
            // txt_AccMask
            // 
            this.txt_AccMask.Location = new System.Drawing.Point(111, 77);
            this.txt_AccMask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_AccMask.Name = "txt_AccMask";
            this.txt_AccMask.Size = new System.Drawing.Size(103, 26);
            this.txt_AccMask.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "定时器1:0x";
            // 
            // cbo_Mode
            // 
            this.cbo_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Mode.FormattingEnabled = true;
            this.cbo_Mode.Items.AddRange(new object[] {
            "正常",
            "只听",
            "自测"});
            this.cbo_Mode.Location = new System.Drawing.Point(476, 80);
            this.cbo_Mode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_Mode.Name = "cbo_Mode";
            this.cbo_Mode.Size = new System.Drawing.Size(103, 28);
            this.cbo_Mode.TabIndex = 1;
            // 
            // cbo_Filter
            // 
            this.cbo_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Filter.FormattingEnabled = true;
            this.cbo_Filter.Items.AddRange(new object[] {
            "接收全部类型",
            "只接收标准帧",
            "只接收扩展帧"});
            this.cbo_Filter.Location = new System.Drawing.Point(476, 35);
            this.cbo_Filter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_Filter.Name = "cbo_Filter";
            this.cbo_Filter.Size = new System.Drawing.Size(103, 28);
            this.cbo_Filter.TabIndex = 1;
            // 
            // txt_Time0
            // 
            this.txt_Time0.Location = new System.Drawing.Point(327, 32);
            this.txt_Time0.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Time0.Name = "txt_Time0";
            this.txt_Time0.Size = new System.Drawing.Size(40, 26);
            this.txt_Time0.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(420, 87);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "模式:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(384, 42);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "滤波方式:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "屏蔽码:0x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "定时器0:0x";
            // 
            // txt_AccCode
            // 
            this.txt_AccCode.Location = new System.Drawing.Point(111, 32);
            this.txt_AccCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_AccCode.Name = "txt_AccCode";
            this.txt_AccCode.Size = new System.Drawing.Size(103, 26);
            this.txt_AccCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "验收码:0x";
            // 
            // cbo_CANIndex
            // 
            this.cbo_CANIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_CANIndex.FormattingEnabled = true;
            this.cbo_CANIndex.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cbo_CANIndex.Location = new System.Drawing.Point(552, 38);
            this.cbo_CANIndex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_CANIndex.Name = "cbo_CANIndex";
            this.cbo_CANIndex.Size = new System.Drawing.Size(68, 28);
            this.cbo_CANIndex.TabIndex = 1;
            // 
            // cbo_DevIndex
            // 
            this.cbo_DevIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_DevIndex.FormattingEnabled = true;
            this.cbo_DevIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cbo_DevIndex.Location = new System.Drawing.Point(357, 38);
            this.cbo_DevIndex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_DevIndex.Name = "cbo_DevIndex";
            this.cbo_DevIndex.Size = new System.Drawing.Size(60, 28);
            this.cbo_DevIndex.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "第几路CAN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "索引号:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(678, 65);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 38);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // btnStartCAN
            // 
            this.btnStartCAN.Location = new System.Drawing.Point(678, 145);
            this.btnStartCAN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartCAN.Name = "btnStartCAN";
            this.btnStartCAN.Size = new System.Drawing.Size(112, 38);
            this.btnStartCAN.TabIndex = 5;
            this.btnStartCAN.Text = "启动CAN";
            this.btnStartCAN.UseVisualStyleBackColor = true;
            this.btnStartCAN.Click += new System.EventHandler(this.button_StartCAN_Click);
            // 
            // btnStopCAN
            // 
            this.btnStopCAN.Location = new System.Drawing.Point(678, 242);
            this.btnStopCAN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStopCAN.Name = "btnStopCAN";
            this.btnStopCAN.Size = new System.Drawing.Size(112, 38);
            this.btnStopCAN.TabIndex = 5;
            this.btnStopCAN.Text = "复位CAN";
            this.btnStopCAN.UseVisualStyleBackColor = true;
            this.btnStopCAN.Click += new System.EventHandler(this.button_StopCAN_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbo_FrameFormat);
            this.groupBox3.Controls.Add(this.cbo_FrameType);
            this.groupBox3.Controls.Add(this.button_Send);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txt_Data);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txt_ID);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(18, 260);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(638, 135);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送数据帧";
            // 
            // cbo_FrameFormat
            // 
            this.cbo_FrameFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_FrameFormat.FormattingEnabled = true;
            this.cbo_FrameFormat.Items.AddRange(new object[] {
            "数据帧",
            "远程帧"});
            this.cbo_FrameFormat.Location = new System.Drawing.Point(294, 32);
            this.cbo_FrameFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_FrameFormat.Name = "cbo_FrameFormat";
            this.cbo_FrameFormat.Size = new System.Drawing.Size(103, 28);
            this.cbo_FrameFormat.TabIndex = 1;
            // 
            // cbo_FrameType
            // 
            this.cbo_FrameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_FrameType.FormattingEnabled = true;
            this.cbo_FrameType.Items.AddRange(new object[] {
            "标准帧",
            "扩展帧"});
            this.cbo_FrameType.Location = new System.Drawing.Point(104, 33);
            this.cbo_FrameType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_FrameType.Name = "cbo_FrameType";
            this.cbo_FrameType.Size = new System.Drawing.Size(103, 28);
            this.cbo_FrameType.TabIndex = 1;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(488, 78);
            this.button_Send.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(112, 38);
            this.button_Send.TabIndex = 5;
            this.button_Send.Text = "发送";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 38);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "帧格式:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 40);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "帧类型:";
            // 
            // txt_Data
            // 
            this.txt_Data.Location = new System.Drawing.Point(84, 80);
            this.txt_Data.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Data.Name = "txt_Data";
            this.txt_Data.Size = new System.Drawing.Size(374, 26);
            this.txt_Data.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 90);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "数据:";
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(483, 30);
            this.txt_ID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(103, 26);
            this.txt_ID.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(408, 40);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "帧ID:0x";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lb_Info);
            this.groupBox4.Location = new System.Drawing.Point(18, 405);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(795, 343);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "信息";
            // 
            // lb_Info
            // 
            this.lb_Info.FormattingEnabled = true;
            this.lb_Info.ItemHeight = 20;
            this.lb_Info.Location = new System.Drawing.Point(15, 33);
            this.lb_Info.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(763, 284);
            this.lb_Info.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(678, 332);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 38);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "清空列表";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 768);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnStopCAN);
            this.Controls.Add(this.btnStartCAN);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "USB CAN Demo(创芯光电科技有限公司)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cbo_CANIndex;
        private System.Windows.Forms.ComboBox cbo_DevIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Time1;
        private System.Windows.Forms.TextBox txt_AccMask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Time0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_AccCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_Mode;
        private System.Windows.Forms.ComboBox cbo_Filter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnStartCAN;
        private System.Windows.Forms.Button btnStopCAN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbo_FrameFormat;
        private System.Windows.Forms.ComboBox cbo_FrameType;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Data;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lb_Info;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cbo_devtype;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClear;
    }
}

