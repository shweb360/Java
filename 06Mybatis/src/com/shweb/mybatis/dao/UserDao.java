package com.shweb.mybatis.dao;

import java.util.List;

import com.shweb.mybtis.model.User;

/**
 * @author wushuang
 * �û�����DAO�ӿ�
 */
public interface UserDao {

	//����id��ѯ�õ�һ��user����
	public User findeUserById(Integer id);
	
	//�����û�����ģ����ѯ�û���Ϣ	
	public List<User> findUserByName(String name);
	
	//�����û�
	public void insertUser(User user);
	
	//����idɾ���û�
	public void deleteUser(Integer id);
	
	//�޸��û�
	public void updateUser(User user);
	
}
