package com.itcast.b_create;

import org.junit.Test;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.itcast.Bean.User;

public class Demo {

	@Test
	public void fun1() {
		
		//������������
		ApplicationContext ac=new ClassPathXmlApplicationContext("com/itcast/b_create/applicationContext.xml");
		
		//������Ҫuser����
		User user = (User)ac.getBean("user"); 
		User user2 = (User)ac.getBean("user"); 
		
		//��ӡuser����
		System.out.println(user==user2);
	}
	@Test
	public void fun2() {		
		//������������
		ApplicationContext ac=new ClassPathXmlApplicationContext("com/itcast/b_create/applicationContext.xml");
		//������Ҫuser����
		User user = (User)ac.getBean("user2"); 
		//��ӡuser����
		System.out.println(user);
	}
	@Test
	public void fun3() {
		
		//������������
		ApplicationContext ac=new ClassPathXmlApplicationContext("com/itcast/b_create/applicationContext.xml");
		
		//������Ҫuser����
		User user = (User)ac.getBean("user3"); 
		//��ӡuser����
		System.out.println(user);
	}
}
