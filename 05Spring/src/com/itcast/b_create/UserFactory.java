package com.itcast.b_create;

import com.itcast.Bean.User;

public class UserFactory {

	public static User createUser() {
		
		System.out.println("对象创建方式2：静态工厂");
		return new User();
	}
	
	public  User createUser2() {
		
		System.out.println("对象创建方式3：实例工厂");
		return new User();
	}
}
