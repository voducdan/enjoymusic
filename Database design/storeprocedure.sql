create or alter proc sp_getAll
as 
	select s.id, s.name, s.avt, s.singer,s.url
	from Song s

go
create or alter proc sp_getById
	@id int
as
	select * 
	from Song
	where Song.id = @id