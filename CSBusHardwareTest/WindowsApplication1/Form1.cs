using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

/*------------兼容ZLG的数据类型---------------------------------*/

//1.ZLGCAN系列接口卡信息的数据类型。
public struct BOARD
{
    public UInt16 hw_Version;
    public UInt16 fw_Version;
    public UInt16 dr_Version;
    public UInt16 in_Version;
    public UInt16 irq_Num;
    public byte can_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public byte[] str_Serial_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
    public byte[] str_hw_Type;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] Reserved;
}

/////////////////////////////////////////////////////
//2.定义CAN信息帧的数据类型。
unsafe public struct CAN  //使用不安全代码
{
    public uint ID;
    public uint TimeStamp;        //时间标识
    public byte IsTime;         //是否使用时间标识
    public byte SendType;         //发送标志。保留，未用
    public byte IsRemote;       //是否是远程帧
    public byte IsExtern;       //是否是扩展帧
    public byte DataLength;          //数据长度
    public fixed byte Data[8];    //数据
    public fixed byte Reserved[3];//保留位

}

//3.定义初始化CAN的数据类型
public struct INIT
{
    public UInt32 AccCode;
    public UInt32 AccMask;
    public UInt32 Reserved;
    public byte Filter;   //0或1接收所有帧。2标准帧滤波，3是扩展帧滤波。
    public byte Timing0;  //波特率参数，具体配置，请查看二次开发库函数说明书。
    public byte Timing1;
    public byte Mode;     //模式，0表示正常模式，1表示只听模式,2自测模式
}

/*------------其他数据结构描述---------------------------------*/
//4.USB-CAN总线适配器板卡信息的数据类型1，该类型为FindUsbDevice函数的返回参数。
public struct BOARD1
{
    public UInt16 hw_Version;
    public UInt16 fw_Version;
    public UInt16 dr_Version;
    public UInt16 in_Version;
    public UInt16 irq_Num;
    public byte can_Num;
    public byte Reserved;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] str_Serial_Num;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] str_hw_Type;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] str_Usb_Serial;
}

/*------------数据结构描述完成---------------------------------*/

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        const int DEV_USBCAN = 3;
        const int DEV_USBCAN2 = 4;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceType"></param>
        /// <param name="deviceID"></param>
        /// <param name="Reserved"></param>
        /// <returns></returns>
        /*------------兼容ZLG的函数描述---------------------------------*/
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_OpenDevice(UInt32 deviceType, UInt32 deviceID, UInt32 Reserved);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_CloseDevice(UInt32 deviceType, UInt32 deviceID);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_InitCAN(UInt32 deviceType, UInt32 deviceID, UInt32 CANInd, ref INIT pInitConfig);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ReadBoardInfo(UInt32 deviceType, UInt32 deviceID, ref BOARD pInfo);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_GetReceiveNum(UInt32 deviceType, UInt32 deviceID, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ClearBuffer(UInt32 deviceType, UInt32 deviceID, UInt32 CANInd);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_StartCAN(UInt32 deviceType, UInt32 deviceID, UInt32 CANInd);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ResetCAN(UInt32 deviceType, UInt32 deviceID, UInt32 CANInd);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_Transmit(UInt32 deviceType, UInt32 deviceID, UInt32 CANInd, ref CAN pSend, UInt32 Len);

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_Receive(UInt32 deviceType, UInt32 deviceID, UInt32 CANInd, ref CAN pReceive, UInt32 Len, Int32 WaitTime);

        /*------------其他函数描述---------------------------------*/

        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_ConnectDevice(UInt32 DevType, UInt32 DevIndex);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_UsbDeviceReset(UInt32 DevType, UInt32 DevIndex, UInt32 Reserved);
        [DllImport("controlcan.dll")]
        static extern UInt32 VCI_FindUsbDevice(ref BOARD1 pInfo);
        /*------------函数描述结束---------------------------------*/

        static UInt32 deviceType = 4;//USBCAN2

        bool isOpen = false;
        UInt32 deviceId = 0;
        UInt32 canId = 0;

        CAN[] arrCANs = new CAN[1000];

        UInt32[] arrDeviceTypes = new UInt32[20];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbo_DevIndex.SelectedIndex = 0;
            cbo_CANIndex.SelectedIndex = 0;
            txt_AccCode.Text = "00000000";
            txt_AccMask.Text = "FFFFFFFF";
            txt_Time0.Text = "03";
            txt_Time1.Text = "1C";
            cbo_Filter.SelectedIndex = 0;              //接收所有类型
            cbo_Mode.SelectedIndex = 2;                //还回测试模式
            cbo_FrameFormat.SelectedIndex = 0;
            cbo_FrameType.SelectedIndex = 0;
            txt_ID.Text = "000002b0";
            txt_Data.Text = "00 00 00 00 00 08 00 00 ";

            Int32 curindex = 0;
            cbo_devtype.Items.Clear();

            curindex = cbo_devtype.Items.Add("DEV_USBCAN");
            arrDeviceTypes[curindex] = DEV_USBCAN;

            curindex = cbo_devtype.Items.Add("DEV_USBCAN2");
            arrDeviceTypes[curindex] = DEV_USBCAN2;

            cbo_devtype.SelectedIndex = 1;
            cbo_devtype.MaxDropDownItems = cbo_devtype.Items.Count;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isOpen)
            {
                VCI_CloseDevice(deviceType, deviceId);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (isOpen)
            {
                VCI_CloseDevice(deviceType, deviceId);
                isOpen = false;
            }
            else
            {
                deviceType = arrDeviceTypes[cbo_devtype.SelectedIndex];

                deviceId = (UInt32)cbo_DevIndex.SelectedIndex;
                canId = (UInt32)cbo_CANIndex.SelectedIndex;
                if (VCI_OpenDevice(deviceType, deviceId, 0) == 0)
                {
                    MessageBox.Show("打开设备失败,请检查设备类型和设备索引号是否正确", "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                isOpen = true;
                INIT config = new INIT();
                config.AccCode = Convert.ToUInt32("0x" + txt_AccCode.Text, 16);
                config.AccMask = Convert.ToUInt32("0x" + txt_AccMask.Text, 16);
                config.Timing0 = Convert.ToByte("0x" + txt_Time0.Text, 16);
                config.Timing1 = Convert.ToByte("0x" + txt_Time1.Text, 16);
                config.Filter = (Byte)(cbo_Filter.SelectedIndex + 1);
                config.Mode = (Byte)cbo_Mode.SelectedIndex;
                VCI_InitCAN(deviceType, deviceId, canId, ref config);
            }
            btnConnect.Text = isOpen ? "断开" : "连接";
            timer1.Enabled = isOpen ? true : false;
        }



        unsafe private void timer1_Tick(object sender, EventArgs e)
        {
            UInt32 res = new UInt32();

            res = VCI_Receive(deviceType, deviceId, canId, ref arrCANs[0], 1000, 100);


            String str = "";
            for (UInt32 i = 0; i < res; i++)
            {


                str = "接收到数据: ";
                str += "  帧ID:0x" + Convert.ToString(arrCANs[i].ID, 16);
                str += "  帧格式:";
                if (arrCANs[i].IsRemote == 0)
                    str += "数据帧 ";
                else
                    str += "远程帧 ";
                if (arrCANs[i].IsExtern == 0)
                    str += "标准帧 ";
                else
                    str += "扩展帧 ";

                //////////////////////////////////////////
                if (arrCANs[i].IsRemote == 0)
                {
                    str += "数据: ";
                    byte len = (byte)(arrCANs[i].DataLength % 9);
                    byte j = 0;
                    fixed (CAN* can = &arrCANs[i])
                    {
                        if (j++ < len)
                            str += " " + Convert.ToString(can->Data[0], 16);
                        if (j++ < len)
                            str += " " + Convert.ToString(can->Data[1], 16);
                        if (j++ < len)
                            str += " " + Convert.ToString(can->Data[2], 16);
                        if (j++ < len)
                            str += " " + Convert.ToString(can->Data[3], 16);
                        if (j++ < len)
                            str += " " + Convert.ToString(can->Data[4], 16);
                        if (j++ < len)
                            str += " " + Convert.ToString(can->Data[5], 16);
                        if (j++ < len)
                            str += " " + Convert.ToString(can->Data[6], 16);
                        if (j++ < len)
                            str += " " + Convert.ToString(can->Data[7], 16);
                    }
                }

                lb_Info.Items.Add(str);
                lb_Info.SelectedIndex = lb_Info.Items.Count - 1;
            }

        }

        private void button_StartCAN_Click(object sender, EventArgs e)
        {
            if (!isOpen)
                return;
            VCI_StartCAN(deviceType, deviceId, canId);
        }

        private void button_StopCAN_Click(object sender, EventArgs e)
        {
            if (!isOpen)
                return;
            VCI_ResetCAN(deviceType, deviceId, canId);
        }

        private byte ConvertHexStringToByte(string s, int i)
        {
            return Convert.ToByte("0x" + s.Substring(i * 3, 2), 16);
        }

        unsafe private void button_Send_Click(object sender, EventArgs e)
        {
            if (!isOpen)
                return;

            CAN cAN = new CAN();
            cAN.IsRemote = (byte)cbo_FrameFormat.SelectedIndex;
            cAN.IsExtern = (byte)cbo_FrameType.SelectedIndex;
            cAN.ID = Convert.ToUInt32("0x" + txt_ID.Text, 16);
            int len = (txt_Data.Text.Length + 1) / 3;
            cAN.DataLength = Convert.ToByte(len);
            String strdata = txt_Data.Text;
            int i = -1;
            if (i++ < len - 1)
                cAN.Data[0] = this.ConvertHexStringToByte(strdata, i);
            if (i++ < len - 1)
                cAN.Data[1] = this.ConvertHexStringToByte(strdata, i);
            if (i++ < len - 1)
                cAN.Data[2] = this.ConvertHexStringToByte(strdata, i);
            if (i++ < len - 1)
                cAN.Data[3] = this.ConvertHexStringToByte(strdata, i);
            if (i++ < len - 1)
                cAN.Data[4] = this.ConvertHexStringToByte(strdata, i);
            if (i++ < len - 1)
                cAN.Data[5] = this.ConvertHexStringToByte(strdata, i);
            if (i++ < len - 1)
                cAN.Data[6] = this.ConvertHexStringToByte(strdata, i);
            if (i++ < len - 1)
                cAN.Data[7] = this.ConvertHexStringToByte(strdata, i);

            if (VCI_Transmit(deviceType, deviceId, canId, ref cAN, 1) == 0)
            {
                MessageBox.Show("发送失败", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            lb_Info.Items.Clear();
        }

    }
}