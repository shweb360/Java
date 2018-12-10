package com.myapp;

import java.util.Date;
import java.util.Locale;

public class StringTest {

	public static void main(String[] args) {

		String str = "wushuang.com";
		System.out.println(str.length());

		char[] c1 = { '明', '日', '科', '技' };
		int cha = Character.codePointAt(c1, 2);
		System.out.println(cha);

		float floatVar = 122.3f;
		int intVar = 2;
		String stringVar = "java";
		System.out.printf("浮点型变量的值为 " + "%f, 整型变量的值为 " + " %d, 字符串变量的值为 " + "is %s", floatVar, intVar, stringVar);
		System.out.println();

		String strs = "007";
		System.out.printf(Locale.CHINA, "%s", strs);
		System.out.println();
		Date date = new Date();
		System.out.printf(Locale.CHINA, "The date is %tc\n", date);
	}

}
