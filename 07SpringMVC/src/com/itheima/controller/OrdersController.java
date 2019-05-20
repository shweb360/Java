package com.itheima.controller;

import com.itheima.po.User;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

import com.itheima.po.Orders;

@Controller
public class OrdersController {

	/**
	 * �򶩵���ѯҳ����ת
	 */
	@RequestMapping("/tofindOrdersWithUser")
	public String tofindOrdersWithUser()
	{
		return "orders";
	}
	/**
	 * ��ѯ�������û���Ϣ
	 */
	@RequestMapping("/findOrdersWithUser")
	public String findOrdersWithUser(Orders orders)
	{
      Integer orderId=orders.getOrdersId();
      User user=(User) orders.getUser();
      String username=user.getUsername();
      System.out.println("orderId="+orderId);
      System.out.println("username="+username);
		return "success";
	}
	
	
}
