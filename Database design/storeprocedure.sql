use EnjoyMusicDB

create or alter proc sp_getAll
as 
	select top 12 s.id, s.name, s.avt, s.singer,s.url, s.listen
	from Song s
	order by s.id desc

go
create or alter proc sp_getById
	@id int
as
	select * 
	from Song
	where Song.id = @id

go
create or alter proc sp_getAllCategory
as
	select * from Category

go
create or alter proc sp_topListen
as 
	select top 10 s.id, s.name, s.avt, s.singer,s.url, s.listen
	from Song s
	order by s.listen desc
