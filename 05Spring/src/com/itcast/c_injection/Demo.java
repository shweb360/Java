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
	//��������
	ApplicationContext appContext=new ClassPathXmlApplicationContext("com/itcast/c_injection/applicationContext.xml");
	//��ȡcar����
	Car car=(Car)appContext.getBean("car");
	System.out.println(car);
	
	User user=(User) appContext.getBean("user");
	System.out.println(user);
	}
}
