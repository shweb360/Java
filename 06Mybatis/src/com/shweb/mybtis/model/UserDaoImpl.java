package com.shweb.mybtis.model;

import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;

import com.shweb.mybatis.dao.UserDao;

public class UserDaoImpl implements UserDao {

	private SqlSessionFactory sqlSessionFactory;
	// 向UserDao实现类中注入，SqlsessionFactory;

	// 通过构造方法注入
	public UserDaoImpl(SqlSessionFactory sqlSessionFactory) {
		this.sqlSessionFactory = sqlSessionFactory;
	}

	@Override
	public User findeUserById(Integer id) {
		SqlSession sqlSession = sqlSessionFactory.openSession();
		User user = sqlSession.selectOne("com.shweb.mapping.userMapper.getUser", id);
		sqlSession.close();
		return user;
	}

	@Override
	public List<User> findUserByName(String name) {
		SqlSession sqlSession = sqlSessionFactory.openSession();
		List<User> list = sqlSession.selectList("com.shweb.mapping.userMapper.getUserByName", name);
		sqlSession.close();
		return list;
	}

	@Override
	public void insertUser(User user) {
		SqlSession sqlSession = sqlSessionFactory.openSession();
		sqlSession.insert("com.shweb.mapping.userMapper.addUser", user);
		// 提交事务
		sqlSession.commit();
		// 释放资源
		sqlSession.close();
	}

	@Override
	public void deleteUser(Integer id) {
		// TODO 自动生成的方法存根
		SqlSession sqlSession = sqlSessionFactory.openSession();
		sqlSession.delete("com.shweb.mapping.userMapping.deleteUser", id);
		// 提交事务
		sqlSession.commit();
		// 释放资源
		sqlSession.close();

	}

	@Override
	public void updateUser(User user) {
		// TODO 自动生成的方法存根
       SqlSession sqlSession=sqlSessionFactory.openSession();
       sqlSession.update("com.shweb.mapping.userMapping.updateUser", user);
          // 提交事务
    		sqlSession.commit();
    		// 释放资源
    		sqlSession.close();
	}

}
