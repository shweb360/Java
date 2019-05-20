package com.itheima.controller;

import com.itheima.po.User;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

import com.itheima.po.Orders;

@Controller
public class OrdersController {

	/**
	 * 向订单查询页面跳转
	 */
	@RequestMapping("/tofindOrdersWithUser")
	public String tofindOrdersWithUser()
	{
		return "orders";
	}
	/**
	 * 查询订单和用户信息
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
