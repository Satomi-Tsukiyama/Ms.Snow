use sysnozawa;

create table softdesign(
	id integer primary key,
    ankenid integer,
    staffid integer,
    manhours decimal,
    insertdatetime timestamp,
    updatedatetime timestamp);

alter table softdesign add foreign key(ankenid) references anken(id);
alter table softdesign add foreign key(staffid) references staff(id);
alter table softdesign add constraint unique(id,ankenid);