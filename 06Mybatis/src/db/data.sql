/*Data for the table `items` */

INSERT  INTO items(itemsname,price,detail,pic,createtime) VALUES 
('̨ʽ��',3000.0,'�õ��������ǳ��ã�',NULL,'2015-07-07 13:28:53'),
('�ʼǱ�',6000.0,'�ʼǱ����ܺã������ã�',NULL,'2015-07-08 13:22:57'),
('����',200.0,'���Ʊ����������������ã�',NULL,'2015-07-010 13:25:02');

/*Data for the table `orderdetail` */

INSERT  INTO `orderdetail`(`orders_id`,`items_id`,`items_num`) VALUES
 (1,1,1),
 (1,2,3),
 (2,3,4),
 (3,2,3);

/*Data for the table `orders` */

INSERT  INTO `orders`(`user_id`,`number`,`createtime`,`note`) VALUES 
(1,'1000010','2015-06-04 13:22:35',NULL),
(1,'1000011','2015-07-08 13:22:41',NULL),
(2,'1000012','2015-07-17 14:13:23',NULL),
(3,'1000012','2015-07-16 18:13:23',NULL),
(4,'1000012','2015-07-15 19:13:23',NULL),
(5,'1000012','2015-07-14 17:13:23',NULL),
(6,'1000012','2015-07-13 16:13:23',NULL);

/*Data for the table `user` */

INSERT  INTO `t_user`(`username`,`birthday`,`sex`,`address`) VALUES 
('����',NULL,'2',NULL),
('����','2014-07-10','1','������'),
('��С��',NULL,'1','����֣��'),
('��С��',NULL,'1','����֣��'),
('������',NULL,'1','����֣��'),
('��С��',NULL,'1','����֣��'),
('����',NULL,NULL,NULL),
 ('СA','2015-06-27','2','����'),
('СB','2015-06-27','2','����'),
('СC','2015-06-27','1','����'),
('СD','2015-06-27','2','����');