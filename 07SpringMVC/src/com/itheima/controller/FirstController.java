package com.itheima.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;

/**
 * @author wushuang
 * 控制器类
 */
public class FirstController implements Controller {

	@Override
	public ModelAndView handleRequest(HttpServletRequest arg0, HttpServletResponse arg1) throws Exception {
		
		//创建ModelAndView
		ModelAndView mav=new ModelAndView();
		//向模型对象中添加数据
		mav.addObject("msg", "This is My first Springmvc");
		//设置逻辑视图名
		mav.setViewName("/WEB-INF/jsp/first.jsp");
		//返回ModelAndView
		return mav;
	}

}
