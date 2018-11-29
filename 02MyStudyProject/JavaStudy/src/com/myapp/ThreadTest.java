package com.myapp;

public class ThreadTest extends Thread {

	public int count = 10;

	public void run() {
		while (true) {

			try {
				System.out.print("sleep£º ");
				Thread.sleep(500);
			} catch (InterruptedException e) {
				
				e.printStackTrace();
			}
			System.out.print(count + " ");
			if (--count == 0) {
				return;
			}
		}
	}

	public static void main(String[] args) {
		ThreadTest t = new ThreadTest();
		t.start();

	}

}
