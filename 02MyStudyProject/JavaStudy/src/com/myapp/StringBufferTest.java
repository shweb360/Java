package com.myapp;

public class StringBufferTest {


	public static void main(String[] args) {
		// TODO �Զ����ɵķ������
       StringBuffer sb=new StringBuffer();
       sb.append("Hello");
       sb.append(" Shang");
       sb.append(" Hai");
       System.out.println(sb);
       System.out.println(sb.capacity());
      
       StringBuilder sbl=new StringBuilder();
       sbl.append("Java");
       sbl.append("is");
       sbl.append("fine");
       System.out.println(sbl.toString());
       
	}

}
/*
 * Java StringBuffer �� StringBuilder ��
�����ַ��������޸ĵ�ʱ����Ҫʹ�� StringBuffer �� StringBuilder �ࡣ
�� String �಻ͬ���ǣ�StringBuffer �� StringBuilder ��Ķ����ܹ�����ε��޸ģ����Ҳ������µ�δʹ�ö���
StringBuilder ���� Java 5 �б���������� StringBuffer ֮������ͬ���� StringBuilder �ķ��������̰߳�ȫ�ģ�����ͬ�����ʣ���
���� StringBuilder ����� StringBuffer ���ٶ����ƣ����Զ�������½���ʹ�� StringBuilder �ࡣȻ����Ӧ�ó���Ҫ���̰߳�ȫ������£������ʹ�� StringBuffer �ࡣ
 */
