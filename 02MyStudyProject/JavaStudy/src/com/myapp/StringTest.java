package com.myapp;

import java.util.Date;
import java.util.Locale;

public class StringTest {

	public static void main(String[] args) {

		String str = "wushuang.com";
		System.out.println(str.length());

		char[] c1 = { '��', '��', '��', '��' };
		int cha = Character.codePointAt(c1, 2);
		System.out.println(cha);

		float floatVar = 122.3f;
		int intVar = 2;
		String stringVar = "java";
		System.out.printf("�����ͱ�����ֵΪ " + "%f, ���ͱ�����ֵΪ " + " %d, �ַ���������ֵΪ " + "is %s", floatVar, intVar, stringVar);
		System.out.println();

		String strs = "007";
		System.out.printf(Locale.CHINA, "%s", strs);
		System.out.println();
		Date date = new Date();
		System.out.printf(Locale.CHINA, "The date is %tc\n", date);
	}

}
