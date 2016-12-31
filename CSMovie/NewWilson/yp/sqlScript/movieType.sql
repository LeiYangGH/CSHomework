use [yp]
go

if object_id('vw_movieType', 'V') is not null
	drop view vw_movieType
go

create view vw_movieType
as
select h.id as leiId
,h.name
 ,l.id as hallId
,l.name as hallName
,l.movieTypeId as hallTypeId
,l.duration as hallduration
,l.poster as halldposter
from movieType as h
inner join movie as l on h.id=l.movieTypeId
go

select * from vw_movieType