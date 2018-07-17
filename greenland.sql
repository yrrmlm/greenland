CREATE SCHEMA `lmgreenland` DEFAULT CHARACTER SET utf8 ;

create table gl_users(
id int(11) primary key auto_increment,
loginname varchar(20) not null default '' comment '登录名',
loginpwd varchar(20) not null default '' comment '登录密码',
pwdsalt varchar(20) not null default '' comment '盐值',
isactive int(2) not null default 0 comment '用户是否有效',
createtime datetime not null default '1900-01-01',
createby varchar(20) not null default '',
updatetime datetime not null default '1900-01-01',
updateby varchar(20) not null default ''
)