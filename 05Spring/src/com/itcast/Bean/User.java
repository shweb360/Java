package com.itcast.Bean;

public class User {

	public User() {
		System.out.println("�ղι���");
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public Integer getAge() {
		return age;
	}
	public void setAge(Integer age) {
		this.age = age;
	}
	private String name;
	private Integer age;
}