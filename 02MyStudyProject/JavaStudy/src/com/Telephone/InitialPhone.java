package com.Telephone;

public class InitialPhone {

	public static void main(String[] args) {
		// TODO �Զ����ɵķ������

		//����ת��
		Phone p1=new CellPhone();
		p1.call();
		p1.message();
		
		Phone p2=new SmartPhone();
		p2.call();
		p2.message();
		
		//����ת��
		if(p2 instanceof SmartPhone) {
			SmartPhone s=(SmartPhone) p2;
			s.call();
			s.play();
		}
	}

}
