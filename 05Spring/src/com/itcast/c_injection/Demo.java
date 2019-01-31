package com.itcast.c_injection;

import org.junit.Test;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.itcast.Bean.Car;
import com.itcast.Bean.User;

public class Demo {

	
	
	@Test
	public void fun() {
		
	@SuppressWarnings("resource")
	//创建容器
	ApplicationContext appContext=new ClassPathXmlApplicationContext("com/itcast/c_injection/applicationContext.xml");
	//获取car对象
	Car car=(Car)appContext.getBean("car");
	System.out.println(car);
	
	User user=(User) appContext.getBean("user");
	System.out.println(user);
	}
}
