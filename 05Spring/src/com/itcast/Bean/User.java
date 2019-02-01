package com.itcast.Bean;

public class User {

	public User() {
		System.out.println("空参构造");
	}
	//构造函数1
	public User(String name, Car car) {
		System.out.println("User(String name, Car car)");
		this.name = name;
		this.car = car;
	}
	//构造函数2
	public User(Integer name, Car car) {
		System.out.println("User(Integer name, Car car)");
		this.name = name+"333";
		this.car = car;
	}
	
	//构造函数3
	public User(Car car,String name) {
		System.out.println("User(Car car,String name)");
		this.car = car;
		this.name = name;
		
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
	public Car getCar() {
		return car;
	}
	public void setCar(Car car) {
		this.car = car;
	}
	private String name;
	
	private Integer age;
	
	private Car car;

	@Override
	public String toString() {
		return "User [name=" + name + ", age=" + age + ", car=" + car + "]";
	}
}
