USE [master]
GO
/****** Object:  Database [CheHang]    Script Date: 2017-5-13 19:26:11 ******/
CREATE DATABASE [CheHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CheHang', FILENAME = N'C:\DB\CheHang.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CheHang_log', FILENAME = N'C:\DB\CheHang_log.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CheHang] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CheHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CheHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CheHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CheHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CheHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CheHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [CheHang] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CheHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CheHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CheHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CheHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CheHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CheHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CheHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CheHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CheHang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CheHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CheHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CheHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CheHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CheHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CheHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CheHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CheHang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CheHang] SET  MULTI_USER 
GO
ALTER DATABASE [CheHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CheHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CheHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CheHang] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CheHang]
GO
/****** Object:  Table [dbo].[TB_Admin]    Script Date: 2017-5-13 19:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](10) NULL,
	[PWD] [nchar](10) NULL,
	[QX] [nchar](10) NULL,
 CONSTRAINT [PK_TB_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_CheLiang]    Script Date: 2017-5-13 19:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CheLiang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ChePai] [nvarchar](50) NULL,
	[PingPai] [nvarchar](50) NULL,
	[ZuJIn] [float] NULL,
	[YaSe] [nvarchar](50) NULL,
	[Memo] [nvarchar](50) NULL,
	[LeiXing] [nvarchar](50) NULL,
	[PIC] [ntext] NULL,
 CONSTRAINT [PK_TB_CheLiang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_Employee]    Script Date: 2017-5-13 19:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](10) NULL,
	[PWD] [nchar](10) NULL,
	[QX] [nchar](10) NULL,
 CONSTRAINT [PK_TB_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_JieYue]    Script Date: 2017-5-13 19:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_JieYue](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ChePai] [nvarchar](50) NULL,
	[PingPai] [nvarchar](50) NULL,
	[ZuJIn] [float] NULL,
	[YaSe] [nvarchar](50) NULL,
	[Memo] [nvarchar](50) NULL,
	[LeiXing] [nvarchar](50) NULL,
	[PIC] [ntext] NULL,
	[UserName] [nvarchar](50) NULL,
	[XingMing] [nvarchar](50) NULL,
	[StartTime] [datetime] NULL CONSTRAINT [DF_TB_JieYue_StartTime]  DEFAULT (getdate()),
	[EndTime] [datetime] NULL,
	[JinE] [float] NULL,
	[State] [nchar](10) NULL,
 CONSTRAINT [PK_TB_JieYue] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_LeiXing]    Script Date: 2017-5-13 19:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_LeiXing](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LeiXing] [nvarchar](50) NULL,
 CONSTRAINT [PK_TB_LeiXing] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_User]    Script Date: 2017-5-13 19:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[PWD] [nvarchar](50) NULL,
	[XingMing] [nvarchar](50) NULL,
	[Sex] [nchar](10) NULL,
	[tel] [nvarchar](50) NULL,
	[IDCard] [nvarchar](50) NULL,
 CONSTRAINT [PK_TB_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[view_chart_cartype]    Script Date: 2017-5-13 19:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_chart_cartype]
AS
SELECT ID, LeiXing AS x, StartTime AS st, EndTime AS et, JinE AS t
FROM   dbo.TB_JieYue

GO
/****** Object:  View [dbo].[view_chart_sex]    Script Date: 2017-5-13 19:26:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_chart_sex]
AS
SELECT j.ID, u.Sex AS x, j.StartTime AS st, j.EndTime AS et
FROM   dbo.TB_JieYue AS j LEFT OUTER JOIN
             dbo.TB_User AS u ON u.UserName = j.UserName

GO
SET IDENTITY_INSERT [dbo].[TB_Admin] ON 

INSERT [dbo].[TB_Admin] ([ID], [UserName], [PWD], [QX]) VALUES (1, N'admin     ', N'admin     ', N'管理员       ')
SET IDENTITY_INSERT [dbo].[TB_Admin] OFF
SET IDENTITY_INSERT [dbo].[TB_CheLiang] ON 

INSERT [dbo].[TB_CheLiang] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC]) VALUES (10, N'浙A12345', N'法拉利', 500, N'红色', N'红色闪电', N'跑车', N'\Image\131363538575632420.jpg')
INSERT [dbo].[TB_CheLiang] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC]) VALUES (11, N'苏A12345', N'瑞虎', 200, N'棕色', N'经典SUV', N'SUV', N'\Image\131363539075774415.jpg')
INSERT [dbo].[TB_CheLiang] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC]) VALUES (12, N'京A12345', N'起亚', 150, N'白色', N'外形炫酷', N'轿车', N'\Image\131363542946243685.jpg')
INSERT [dbo].[TB_CheLiang] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC]) VALUES (13, N'津A12345', N'福特', 100, N'黑色', N'容量超大', N'皮卡', N'\Image\131363548820545938.jpg')
INSERT [dbo].[TB_CheLiang] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC]) VALUES (14, N'沪A12345', N'长安', 50, N'银色', N'运货方便', N'面包车', N'\Image\131363556910250160.jpg')
SET IDENTITY_INSERT [dbo].[TB_CheLiang] OFF
SET IDENTITY_INSERT [dbo].[TB_Employee] ON 

INSERT [dbo].[TB_Employee] ([ID], [UserName], [PWD], [QX]) VALUES (1, N'123       ', N'123       ', N'工作人员      ')
INSERT [dbo].[TB_Employee] ([ID], [UserName], [PWD], [QX]) VALUES (4, N'e         ', N'e         ', N'工作人员      ')
INSERT [dbo].[TB_Employee] ([ID], [UserName], [PWD], [QX]) VALUES (6, N'e         ', N'e         ', N'工作人员      ')
SET IDENTITY_INSERT [dbo].[TB_Employee] OFF
SET IDENTITY_INSERT [dbo].[TB_JieYue] ON 

INSERT [dbo].[TB_JieYue] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC], [UserName], [XingMing], [StartTime], [EndTime], [JinE], [State]) VALUES (7, N'京A12345', N'起亚', 150, N'白色', N'外形炫酷', N'轿车', NULL, N'0001', N'张亮', CAST(N'2017-04-07 16:08:00.427' AS DateTime), CAST(N'2017-04-07 16:08:06.000' AS DateTime), 150, N'已归还       ')
INSERT [dbo].[TB_JieYue] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC], [UserName], [XingMing], [StartTime], [EndTime], [JinE], [State]) VALUES (8, N'苏A12345', N'瑞虎', 200, N'棕色', N'经典SUV', N'轿车', NULL, N'0001', N'张亮', CAST(N'2017-04-07 16:08:12.303' AS DateTime), CAST(N'2017-04-07 16:08:18.000' AS DateTime), 200, N'已归还       ')
INSERT [dbo].[TB_JieYue] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC], [UserName], [XingMing], [StartTime], [EndTime], [JinE], [State]) VALUES (9, N'苏A12345', N'瑞虎', 200, N'棕色', N'经典SUV', N'轿车', NULL, N'0001', N'张亮', CAST(N'2017-04-07 16:08:42.687' AS DateTime), CAST(N'2017-04-07 16:08:54.000' AS DateTime), 200, N'已归还       ')
INSERT [dbo].[TB_JieYue] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC], [UserName], [XingMing], [StartTime], [EndTime], [JinE], [State]) VALUES (12, N'浙A12345', N'法拉利', 500, N'红色', N'红色闪电', N'跑车', NULL, N'0002', N'王芳', CAST(N'2017-04-08 09:20:58.450' AS DateTime), CAST(N'2017-04-08 09:21:08.000' AS DateTime), 500, N'已归还       ')
INSERT [dbo].[TB_JieYue] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC], [UserName], [XingMing], [StartTime], [EndTime], [JinE], [State]) VALUES (13, N'浙A12345', N'法拉利', 500, N'红色', N'红色闪电', N'跑车', NULL, N'0003', N'方哲', CAST(N'2017-04-08 09:22:43.747' AS DateTime), CAST(N'2017-04-08 09:22:50.000' AS DateTime), 500, N'已归还       ')
INSERT [dbo].[TB_JieYue] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC], [UserName], [XingMing], [StartTime], [EndTime], [JinE], [State]) VALUES (14, N'京A12345', N'起亚', 150, N'白色', N'外形炫酷', N'轿车', NULL, N'0002', N'王芳', CAST(N'2017-04-27 13:57:46.700' AS DateTime), CAST(N'2017-04-27 14:17:34.000' AS DateTime), 150, N'已归还       ')
INSERT [dbo].[TB_JieYue] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC], [UserName], [XingMing], [StartTime], [EndTime], [JinE], [State]) VALUES (15, N'苏A12345', N'瑞虎', 200, N'棕色', N'经典SUV', N'SUV', NULL, N'0003', N'方哲', CAST(N'2017-04-27 13:58:08.110' AS DateTime), CAST(N'2017-04-27 14:18:28.000' AS DateTime), 200, N'已归还       ')
INSERT [dbo].[TB_JieYue] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC], [UserName], [XingMing], [StartTime], [EndTime], [JinE], [State]) VALUES (16, N'沪A12345', N'长安', 50, N'银色', N'运货方便', N'面包车', NULL, N'0001', N'张亮', CAST(N'2017-04-27 14:00:12.807' AS DateTime), CAST(N'2017-04-27 14:00:19.000' AS DateTime), 50, N'已归还       ')
INSERT [dbo].[TB_JieYue] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC], [UserName], [XingMing], [StartTime], [EndTime], [JinE], [State]) VALUES (17, N'津A12345', N'福特', 100, N'黑色', N'容量超大', N'皮卡', NULL, N'0001', N'张亮', CAST(N'2017-05-12 18:44:31.080' AS DateTime), CAST(N'2017-05-12 18:44:43.000' AS DateTime), 100, N'已归还       ')
INSERT [dbo].[TB_JieYue] ([ID], [ChePai], [PingPai], [ZuJIn], [YaSe], [Memo], [LeiXing], [PIC], [UserName], [XingMing], [StartTime], [EndTime], [JinE], [State]) VALUES (18, N'京A12345', N'起亚', 150, N'白色', N'外形炫酷', N'轿车', NULL, N'0003', N'方哲', CAST(N'2017-05-12 18:45:22.733' AS DateTime), CAST(N'2017-05-12 18:45:54.000' AS DateTime), 150, N'已归还       ')
SET IDENTITY_INSERT [dbo].[TB_JieYue] OFF
SET IDENTITY_INSERT [dbo].[TB_LeiXing] ON 

INSERT [dbo].[TB_LeiXing] ([ID], [LeiXing]) VALUES (1, N'轿车')
INSERT [dbo].[TB_LeiXing] ([ID], [LeiXing]) VALUES (2, N'SUV')
INSERT [dbo].[TB_LeiXing] ([ID], [LeiXing]) VALUES (3, N'跑车')
INSERT [dbo].[TB_LeiXing] ([ID], [LeiXing]) VALUES (6, N'皮卡')
INSERT [dbo].[TB_LeiXing] ([ID], [LeiXing]) VALUES (7, N'面包车')
SET IDENTITY_INSERT [dbo].[TB_LeiXing] OFF
SET IDENTITY_INSERT [dbo].[TB_User] ON 

INSERT [dbo].[TB_User] ([ID], [UserName], [PWD], [XingMing], [Sex], [tel], [IDCard]) VALUES (3, N'0001', N'0001', N'张亮', N'男         ', N'15176086969', N'522635197608189322')
INSERT [dbo].[TB_User] ([ID], [UserName], [PWD], [XingMing], [Sex], [tel], [IDCard]) VALUES (4, N'0002', N'0002', N'王芳', N'女         ', N'15730198430', N'321324187502153220')
INSERT [dbo].[TB_User] ([ID], [UserName], [PWD], [XingMing], [Sex], [tel], [IDCard]) VALUES (5, N'0003', N'0003', N'方哲', N'男         ', N'18640381596', N'324423198503256410')
SET IDENTITY_INSERT [dbo].[TB_User] OFF
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TB_JieYue"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 285
               Right = 335
            End
            DisplayFlags = 280
            TopColumn = 7
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_chart_cartype'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_chart_cartype'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "j"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 206
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "u"
            Begin Extent = 
               Top = 9
               Left = 336
               Bottom = 206
               Right = 558
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_chart_sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_chart_sex'
GO
USE [master]
GO
ALTER DATABASE [CheHang] SET  READ_WRITE 
GO
