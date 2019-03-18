package com.itcast.b_create;

import org.junit.Test;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.itcast.Bean.User;

public class Demo {

	@Test
	public void fun1() {
		
		//创建容器对象
		ApplicationContext ac=new ClassPathXmlApplicationContext("com/itcast/b_create/applicationContext.xml");
		
		//向容器要user对象；
		User user = (User)ac.getBean("user"); 
		User user2 = (User)ac.getBean("user"); 
		
		//打印user对象；
		System.out.println(user==user2);
	}
	@Test
	public void fun2() {		
		//创建容器对象
		ApplicationContext ac=new ClassPathXmlApplicationContext("com/itcast/b_create/applicationContext.xml");
		//向容器要user对象；
		User user = (User)ac.getBean("user2"); 
		//打印user对象；
		System.out.println(user);
	}
	@Test
	public void fun3() {
		
		//创建容器对象
		ApplicationContext ac=new ClassPathXmlApplicationContext("com/itcast/b_create/applicationContext.xml");
		
		//向容器要user对象；
		User user = (User)ac.getBean("user3"); 
		//打印user对象；
		System.out.println(user);
	}
}
