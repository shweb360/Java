package com.itcast.b_create;

import com.itcast.Bean.User;

public class UserFactory {

	public static User createUser() {
		
		System.out.println("���󴴽���ʽ2����̬����");
		return new User();
	}
	
	public  User createUser2() {
		
		System.out.println("���󴴽���ʽ3��ʵ������");
		return new User();
	}
}
