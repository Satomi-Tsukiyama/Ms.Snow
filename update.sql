use sysnozawa;
alter table item add code3 varchar(10) after code2;
alter table item drop index code_unique;
alter table item add unique code_unique(code1,code2,code3);