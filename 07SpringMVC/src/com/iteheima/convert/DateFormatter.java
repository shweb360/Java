package com.iteheima.convert;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import org.springframework.format.Formatter;

/**
 * ʹ��Formatter�Զ�������ת����
 * @author wushuang
 *
 */
public class DateFormatter implements Formatter<Date> {

	//�������ڸ�ʽ
	
	String datePattern="yyyy-MM-dd HH:mm:ss";
	//����SimpleDateFormat����
	private SimpleDateFormat simpleDateFormat;
	
	@Override
	public String print(Date date,Locale locale) {
		return new SimpleDateFormat().format(date);
		
	}
	@Override
	public Date parse(String source,Locale locale) throws ParseException{
		simpleDateFormat=new SimpleDateFormat(datePattern);
		return simpleDateFormat.parse(source);
	}
}
