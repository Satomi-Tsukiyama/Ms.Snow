use sysnozawa;
create table ankenorderrange (
	id integer primary key,
    ankenid integer,
    name varchar(50),
    insertdatetime timestamp,
    updatedatetime timestamp);
    
alter table ankenorderrange add foreign key(ankenid) references anken(id);

create table adjustment(
	id integer primary key,
    ankenid integer,
    staffid integer,
    fieldduration varchar(50),
    officeduration varchar(50),
    lacation varchar(50),
    note varchar(50),
    insertdatetime timestamp,
    updatedatetime timestamp);

alter table adjustment add foreign key(ankenid) references anken(id);
alter table adjustment add foreign key(staffid) references staff(id);
    