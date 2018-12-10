package com.myapp;

import java.util.*;

public class CollectionMap {

	public static void main(String[] args) {
		Map<String, String> map = new HashMap<String, String>();
		map.put("name", "wushuang");
		map.put("add", "shanghai");
		map.put("age", "20");
		// 第一种，普遍使用，二次取值
		for (String key : map.keySet()) {

			System.out.println("Key:" + key + " Value：" + map.get(key));
		}
		// 第二种，通过Map.entrySet使用iterator遍历key和value：
		Iterator<Map.Entry<String, String>> itor = map.entrySet().iterator();
		while (itor.hasNext()) {
			Map.Entry<String, String> entry = itor.next();
			System.out.println("key= " + entry.getKey() + " and value= " + entry.getValue());

		}
		// 第三种，推荐，尤其是容量大时
		for (Map.Entry<String, String> item : map.entrySet()) {
			System.out.println(item);
		}
		// 第四种，通过Map.values()遍历所有的value，但不能遍历key
		for (String s : map.values()) {
			System.out.print("value:" + s + "\t");
		}
		
	}

}
/*
 * 总结 Java集合框架为程序员提供了预先包装的数据结构和算法来操纵他们。
 * 集合是一个对象，可容纳其他对象的引用。集合接口声明对每一种类型的集合可以执行的操作。
 * 集合框架的类和接口均在java.util包中。
 * 任何对象加入集合类后，自动转变为Object类型，所以在取出的时候，需要进行强制类型转换。
 */
