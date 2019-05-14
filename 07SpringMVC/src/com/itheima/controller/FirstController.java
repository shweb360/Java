package com.itheima.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;

/**
 * @author wushuang
 * ��������
 */
public class FirstController implements Controller {

	@Override
	public ModelAndView handleRequest(HttpServletRequest arg0, HttpServletResponse arg1) throws Exception {
		
		//����ModelAndView
		ModelAndView mav=new ModelAndView();
		//��ģ�Ͷ������������
		mav.addObject("msg", "This is My first Springmvc");
		//�����߼���ͼ��
		mav.setViewName("/WEB-INF/jsp/first.jsp");
		//����ModelAndView
		return mav;
	}

}
