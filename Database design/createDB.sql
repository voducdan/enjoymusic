if exists (select name from sys.databases where name='EnjoyMusicDB') drop database EnjoyMusicDB

create database EnjoyMusicDB

use EnjoyMusicDB

create table Listener (
	id int identity(1,1),
	username varchar(30),
	pass nvarchar(30),
	user_role varchar(10),
	avt varchar(50),
	create_at datetime
	primary key (id)
);

create table Category (
	id int identity(1,1),
	name nvarchar(100),
	url varchar(100)
	primary key (id)
)

create table Song (
	id int identity,
	name nvarchar(100),
	singer nvarchar(50),
	composer nvarchar(50),
	category int,
	listen int,
	download int,
	publish_year int,
	avt varchar(100),
	lyric nvarchar(1000),
	url varchar(100),
	path varchar(100)
	primary key (id)
)
alter table Song alter column lyric nvarchar(3000)
create table List (
	id int identity,
	listener int,
	name nvarchar(100)
	primary key (id)
)

create table SongList (
	listid int,
	songid int
	primary key (listid, songid)
)

create table Comment (
	id int identity,
	listener int,
	song int,
	content nvarchar(1000),
	create_at datetime
	primary key (id)
)

alter table Comment add  rate int

create table Favourite (
	id int,
	listener int,
	song int
	primary key (id)
)

use EnjoyMusicDB

alter table Favourite add constraint FK_Listener_Favourite foreign key(listener) references Listener(id)
alter table Favourite add constraint FK_Song_Favourite foreign key(song) references Song(id)
alter table List add constraint FK_Listener_List foreign key(listener) references Listener(id)
alter table SongList add constraint FK_List_SongList foreign key(listid) references List(id)
alter table SongList add constraint FK_Song_SongList foreign key(songid) references Song(id)
alter table Song add constraint FK_Category_Song foreign key(category) references Category(id)
alter table Comment add constraint FK_Song_Comment foreign key(song) references Song(id)
alter table Comment add constraint FK_Listener_Comment foreign key(listener) references Listener(id)

