package com.Telephone;

public class SmartPhone extends Phone implements IplayGame {

	public void call() {
		System.out.println("SmartPhone call()");
	}

	@Override
	public void message() {
		// TODO �Զ����ɵķ������
		System.out.println("SmartPhone message()");
	}
	
	public void play() {
		System.out.println("SmartPhone playGame()");
	}
	
}
