-- 此代码可以用于在数据库内禁用更改跟踪
-- 请确保在执行此代码之前所有表都已停止使用更改跟踪
    
IF EXISTS (SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID(N'ceshi')) 
  ALTER DATABASE [ceshi] 
  SET  CHANGE_TRACKING = OFF
GO
