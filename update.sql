use sysnozawa;

create table itemamount(
	id integer primary key,
    itemid integer,
    shopid integer,
    amount decimal,
    note varchar(50),
    insertdatetime timestamp,
    updatedatetime timestamp);

alter table itemamount add foreign key(shopid) references shop(id);
alter table itemamount add foreign key(itemid) references item(id);
-- create view salesplan as select ~