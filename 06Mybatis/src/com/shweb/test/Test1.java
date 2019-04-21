package com.shweb.test;

import java.io.IOException;
import java.io.InputStream;
import java.io.Reader;
import java.nio.channels.SeekableByteChannel;
import java.util.List;

import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.junit.jupiter.api.Test;

import com.shweb.mybtis.model.User;
import com.shweb.util.MyBatisUtil;

public class Test1 {

	@Test
	public void testSelect()
	{
		//mybatis�������ļ�
        String resource = "SqlMapConfig.xml";
        //ʹ�������������mybatis�������ļ�����Ҳ���ع�����ӳ���ļ���
        InputStream is = Test1.class.getClassLoader().getResourceAsStream(resource);
        //����sqlSession�Ĺ���
        SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(is);
        //ʹ��MyBatis�ṩ��Resources�����mybatis�������ļ�����Ҳ���ع�����ӳ���ļ���
        //Reader reader = Resources.getResourceAsReader(resource); 
        //����sqlSession�Ĺ���
        //SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(reader);
        //������ִ��ӳ���ļ���sql��sqlSession
        SqlSession session = sessionFactory.openSession();
        /**
         * ӳ��sql�ı�ʶ�ַ�����
         * me.gacl.mapping.userMapper��userMapper.xml�ļ���mapper��ǩ��namespace���Ե�ֵ��
         * getUser��select��ǩ��id����ֵ��ͨ��select��ǩ��id����ֵ�Ϳ����ҵ�Ҫִ�е�SQL
         */
        String statement = "com.shweb.mapping.userMapper.getUser";//ӳ��sql�ı�ʶ�ַ���
        //ִ�в�ѯ����һ��Ψһuser�����sql
        User user = session.selectOne(statement, 2);
        System.out.println(user);
	}
	
	@Test
	public void addUser() throws IOException {
		//mybatis�������ļ�
        String resource = "SqlMapConfig.xml";
        //ʹ�������������mybatis�������ļ�����Ҳ���ع�����ӳ���ļ���
        InputStream is = Test1.class.getClassLoader().getResourceAsStream(resource);
        //����sqlSession�Ĺ���
        SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(is);
        //ʹ��MyBatis�ṩ��Resources�����mybatis�������ļ�����Ҳ���ع�����ӳ���ļ���
        //Reader reader = Resources.getResourceAsReader(resource); 
        //����sqlSession�Ĺ���
        //SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(reader);
        //������ִ��ӳ���ļ���sql��sqlSession
        SqlSession session = sessionFactory.openSession();
		
		String satament="com.shweb.mapping.userMapper.addUser";
		User user=new User();
		user.setId("8");
		user.setAge(20);
		user.setCollege("������ѧ1");
		user.setIntroduction("�ķ�Χ��2");
		user.setMajor("��е����1");
		user.setName("С��2");
		int i=session.insert(satament,user);
		session.commit();
		session.close();
		System.out.println(i);
	}
	
	@Test
	public void deleteUser() throws IOException {
		//mybatis�������ļ�
        String resource = "SqlMapConfig.xml";
        //ʹ�������������mybatis�������ļ�����Ҳ���ع�����ӳ���ļ���
        InputStream is = Test1.class.getClassLoader().getResourceAsStream(resource);
        //����sqlSession�Ĺ���
        SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(is);
        //ʹ��MyBatis�ṩ��Resources�����mybatis�������ļ�����Ҳ���ع�����ӳ���ļ���
        //Reader reader = Resources.getResourceAsReader(resource); 
        //����sqlSession�Ĺ���
        //SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(reader);
        //������ִ��ӳ���ļ���sql��sqlSession
        SqlSession session = sessionFactory.openSession();
		
		String satament="com.shweb.mapping.userMapper.deleteUser";
		int i = session.delete(satament, "4");
		session.commit();
		session.close();
		System.out.println(i);
	}
	@Test
	public void updateUser() throws IOException {
		//mybatis�������ļ�
        String resource = "SqlMapConfig.xml";
        //ʹ�������������mybatis�������ļ�����Ҳ���ع�����ӳ���ļ���
        InputStream is = Test1.class.getClassLoader().getResourceAsStream(resource);
        //����sqlSession�Ĺ���
        SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(is);
        //ʹ��MyBatis�ṩ��Resources�����mybatis�������ļ�����Ҳ���ع�����ӳ���ļ���
        //Reader reader = Resources.getResourceAsReader(resource); 
        //����sqlSession�Ĺ���
        //SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(reader);
        //������ִ��ӳ���ļ���sql��sqlSession
        SqlSession session = sessionFactory.openSession();
		
		String satament="com.shweb.mapping.userMapper.updateUser";
		User user=new User();
		user.setId("5");		
		user.setCollege("������ѧ6662");		
		user.setName("����");
		int i=session.insert(satament,user);
		session.commit();
	
		session.close();
		System.out.println(i);
	}
	@Test
	public void getAllUser() throws IOException {
		
        SqlSession session = MyBatisUtil.getSqlSession();		
		String satament="com.shweb.mapping.userMapper.getAllUser";
		List<User> lstUsers = session.selectList(satament);
		System.out.println(lstUsers);
		session.close();
		
	}
	
	//https://www.cnblogs.com/xdp-gacl/p/4264301.html
}
