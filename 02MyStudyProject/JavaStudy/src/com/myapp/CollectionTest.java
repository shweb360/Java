package com.myapp;

import java.util.*;

public class CollectionTest {

	public static void main(String[] args) {

		List<String> list = new ArrayList<String>();
		list.add("Hello");
		list.add("wu");
		list.add("shuang");
		// 第一种遍历，
		for (String st : list) {
			System.out.println(st);
		}
		//第二种，将链表转换成数组.
		String[] strArray=new String[list.size()];
		strArray=list.toArray(strArray);
		for (int i = 0; i < strArray.length; i++) {
			
			System.out.println(strArray[i]);
		}
		//第三种，迭代器
	    Iterator<String> itor=list.iterator();
	    while(itor.hasNext()) {
	    	System.out.println(itor.next());
	    }
	}

}
