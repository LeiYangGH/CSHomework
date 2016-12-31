use yp
go

if OBJECT_ID('vw_position','V') is not null
	drop view vw_position
go

create view vw_position
as
select p.*
,pt.name as positionTypeName
,l.style as layoutStyle
from position as p
inner join layout as l on p.layoutId=l.id
inner join positionType pt on p.positionTypeId=pt.id
go
select * from vw_position