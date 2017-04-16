USE [master]
GO

/****** Object:  Database [WareHouse]    Script Date: 2017-4-16 21:41:10 ******/
CREATE DATABASE [WareHouse]

GO

use [WareHouse]
GO

CREATE TABLE Material(
	[Name] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 0) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY
)

CREATE TABLE InOut(
	[MID] [int] NOT NULL,
	[IsIn] [bit] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Date] [datetime] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY)

	ALTER TABLE [dbo].[InOut]  WITH CHECK ADD  CONSTRAINT [FK_InOut_Material] FOREIGN KEY([MID])
REFERENCES [dbo].[Material] ([ID])
GO
