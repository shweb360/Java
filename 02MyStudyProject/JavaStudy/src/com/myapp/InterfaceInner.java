package com.myapp;

public class InterfaceInner {

	public static void main(String[] args) {
		
		InterfaceInner x=new InterfaceInner();
		InnerClass in=x.new InnerClass("wew");
		in.doit();
		//��ʹ������������ֹ�������������̻߳���ִ�����񣬺���������Ҳ���޷�����ִ�С�
		System.exit(0);
	}
	
	
	//�ڲ���	
   public	class InnerClass implements OutInterface{
       public InnerClass(String s) {
    	   System.out.println(s);
       }
	
		public void f() {
			System.out.println("�����ڲ����еķ���f()");
		}
		
		public OutInterface doit() {
			
			return new InnerClass("�����ڲ��๹�췽��") ;
			
		}
	}
}

interface OutInterface{
	public void f();
}

