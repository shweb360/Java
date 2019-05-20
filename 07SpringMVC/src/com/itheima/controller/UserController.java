package com.itheima.controller;

import javax.servlet.http.HttpServletRequest;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;

import com.itheima.po.User;


/**
 * @author wushuang
 *创建用户操作的控制器类
 */
@Controller
public class UserController {
	
	//简单数据类型绑定
	@RequestMapping(value="/selectUser")
	public String selectUser(HttpServletRequest request) {
		
		String id=request.getParameter("id");
		System.out.println("id:"+id);
		return "success";
	}
	@RequestMapping("/getUser")
	public String getUser(@RequestParam(value="user_id") Integer id) {
		System.out.println("id——"+id);
		return "success";
	}
	/**
	 * 向用户注册页面跳转
	 */
	@RequestMapping("/toRegister")
	public String toRegister() {
		return "register";
		
	}
	/**
	 * 接受用户注册信息
	 */
	@RequestMapping(value="/registerUser",method=RequestMethod.POST)
	public String registerUser(User user) {
		String username=user.getUsername();
		String password=user.getPassword();
		System.out.println("username="+username);
		System.out.println("password="+password);
		return "success";
		
	}
	
	/**
	 * 向用户列表页面跳转
	 * @return
	 */
	@RequestMapping("/selectUsers")
	public String selectUsers()
	{
		return "user";
	}
	/**
	 * 接受批量删除用户的方法
	 * @param ids
	 * @return
	 */
	@RequestMapping("/deleteUsers")
	public String deleteUsers(Integer[] ids) {
		if(ids!=null) {
			for(Integer id:ids) {
				System.out.println("删除了id为"+id+"的用户");
			}
		}
		else
		{
			System.out.println("ids=null");
		}
		return "success";
	}
}
