package com.itheima.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;


/**
 * @author wushuang controller ◊¢Ω‚¿‡–Õ
 */
@Controller
public class ZhujieController {

	@RequestMapping(value = "/Zhujie", method = RequestMethod.GET)
	public String handleRequest(HttpServletRequest requset, HttpServletResponse response, Model model)
			throws Exception {

		model.addAttribute("msg", "hello,wushuang");

		//return "/WEB-INF/jsp/first.jsp";
		return "zhujie";
	}

}
