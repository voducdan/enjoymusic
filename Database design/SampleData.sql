use EnjoyMusicDB

insert into Category (name,url) values (N'Nhạc trẻ','nhac-tre')

insert into Song (name,singer,composer,category,listen,download,publish_year,avt,lyric,url,path)
values (N'Gửi anh xa nhớ', N'Bích Phương',N'Tiên Cookie',1,0,0,2016,'','','gui-anh-xa-nho','')

select * from Category
select * from Song