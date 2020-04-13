use EnjoyMusicDB


go
CREATE FUNCTION ufn_removeMark (@text nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
	SET @text = LOWER(@text)
	DECLARE @textLen int = LEN(@text)
	IF @textLen > 0
	BEGIN
		DECLARE @index int = 1
		DECLARE @lPos int
		DECLARE @SIGN_CHARS nvarchar(100) = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýđð'
		DECLARE @UNSIGN_CHARS varchar(100) = 'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyydd'

		WHILE @index <= @textLen
		BEGIN
			SET @lPos = CHARINDEX(SUBSTRING(@text,@index,1),@SIGN_CHARS)
			IF @lPos > 0
			BEGIN
				SET @text = STUFF(@text,@index,1,SUBSTRING(@UNSIGN_CHARS,@lPos,1))
			END
			SET @index = @index + 1
		END
	END
	RETURN @text
END

go
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

go
create or alter proc sp_topDownload
as 
	select top 10 s.id, s.name, s.avt, s.singer,s.url, s.listen
	from Song s
	order by s.download desc

go
create or alter proc sp_topRate
as 
	select top 10 s.id, s.name, s.avt, s.singer,s.url, s.listen
	from Song s, Comment c
	where c.song = s.id
	order by c.rate desc

go
create or alter proc sp_newComment
as 
	select top 10 s.id, s.name, s.avt, s.singer,s.url, s.listen
	from Song s, Comment c
	where c.song = s.id
	order by c.id desc
go
create or alter proc sp_GetSongByCategory
	@category varchar(100)
as
	select s.id, s.name, s.avt, s.singer,s.url, s.listen, s.category
	from Song s, Category c
	where s.category = c.id and c.url = @category

go
create or alter proc sp_GetBySinger
	@singer nvarchar(50)
as
	select top 10 s.id, s.name, s.avt, s.singer,s.url, s.listen
	from Song s
	where dbo.ufn_removeMark(s.singer) like '%'+dbo.ufn_removeMark(@singer)+'%' 
go
create or alter proc sp_getByComposer
	@composer nvarchar(50)
as
	select top 10 s.id, s.name, s.avt, s.singer,s.url, s.listen
	from Song s
	where dbo.ufn_removeMark(s.singer) like '%'+dbo.ufn_removeMark(@composer)+'%' 

go
create or alter proc sp_searchByName
	@key nvarchar(50)
as
	select s.id, s.name, s.avt, s.singer,s.url, s.listen
	from Song s
	where dbo.ufn_removeMark(s.name) like '%'+dbo.ufn_removeMark(@key)+'%' 
			