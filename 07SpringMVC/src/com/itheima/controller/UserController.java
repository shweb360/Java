package com.itheima.controller;

import javax.servlet.http.HttpServletRequest;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;

import com.itheima.po.User;


/**
 * @author wushuang
 *�����û������Ŀ�������
 */
@Controller
public class UserController {
	
	//���������Ͱ�
	@RequestMapping(value="/selectUser")
	public String selectUser(HttpServletRequest request) {
		
		String id=request.getParameter("id");
		System.out.println("id:"+id);
		return "success";
	}
	@RequestMapping("/getUser")
	public String getUser(@RequestParam(value="user_id") Integer id) {
		System.out.println("id����"+id);
		return "success";
	}
	/**
	 * ���û�ע��ҳ����ת
	 */
	@RequestMapping("/toRegister")
	public String toRegister() {
		return "register";
		
	}
	/**
	 * �����û�ע����Ϣ
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
	 * ���û��б�ҳ����ת
	 * @return
	 */
	@RequestMapping("/selectUsers")
	public String selectUsers()
	{
		return "user";
	}
	/**
	 * ��������ɾ���û��ķ���
	 * @param ids
	 * @return
	 */
	@RequestMapping("/deleteUsers")
	public String deleteUsers(Integer[] ids) {
		if(ids!=null) {
			for(Integer id:ids) {
				System.out.println("ɾ����idΪ"+id+"���û�");
			}
		}
		else
		{
			System.out.println("ids=null");
		}
		return "success";
	}
}
