package com.myapp;
import java.util.Scanner;
import java.lang.StringBuffer;

public class first {

	public static void main(String[] args) {
	
		Scanner scan=new Scanner(System.in);
		
		System.out.println("next��ʽ���ܣ�");
		
		if(scan.hasNext()) {
			String str1=scan.next();
			System.out.println("��������Ϊ��"+str1);
			
		}
		
		StringBuffer ss=new StringBuffer();
		ss.append("22");
		ss.append("33");
		System.out.println(ss);
		scan.close();
		
	}


}
