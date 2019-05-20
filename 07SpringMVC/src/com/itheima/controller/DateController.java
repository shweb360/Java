package com.itheima.controller;

import java.util.Date;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

/**
 * 日期控制器类
 * @author wushuang
 *
 */
@Controller
public class DateController {

	@RequestMapping("/customDate")
	public String CustomDate(Date date)
	{
		System.out.println("date="+date);
		return"success";
	}
}
