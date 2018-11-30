package com.myapp;

public class ThreadSafe implements Runnable {
	int num = 10;
	public void run() {
		while (true) {
			//同步
		   synchronized ("") {		
		
			if (num > 0) {
				try {
					Thread.sleep(1000);
				} catch (InterruptedException e) {
					
					e.printStackTrace();
				}
				System.out.println("ticks：" + num--);
			}
		   }
		}
	}

	public static void main(String[] args) {
		//实例化对象
		ThreadSafe t = new ThreadSafe();
		//以该类对象，实例化四个线程
		Thread ta = new Thread(t);
		Thread tb = new Thread(t);
		Thread tc = new Thread(t);
		Thread td = new Thread(t);
		//分别启动线程
		ta.start();
		tb.start();
		tc.start();
		td.start();

	}

}
