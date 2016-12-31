use yp
go
if object_id('vw_movieSchedule', 'V') is not null
	drop view vw_movieSchedule
go

create view vw_movieSchedule
as
select ms.*
,m.name as movieName
,m.duration as movieDuration
,m.movieTypeId
,mt.Name as movieTypeName
,s.name as scheduleName
,s.beginDate as scheduleBeginDate
,s.duration as scheduleDuration
from movieSchedule as ms
inner join movie as m on ms.movieId=m.id
inner join movieType as mt on mt.id = m.movieTypeId
inner join schedule as s  on ms.scheduleId=s.id
go
select * from vw_movieSchedule