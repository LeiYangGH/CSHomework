if object_id('vw_layout', 'V') is not null
	drop view vw_layout
go

create view vw_layout
as
select l.*, refNum = (
select count(h.layoutId) from hall as h where h.layoutId = l.id
)
from layout as l
go

select * from vw_layout