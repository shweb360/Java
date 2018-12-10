package com.myapp;

import java.util.*;

public class CollectionMap {

	public static void main(String[] args) {
		Map<String, String> map = new HashMap<String, String>();
		map.put("name", "wushuang");
		map.put("add", "shanghai");
		map.put("age", "20");
		// ��һ�֣��ձ�ʹ�ã�����ȡֵ
		for (String key : map.keySet()) {

			System.out.println("Key:" + key + " Value��" + map.get(key));
		}
		// �ڶ��֣�ͨ��Map.entrySetʹ��iterator����key��value��
		Iterator<Map.Entry<String, String>> itor = map.entrySet().iterator();
		while (itor.hasNext()) {
			Map.Entry<String, String> entry = itor.next();
			System.out.println("key= " + entry.getKey() + " and value= " + entry.getValue());

		}
		// �����֣��Ƽ���������������ʱ
		for (Map.Entry<String, String> item : map.entrySet()) {
			System.out.println(item);
		}
		// �����֣�ͨ��Map.values()�������е�value�������ܱ���key
		for (String s : map.values()) {
			System.out.print("value:" + s + "\t");
		}
		
	}

}
/*
 * �ܽ� Java���Ͽ��Ϊ����Ա�ṩ��Ԥ�Ȱ�װ�����ݽṹ���㷨���������ǡ�
 * ������һ�����󣬿�����������������á����Ͻӿ�������ÿһ�����͵ļ��Ͽ���ִ�еĲ�����
 * ���Ͽ�ܵ���ͽӿھ���java.util���С�
 * �κζ�����뼯������Զ�ת��ΪObject���ͣ�������ȡ����ʱ����Ҫ����ǿ������ת����
 */
