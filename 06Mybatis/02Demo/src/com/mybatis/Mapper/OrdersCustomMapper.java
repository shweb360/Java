package com.mybatis.Mapper;

import java.util.List;

import com.mybatis.entity.*;


public interface OrdersCustomMapper {
    /** 查询订单，关联查询用户信息 */
    public List<OrdersCustom> findOrdersUser();
	/** 查询订单关联查询用户信息，使用reslutMap实现 (一对一查询)*/
	public List<Orders> findOrdersUserResultMap();
	/**查询订单（关联用户）以及订单明细 (一对多查询)*/
    public List<Orders> findOrdersAndOrderDetailResultMap();    
    /** 查询用户及用户所购买的商品信息 (多对多查询)*/
    public List<User> findUserAndItemsResultMap();
}
