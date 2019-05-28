package com.itheima.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;

import com.itheima.po.User;
import com.itheima.vo.UserV0;


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
	
	/**
	 * 向用户批量修改页面跳转
	 */
	@RequestMapping("/toUserEdit")
	public String toUserEdit()
	{
		return "user_edit";
	}
	/**
	 * 接受批量修改用户的方法
	 * @param userList
	 * @return
	 */
	@RequestMapping("/editUser")
	public String editUser(UserV0 userList) {
		
		List<User> users=userList.getUsers();
		for(User user:users) {
			if(user.getId()!=null) {
				System.out.println("修改了id为"+user.getId()+"的用户名为："+user.getUsername());
			}
		}
		
		return "success";
	}
	@RequestMapping("/toIndex")
	public String toindex()
	{
		return "index";
	}
	/**
	 * 接收页面请求的JSON数据，并返回JSON格式结果
	 */
	@RequestMapping("/testJson")
	public User testJson(@RequestBody User user) {
		System.out.println(user);
		return user;
	}
	
	/**
	 * 接受Resetful风格的请求，其接收方式为GET
	 * 
	 */
	@RequestMapping(value="/user/{id}",method=RequestMethod.GET)
	@ResponseBody
	public User selectUser(@PathVariable("id") String id)
	{
		System.out.println("id:"+id);
		User user=new User();
		if(id.equals("1234")) {
			user.setUsername("wushuang");
		}
		return user;
	}
}
