package com.iteheima.convert;

import java.util.Date;
import java.text.ParseException;
import java.text.SimpleDateFormat;

import org.springframework.core.convert.converter.Converter;

import com.sun.xml.internal.txw2.IllegalAnnotationException;

/**
 * 自定义日期转换器
 * 
 * @author wushuang
 *
 */
public class DateConverter implements Converter<String, Date> {

	// 定义日期格式
	private String datePattern = "yyyy-MM-dd HH:mm:ss";

	@Override
	public Date convert(String source) {
		//格式化日期
		SimpleDateFormat sdf=new SimpleDateFormat(datePattern);
		try {
			return (Date) sdf.parse(source);
		} catch (ParseException e) { 
			throw new IllegalArgumentException("无效的日期格式，请使用这种格式："+datePattern); 
			// TODO: handle exception
		}
	}
}
