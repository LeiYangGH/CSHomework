if object_id('vw_movie', 'V') is not null
	drop view vw_movie
go

create view vw_movie
as
select o.*
,e.name as movieTypeName
from movie as o
inner join movieType as e on e.id=o.movieTypeId
go

select * from vw_movie