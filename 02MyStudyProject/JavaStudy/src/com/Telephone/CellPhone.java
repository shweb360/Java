package com.Telephone;

public class CellPhone extends Phone {
	public void call() {
		System.out.println("CellPhone call()");
	}

	@Override
	public void message() {
		// TODO �Զ����ɵķ������
		System.out.println("CellPhone message()");
	}
}
