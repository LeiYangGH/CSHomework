use [yp]
go

if object_id('vw_originPrice', 'V') is not null
	drop view vw_originPrice
go

create view vw_originPrice
as
select o.*
,pt.name as priceTempletName
,pt.price as priceTempletValue
,post.name as positionTypeName
from originPrice as o
inner join priceTemplet as pt on pt.id=o.priceTempletId
inner join positionType as post on post.id = o.positionTypeId
go

select * from vw_originPrice