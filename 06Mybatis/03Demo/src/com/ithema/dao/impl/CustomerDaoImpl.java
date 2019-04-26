package com.ithema.dao.impl;

import org.mybatis.spring.support.SqlSessionDaoSupport;

import com.ithema.dao.CustomerDao;

import com.ithema.pro.Customer;

/**
 * @author wushuang
 *Dao�ӿ�ʵ������Ҫע��SqlSessionFactory��ͨ��spring����ע�롣
 *����spring�������÷�ʽ������dao��bean��
 *��CustomerDaoImplʵ����̳�SqlSessionDaoSupport
 */
public class CustomerDaoImpl extends SqlSessionDaoSupport implements CustomerDao {

	public Customer findCustomerById(Integer id) {
		return this.getSqlSession().selectOne("com.ithema.mapper.CustomerMapper.findCustomerById",id);
	}
}
