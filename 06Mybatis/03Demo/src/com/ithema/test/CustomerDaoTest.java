package com.ithema.test;


import org.junit.Before;
import org.junit.Test;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

import com.ithema.dao.CustomerDao;
import com.ithema.pro.Customer;

/**
 * @author wushuang
 * 原始dao开发（和spring整合后）
 */
public class CustomerDaoTest {

	
	private ApplicationContext applicationContext;

	@Before
	public void setUp() throws Exception {

		applicationContext = new ClassPathXmlApplicationContext("applicationContext.xml");
	}

	@Test
	public void findCustomerByIdTest() {

		CustomerDao cd = (CustomerDao) applicationContext.getBean("customerDao");
		Customer ct = cd.findCustomerById(1);
		System.out.println(ct);
	}
}