use [yp]
go

if OBJECT_ID('vw_discount','V') is not null
	drop view vw_discount
go

create view vw_discount
as
select d.*
,ct.name as coustomerTypeName
,m.name as discountModeName
from discount as d
inner join customerType as ct on ct.id = d.customerTypeId
inner join discountMode as m on m.id = d.discountModeId
go

select * from vw_discount