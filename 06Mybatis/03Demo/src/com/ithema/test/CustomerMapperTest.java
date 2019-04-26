package com.ithema.test;

import org.junit.Before;
import org.junit.Test;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.ithema.dao.CustomerDao;
import com.ithema.mapper.CustomerMapper;
import com.ithema.pro.Customer;

/**
 * Mapper接口开发（和spring整合后）
 * @author wushuang
 *
 */
public class CustomerMapperTest {
	private ApplicationContext applicationContext;
	@Before
	public void setUp() throws Exception {

		applicationContext = new ClassPathXmlApplicationContext("applicationContext.xml");
	}

	@Test
	public void findCustomerByIdMapperTest() {

		//CustomerMapper cd = (CustomerMapper) applicationContext.getBean(CustomerMapper.class);
		CustomerMapper cd = (CustomerMapper) applicationContext.getBean("customerMapper");
		Customer ct = cd.findCustomerById(1);
		System.out.println(ct);
	}
}
