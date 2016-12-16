USE [master]
GO
/****** Object:  Database [ceshi]    Script Date: 09/19/2016 22:36:42 ******/
CREATE DATABASE [ceshi] ON  PRIMARY 
( NAME = N'sydata', FILENAME = N'C:\DB\sydata.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sydata_log', FILENAME = N'C:\DB\sydata_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ceshi] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ceshi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ceshi] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ceshi] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ceshi] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ceshi] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ceshi] SET ARITHABORT OFF
GO
ALTER DATABASE [ceshi] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ceshi] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ceshi] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ceshi] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ceshi] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ceshi] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ceshi] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ceshi] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ceshi] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ceshi] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ceshi] SET  DISABLE_BROKER
GO
ALTER DATABASE [ceshi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ceshi] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ceshi] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ceshi] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ceshi] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ceshi] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ceshi] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ceshi] SET  READ_WRITE
GO
ALTER DATABASE [ceshi] SET RECOVERY FULL
GO
ALTER DATABASE [ceshi] SET  MULTI_USER
GO
ALTER DATABASE [ceshi] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ceshi] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'ceshi', N'ON'
GO
USE [ceshi]
GO
/****** Object:  Table [dbo].[userinfo]    Script Date: 09/19/2016 22:36:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[userinfo](
	[id] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[age] [int] NULL,
	[pswd] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'1', N'1', 1, N'1')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'2', N'2', 2, N'2')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'101', N'张三', 18, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'102', N'李四', 18, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'103', N'王麻子', 18, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'104', N'上官飘雪', 18, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'105', N'西门吹雪', 18, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'106', N'独孤求败', 18, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'107', N'东方不败', 18, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'108', N'西方失败', 99, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'109', N'去你大爷', 18, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'110', N'太上老君', 18, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'112', N'哎哟我去', 18, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'118', N'123123', 13123, N'123123')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'789', N'xuhui', 12, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'my101', N'猪八戒', 12, N'123456qwe')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'my102', N'1231', 12, N'7654321')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'my103', N'杀毒', 12, N'123456qwe')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'my104', N'徐大爷', 99, N'123456')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'ksdjhgkjdshgkdshg', N'dsklghsd', 21, N'kjsdhgfkjsdg')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'12123r1w56e4r6', N'1s23f1sd', 31, N'123f1d2s3f1')
INSERT [dbo].[userinfo] ([id], [name], [age], [pswd]) VALUES (N'22', N'22', 33, N'22')
/****** Object:  Table [dbo].[spzl]    Script Date: 09/19/2016 22:36:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[spzl](
	[HH] [varchar](50) NOT NULL,
	[PM] [varchar](50) NOT NULL,
	[ZJM] [varchar](50) NULL,
	[DW] [varchar](50) NOT NULL,
	[JJ] [money] NOT NULL,
	[ghs] [varchar](50) NULL,
	[llb] [varchar](50) NOT NULL,
	[gg] [varchar](50) NOT NULL,
	[tm] [varchar](50) NULL,
	[cd] [varchar](50) NULL,
	[bz] [varchar](50) NULL,
	[lsj] [money] NOT NULL,
	[spbh] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[spzl] ([HH], [PM], [ZJM], [DW], [JJ], [ghs], [llb], [gg], [tm], [cd], [bz], [lsj], [spbh]) VALUES (N'1001', N'回锅肉', N'1231', N'份', 13.0000, N'自购', N'13', N'13', N'13', N'13', N'13', 18.0000, 1)
INSERT [dbo].[spzl] ([HH], [PM], [ZJM], [DW], [JJ], [ghs], [llb], [gg], [tm], [cd], [bz], [lsj], [spbh]) VALUES (N'1002', N'红烧牛肉', N'123123', N'份', 12.0000, N'自购', N'13', N'13', N'13', N'13', N'13', 18.0000, 2)
INSERT [dbo].[spzl] ([HH], [PM], [ZJM], [DW], [JJ], [ghs], [llb], [gg], [tm], [cd], [bz], [lsj], [spbh]) VALUES (N'1010', N'麻婆豆腐', N'mpdf', N'份', 18.0000, N'18', N'个', N'', N'123456', N'18', N'18', 18.0000, 6)
INSERT [dbo].[spzl] ([HH], [PM], [ZJM], [DW], [JJ], [ghs], [llb], [gg], [tm], [cd], [bz], [lsj], [spbh]) VALUES (N'1003', N'青椒肉丝', N'2323', N'份', 16.0000, N'自购', N'13', N'13', N'13', N'13', N'213', 18.0000, 3)
INSERT [dbo].[spzl] ([HH], [PM], [ZJM], [DW], [JJ], [ghs], [llb], [gg], [tm], [cd], [bz], [lsj], [spbh]) VALUES (N'1005', N'宫爆鸡丁', N'12313', N'份', 18.0000, N'自购', N'13', N'123', N'13', N'13', N'13', 18.0000, 4)
INSERT [dbo].[spzl] ([HH], [PM], [ZJM], [DW], [JJ], [ghs], [llb], [gg], [tm], [cd], [bz], [lsj], [spbh]) VALUES (N'1009', N'红烧牛肉', N'213', N'份', 18.0000, N'自购', N'13', N'gg', N'13', N'13', N'13', 18.0000, 5)
/****** Object:  Table [dbo].[splb]    Script Date: 09/19/2016 22:36:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[splb](
	[lbid] [int] IDENTITY(10,1) NOT NULL,
	[lbmc] [varchar](50) NOT NULL,
	[guid] [int] NOT NULL,
 CONSTRAINT [PK_splb] PRIMARY KEY CLUSTERED 
(
	[lbid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[splb] ON
INSERT [dbo].[splb] ([lbid], [lbmc], [guid]) VALUES (11, N'红烧肉', 11)
INSERT [dbo].[splb] ([lbid], [lbmc], [guid]) VALUES (12, N'火锅肉', 12)
SET IDENTITY_INSERT [dbo].[splb] OFF
