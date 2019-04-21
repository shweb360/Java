CREATE TABLE items (
  id INT NOT NULL  AUTO_INCREMENT,
  itemsname VARCHAR(32) NOT NULL COMMENT '��Ʒ����',
  price FLOAT(10,1) NOT NULL COMMENT '��Ʒ����',
  detail TEXT COMMENT '��Ʒ����',
  pic VARCHAR(64) DEFAULT NULL COMMENT '��ƷͼƬ',
  createtime DATETIME NOT NULL COMMENT '��������',
  PRIMARY KEY (id)
)  DEFAULT CHARSET=utf8;

/*Table structure for table `orderdetail` */

CREATE TABLE orderdetail (
  id INT NOT NULL AUTO_INCREMENT,
 orders_id INT NOT NULL COMMENT '����id',
  items_id INT NOT NULL COMMENT '��Ʒid',
  items_num INT  DEFAULT NULL COMMENT '��Ʒ��������',
  PRIMARY KEY (id),
  KEY `FK_orderdetail_1` (`orders_id`),
  KEY `FK_orderdetail_2` (`items_id`),
  CONSTRAINT `FK_orderdetail_1` FOREIGN KEY (`orders_id`) REFERENCES `orders` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_orderdetail_2` FOREIGN KEY (`items_id`) REFERENCES `items` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
)  DEFAULT CHARSET=utf8;

/*Table structure for table `orders` */

CREATE TABLE orders (
  id INT NOT NULL AUTO_INCREMENT,
  user_id INT NOT NULL COMMENT '�µ��û�id',
  number VARCHAR(30) NOT NULL COMMENT '������',
  createtime DATETIME NOT NULL COMMENT '��������ʱ��',
  note VARCHAR(100) DEFAULT NULL COMMENT '��ע',
  PRIMARY KEY (`id`),
  KEY `FK_orders_1` (`user_id`),
  CONSTRAINT `FK_orders_id` FOREIGN KEY (`user_id`) REFERENCES `t_user` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
)  DEFAULT CHARSET=utf8;

/*Table structure for table `t_user` */

CREATE TABLE t_user (
  id INT NOT NULL AUTO_INCREMENT,
  username VARCHAR(32) NOT NULL COMMENT '�û�����',
  birthday DATE DEFAULT NULL COMMENT '����',
  sex CHAR(1) DEFAULT NULL COMMENT '�Ա�',
  address  VARCHAR(256) DEFAULT NULL COMMENT '��ַ',
  PRIMARY KEY (`id`)
) DEFAULT CHARSET=utf8;