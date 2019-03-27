package com.shweb.mybtis.model;

import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;

import com.shweb.mybatis.dao.UserDao;

public class UserDaoImpl implements UserDao {

	private SqlSessionFactory sqlSessionFactory;
	// ��UserDaoʵ������ע�룬SqlsessionFactory;

	// ͨ�����췽��ע��
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
		// �ύ����
		sqlSession.commit();
		// �ͷ���Դ
		sqlSession.close();
	}

	@Override
	public void deleteUser(Integer id) {
		// TODO �Զ����ɵķ������
		SqlSession sqlSession = sqlSessionFactory.openSession();
		sqlSession.delete("com.shweb.mapping.userMapping.deleteUser", id);
		// �ύ����
		sqlSession.commit();
		// �ͷ���Դ
		sqlSession.close();

	}

	@Override
	public void updateUser(User user) {
		// TODO �Զ����ɵķ������
       SqlSession sqlSession=sqlSessionFactory.openSession();
       sqlSession.update("com.shweb.mapping.userMapping.updateUser", user);
          // �ύ����
    		sqlSession.commit();
    		// �ͷ���Դ
    		sqlSession.close();
	}

}
