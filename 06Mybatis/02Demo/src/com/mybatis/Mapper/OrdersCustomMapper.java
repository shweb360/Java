package com.mybatis.Mapper;

import java.util.List;

import com.mybatis.entity.*;


public interface OrdersCustomMapper {
    /** ��ѯ������������ѯ�û���Ϣ */
    public List<OrdersCustom> findOrdersUser();
	/** ��ѯ����������ѯ�û���Ϣ��ʹ��reslutMapʵ��*/
	public List<Orders>findOrdersUserResultMap();
}
