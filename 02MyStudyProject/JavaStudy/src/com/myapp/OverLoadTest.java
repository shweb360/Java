package com.myapp;

public class OverLoadTest {

	// �������أ�ͬһ����������ͬʱ����һ������ͬ���ķ�����ֻҪ�������ͣ�����������ͬ���ɡ�

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

		System.out.println("����add(int a):" + add(1));
		System.out.println("����add(int a, int b):" + add(1, 2));
		System.out.println("����add(double a,int b):" + add(1.1, 2));
	}

}
