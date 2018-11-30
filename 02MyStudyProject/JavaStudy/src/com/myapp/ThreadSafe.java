package com.myapp;

public class ThreadSafe implements Runnable {
	int num = 10;
	public void run() {
		while (true) {
			//ͬ��
		   synchronized ("") {		
		
			if (num > 0) {
				try {
					Thread.sleep(1000);
				} catch (InterruptedException e) {
					
					e.printStackTrace();
				}
				System.out.println("ticks��" + num--);
			}
		   }
		}
	}

	public static void main(String[] args) {
		//ʵ��������
		ThreadSafe t = new ThreadSafe();
		//�Ը������ʵ�����ĸ��߳�
		Thread ta = new Thread(t);
		Thread tb = new Thread(t);
		Thread tc = new Thread(t);
		Thread td = new Thread(t);
		//�ֱ������߳�
		ta.start();
		tb.start();
		tc.start();
		td.start();

	}

}
