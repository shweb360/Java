package com.myapp;

public class OverLoadTest {

	// 方法重载，同一个类中允许同时存在一个或多个同名的方法，只要参数类型，参数个数不同即可。

	public static int add(int a) {
		return a++;
	}

	public static int add(int a, int b) {
		return a + b;
	}

	public static int add(double a, int b) {
		return (int) a + b;
	}

	public static void main(String[] args) {

		System.out.println("调用add(int a):" + add(1));
		System.out.println("调用add(int a, int b):" + add(1, 2));
		System.out.println("调用add(double a,int b):" + add(1.1, 2));
	}

}
