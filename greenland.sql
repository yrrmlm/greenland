CREATE SCHEMA `lmgreenland` DEFAULT CHARACTER SET utf8 ;

create table `lmgreenland`.gl_users(
id int(11) primary key auto_increment,
loginname varchar(20) not null default '' comment '登录名',
loginpwd varchar(20) not null default '' comment '登录密码',
pwdsalt varchar(20) not null default '' comment '盐值',
isactive int(2) not null default 0 comment '用户是否有效',
createtime datetime not null default '1900-01-01',
createby varchar(20) not null default '',
updatetime datetime not null default '1900-01-01',
updateby varchar(20) not null default ''
);

CREATE TABLE `lmgreenland`.`gl_log` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `logtype` INT(2) NOT NULL DEFAULT 0 COMMENT '日志类型（Info = 0,Warning = 1, Error = 2, Debug = 3)',
  `function` VARCHAR(20) NOT NULL DEFAULT '' COMMENT '功能模块',
  `searchtext1` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '查询条件1',
  `searchtext2` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '查询条件2',
  `requestinfo` VARCHAR(1000) NOT NULL DEFAULT '' COMMENT '请求内容',
  `responseinfo` VARCHAR(1000) NOT NULL DEFAULT '' COMMENT '响应内容',
  `otherinfo` VARCHAR(1000) NOT NULL DEFAULT '' COMMENT '其他',
  `requestip` VARCHAR(25) NOT NULL DEFAULT '' COMMENT '请求ip',
  `hostip` VARCHAR(25) NOT NULL DEFAULT '' COMMENT '主机ip',
  `createtime` DATETIME NOT NULL DEFAULT '1900-01-01' COMMENT '创建时间',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COMMENT = '日志表';
