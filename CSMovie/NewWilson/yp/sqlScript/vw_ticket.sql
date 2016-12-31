use [yp]
go

if object_id('vw_ticket', 'V') is not null
	drop view vw_ticket
go

create view vw_ticket
as
select t.*
,s.name as scheduleName
,s.id as scheduleid
,m.name as movieName
,m.id as movieId
,play.date as playDate
,play.beginTime as playBeginTime
,h.id as hallId
,h.name as hallName
,p.rowNum
,p.colNum
,pt.name as positionTypeName
,pt.id as positionTypeId
from ticket as t
inner join position as p on p.id = t.positionId
inner join positionType as pt on p.positionTypeId = pt.id
inner join customerType as ct on ct.id = t.customerTypeId
inner join play  on play.id = t.playId
inner join hall as h on h.id = play.hallId
inner join movieSchedule as ms on ms.id=play.movieScheduleId
inner join schedule as s on s.id = ms.scheduleId
inner join movie as m on m.id=ms.movieId
go

select * from vw_ticket