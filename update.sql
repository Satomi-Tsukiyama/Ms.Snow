use sysnozawa;

alter table anken drop index code_unique; 
alter table anken add constraint unique(code1,code2,code3,name);

alter table item add quantityunit varchar(10) after quantity;