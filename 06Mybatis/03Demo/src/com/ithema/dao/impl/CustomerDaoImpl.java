package com.ithema.dao.impl;

import org.mybatis.spring.support.SqlSessionDaoSupport;

import com.ithema.dao.CustomerDao;

import com.ithema.pro.Customer;

/**
 * @author wushuang
 *Dao接口实现类需要注入SqlSessionFactory，通过spring进行注入。
 *这里spring声明配置方式，配置dao的bean：
 *让CustomerDaoImpl实现类继承SqlSessionDaoSupport
 */
public class CustomerDaoImpl extends SqlSessionDaoSupport implements CustomerDao {

	public Customer findCustomerById(Integer id) {
		return this.getSqlSession().selectOne("com.ithema.mapper.CustomerMapper.findCustomerById",id);
	}
}
