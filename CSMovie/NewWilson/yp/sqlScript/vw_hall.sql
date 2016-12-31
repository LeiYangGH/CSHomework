use [yp]
go

if object_id('vw_hall', 'V') is not null
	drop view vw_hall
go

create view vw_hall
as
select h.*
,l.style as layoutStyle
from hall as h
inner join layout as l on h.layoutId=l.id
go

select * from vw_hall_layout