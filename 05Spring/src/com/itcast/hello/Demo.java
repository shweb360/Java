package com.itcast.hello;

import org.junit.Test;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.itcast.Bean.User;

public class Demo {

	@Test
	public void fun1() {
		
		//������������
		ApplicationContext ac=new ClassPathXmlApplicationContext("applicationContext.xml");
		
		//������Ҫuser����
		User user = (User)ac.getBean("user"); 
		//��ӡuser����
		System.out.println(user);
	}
}
