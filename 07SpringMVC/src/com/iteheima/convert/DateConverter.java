package com.iteheima.convert;

import java.util.Date;
import java.text.ParseException;
import java.text.SimpleDateFormat;

import org.springframework.core.convert.converter.Converter;

import com.sun.xml.internal.txw2.IllegalAnnotationException;

/**
 * �Զ�������ת����
 * 
 * @author wushuang
 *
 */
public class DateConverter implements Converter<String, Date> {

	// �������ڸ�ʽ
	private String datePattern = "yyyy-MM-dd HH:mm:ss";

	@Override
	public Date convert(String source) {
		//��ʽ������
		SimpleDateFormat sdf=new SimpleDateFormat(datePattern);
		try {
			return (Date) sdf.parse(source);
		} catch (ParseException e) { 
			throw new IllegalArgumentException("��Ч�����ڸ�ʽ����ʹ�����ָ�ʽ��"+datePattern); 
			// TODO: handle exception
		}
	}
}
