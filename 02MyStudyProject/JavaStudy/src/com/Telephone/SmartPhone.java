package com.Telephone;

public class SmartPhone extends Phone implements IplayGame {

	public void call() {
		System.out.println("SmartPhone call()");
	}

	@Override
	public void message() {
		// TODO 自动生成的方法存根
		System.out.println("SmartPhone message()");
	}
	
	public void play() {
		System.out.println("SmartPhone playGame()");
	}
	
}
