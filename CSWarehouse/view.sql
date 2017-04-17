USE [WareHouse]
GO

CREATE VIEW [dbo].[VIn]
AS
SELECT  dbo.Material.Name, dbo.Material.Price, dbo.InOut.Quantity, dbo.InOut.Date
FROM     dbo.InOut INNER JOIN
               dbo.Material ON dbo.InOut.MID = dbo.Material.ID
WHERE   (dbo.InOut.IsIn = 1)

GO


CREATE VIEW [dbo].[VOut]
AS
SELECT  dbo.Material.Name, dbo.Material.Price, dbo.InOut.Quantity, dbo.InOut.Date
FROM     dbo.InOut INNER JOIN
               dbo.Material ON dbo.InOut.MID = dbo.Material.ID
WHERE   (dbo.InOut.IsIn = 0)

GO