alter proc proc_movie
@typeID tinyint
as
	if not exists(SELECT * FROM movieType where id=@typeID)
	select * from vw_movie
	else
	begin
	select * from vw_movie
	where movieTypeId=@typeID	
	end
	go
	
	exec proc_movie @typeID=1