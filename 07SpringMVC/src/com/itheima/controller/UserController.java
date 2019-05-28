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
	
	/**
	 * ���û������޸�ҳ����ת
	 */
	@RequestMapping("/toUserEdit")
	public String toUserEdit()
	{
		return "user_edit";
	}
	/**
	 * ���������޸��û��ķ���
	 * @param userList
	 * @return
	 */
	@RequestMapping("/editUser")
	public String editUser(UserV0 userList) {
		
		List<User> users=userList.getUsers();
		for(User user:users) {
			if(user.getId()!=null) {
				System.out.println("�޸���idΪ"+user.getId()+"���û���Ϊ��"+user.getUsername());
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
	 * ����ҳ�������JSON���ݣ�������JSON��ʽ���
	 */
	@RequestMapping("/testJson")
	public User testJson(@RequestBody User user) {
		System.out.println(user);
		return user;
	}
	
	/**
	 * ����Resetful������������շ�ʽΪGET
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
