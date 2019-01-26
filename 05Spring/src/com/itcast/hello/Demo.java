package com.itcast.hello;

import org.junit.Test;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.itcast.Bean.User;

public class Demo {

	@Test
	public void fun1() {
		
		//创建容器对象
		ApplicationContext ac=new ClassPathXmlApplicationContext("applicationContext.xml");
		
		//向容器要user对象；
		User user = (User)ac.getBean("user"); 
		//打印user对象；
		System.out.println(user);
	}
}
