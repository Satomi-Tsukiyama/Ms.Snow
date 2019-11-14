use sysnozawa;
create table sysnozawa.item(
	id integer primary key,
	code1 varchar(10),
	code2 varchar(10), 
	name varchar(20),
	kata varchar(20),
	maker varchar(20),
	unit varchar(10),
    quantity integer,
    insertdatetime timestamp,
    updatedatetime timestamp);

alter table item add unique code_unique(code1,code2);
alter table calendar modify column day date not null;
alter table item modify column name varchar(20) not null;
alter table item modify column kata varchar(20) not null;
alter table item modify column unit varchar(10) not null;

-- select * from item;