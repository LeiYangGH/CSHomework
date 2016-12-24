using System;
namespace YYBroadcast
{
	internal class GlobalVariable
	{
		private static string _vip = "";
		private static string _systemTime;
		private static string _userName;
		private static IntPtr _hwndMain;
		private static string _vipDate;
		private static int _huoQuPinDao = 0;
		private static string _gongGao = "";
		private static int _neiRongBianHao1 = 1;
		private static int _neiRongBianHao2 = 1;
		private static int _neiRongBianHao3 = 1;
		private static int _neiRongBianHao4 = 1;
		private static int _neiRongBianHao5 = 1;
		public static string Vip
		{
			get
			{
				return GlobalVariable._vip;
			}
			set
			{
				GlobalVariable._vip = value;
			}
		}
		public static string SystemTime
		{
			get
			{
				return GlobalVariable._systemTime;
			}
			set
			{
				GlobalVariable._systemTime = value;
			}
		}
		public static string UserName
		{
			get
			{
				return GlobalVariable._userName;
			}
			set
			{
				GlobalVariable._userName = value;
			}
		}
		public static IntPtr HwndMain
		{
			get
			{
				return GlobalVariable._hwndMain;
			}
			set
			{
				GlobalVariable._hwndMain = value;
			}
		}
		public static string VipDate
		{
			get
			{
				return GlobalVariable._vipDate;
			}
			set
			{
				GlobalVariable._vipDate = value;
			}
		}
		public static int HuoQuPinDao
		{
			get
			{
				return GlobalVariable._huoQuPinDao;
			}
			set
			{
				GlobalVariable._huoQuPinDao = value;
			}
		}
		public static string GongGao
		{
			get
			{
				return GlobalVariable._gongGao;
			}
			set
			{
				GlobalVariable._gongGao = value;
			}
		}
		public static int NeiRongBianHao1
		{
			get
			{
				return GlobalVariable._neiRongBianHao1;
			}
			set
			{
				GlobalVariable._neiRongBianHao1 = value;
			}
		}
		public static int NeiRongBianHao2
		{
			get
			{
				return GlobalVariable._neiRongBianHao2;
			}
			set
			{
				GlobalVariable._neiRongBianHao2 = value;
			}
		}
		public static int NeiRongBianHao3
		{
			get
			{
				return GlobalVariable._neiRongBianHao3;
			}
			set
			{
				GlobalVariable._neiRongBianHao3 = value;
			}
		}
		public static int NeiRongBianHao4
		{
			get
			{
				return GlobalVariable._neiRongBianHao4;
			}
			set
			{
				GlobalVariable._neiRongBianHao4 = value;
			}
		}
		public static int NeiRongBianHao5
		{
			get
			{
				return GlobalVariable._neiRongBianHao5;
			}
			set
			{
				GlobalVariable._neiRongBianHao5 = value;
			}
		}
	}
}
