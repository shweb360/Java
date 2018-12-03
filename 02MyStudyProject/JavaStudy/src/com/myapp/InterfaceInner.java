package com.myapp;

public class InterfaceInner {

	public static void main(String[] args) {
		
		InterfaceInner x=new InterfaceInner();
		InnerClass in=x.new InnerClass("wew");
		in.doit();
		//会使程序立即被终止，程序中若有线程还在执行任务，后续的任务也就无法继续执行。
		System.exit(0);
	}
	
	
	//内部类	
   public	class InnerClass implements OutInterface{
       public InnerClass(String s) {
    	   System.out.println(s);
       }
	
		public void f() {
			System.out.println("访问内部类中的方法f()");
		}
		
		public OutInterface doit() {
			
			return new InnerClass("访问内部类构造方法") ;
			
		}
	}
}

interface OutInterface{
	public void f();
}

