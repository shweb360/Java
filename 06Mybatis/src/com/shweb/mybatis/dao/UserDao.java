package com.shweb.mybatis.dao;

import java.util.List;

import com.shweb.mybtis.model.User;

/**
 * @author wushuang
 * 用户管理DAO接口
 */
public interface UserDao {

	//根据id查询得到一个user对象
	public User findeUserById(Integer id);
	
	//根据用户名称模糊查询用户信息	
	public List<User> findUserByName(String name);
	
	//增加用户
	public void insertUser(User user);
	
	//根据id删除用户
	public void deleteUser(Integer id);
	
	//修改用户
	public void updateUser(User user);
	
}
