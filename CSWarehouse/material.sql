USE [WareHouse]
GO
SET IDENTITY_INSERT [dbo].[Material] ON 

INSERT [dbo].[Material] ([Name], [Price], [ID]) VALUES (N'轮胎', CAST(500 AS Decimal(18, 0)), 1)
INSERT [dbo].[Material] ([Name], [Price], [ID]) VALUES (N'离合器', CAST(300 AS Decimal(18, 0)), 2)
INSERT [dbo].[Material] ([Name], [Price], [ID]) VALUES (N'汽车保险杠', CAST(300 AS Decimal(18, 0)), 3)
INSERT [dbo].[Material] ([Name], [Price], [ID]) VALUES (N'冷凝器', CAST(200 AS Decimal(18, 0)), 4)
INSERT [dbo].[Material] ([Name], [Price], [ID]) VALUES (N'刹车片', CAST(150 AS Decimal(18, 0)), 5)
INSERT [dbo].[Material] ([Name], [Price], [ID]) VALUES (N'活塞环', CAST(50 AS Decimal(18, 0)), 6)
SET IDENTITY_INSERT [dbo].[Material] OFF
