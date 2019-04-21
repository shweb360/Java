package com.mybatis.Mapper;

import java.util.List;

import com.mybatis.entity.*;


public interface OrdersCustomMapper {
    /** 查询订单，关联查询用户信息 */
    public List<OrdersCustom> findOrdersUser();
	/** 查询订单关联查询用户信息，使用reslutMap实现*/
	public List<Orders>findOrdersUserResultMap();
}
