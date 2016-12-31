use yp
go
if object_id('vw_play', 'V') is not null
	drop view vw_play
go

create view vw_play
as
select p.*
,h.name as HallName
,h.layoutId
,l.style as layoutStyle
,m.id as movieId
,m.name as movieName
,m.duration as movieDuration
,m.movieTypeId
,mt.Name as movieTypeName
,s.id as scheduleId
,s.name as scheduleName
,s.beginDate as scheduleBeginDate
,s.duration as scheduleDuration
from play as p
inner join hall as h on p.hallId=h.id
inner join layout as l on l.id = h.layoutId
inner join movieSchedule as ms on p.movieScheduleId=ms.id
inner join movie as m on ms.movieId=m.id
inner join movieType as mt on mt.id = m.movieTypeId
inner join schedule as s  on ms.scheduleId=s.id
go
select * from vw_play