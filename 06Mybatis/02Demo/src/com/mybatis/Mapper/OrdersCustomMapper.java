package com.mybatis.Mapper;

import java.util.List;

import com.mybatis.entity.*;


public interface OrdersCustomMapper {
    /** ��ѯ������������ѯ�û���Ϣ */
    public List<OrdersCustom> findOrdersUser();
	/** ��ѯ����������ѯ�û���Ϣ��ʹ��reslutMapʵ�� (һ��һ��ѯ)*/
	public List<Orders> findOrdersUserResultMap();
	/**��ѯ�����������û����Լ�������ϸ (һ�Զ��ѯ)*/
    public List<Orders> findOrdersAndOrderDetailResultMap();    
    /** ��ѯ�û����û����������Ʒ��Ϣ (��Զ��ѯ)*/
    public List<User> findUserAndItemsResultMap();
}
