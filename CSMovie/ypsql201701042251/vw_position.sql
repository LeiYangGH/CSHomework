USE [yp]
GO

/****** Object:  View [dbo].[vw_position]    Script Date: 2017-1-4 22:50:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vw_position]
AS
SELECT p.id AS positionId, p.rowNum, p.colNum, p.positionTypeId, pt.name AS positionTypeName, p.layoutId, l.style AS layoutStyle, p.useAble
FROM   dbo.position AS p INNER JOIN
             dbo.layout AS l ON p.layoutId = l.id INNER JOIN
             dbo.positionType AS pt ON p.positionTypeId = pt.id

GO

