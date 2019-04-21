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
		//mybatis的配置文件
        String resource = "SqlMapConfig.xml";
        //使用类加载器加载mybatis的配置文件（它也加载关联的映射文件）
        InputStream is = Test1.class.getClassLoader().getResourceAsStream(resource);
        //构建sqlSession的工厂
        SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(is);
        //使用MyBatis提供的Resources类加载mybatis的配置文件（它也加载关联的映射文件）
        //Reader reader = Resources.getResourceAsReader(resource); 
        //构建sqlSession的工厂
        //SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(reader);
        //创建能执行映射文件中sql的sqlSession
        SqlSession session = sessionFactory.openSession();
        /**
         * 映射sql的标识字符串，
         * me.gacl.mapping.userMapper是userMapper.xml文件中mapper标签的namespace属性的值，
         * getUser是select标签的id属性值，通过select标签的id属性值就可以找到要执行的SQL
         */
        String statement = "com.shweb.mapping.userMapper.getUser";//映射sql的标识字符串
        //执行查询返回一个唯一user对象的sql
        User user = session.selectOne(statement, 2);
        System.out.println(user);
	}
	
	@Test
	public void addUser() throws IOException {
		//mybatis的配置文件
        String resource = "SqlMapConfig.xml";
        //使用类加载器加载mybatis的配置文件（它也加载关联的映射文件）
        InputStream is = Test1.class.getClassLoader().getResourceAsStream(resource);
        //构建sqlSession的工厂
        SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(is);
        //使用MyBatis提供的Resources类加载mybatis的配置文件（它也加载关联的映射文件）
        //Reader reader = Resources.getResourceAsReader(resource); 
        //构建sqlSession的工厂
        //SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(reader);
        //创建能执行映射文件中sql的sqlSession
        SqlSession session = sessionFactory.openSession();
		
		String satament="com.shweb.mapping.userMapper.addUser";
		User user=new User();
		user.setId("8");
		user.setAge(20);
		user.setCollege("北京大学1");
		user.setIntroduction("的范围人2");
		user.setMajor("机械工程1");
		user.setName("小雷2");
		int i=session.insert(satament,user);
		session.commit();
		session.close();
		System.out.println(i);
	}
	
	@Test
	public void deleteUser() throws IOException {
		//mybatis的配置文件
        String resource = "SqlMapConfig.xml";
        //使用类加载器加载mybatis的配置文件（它也加载关联的映射文件）
        InputStream is = Test1.class.getClassLoader().getResourceAsStream(resource);
        //构建sqlSession的工厂
        SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(is);
        //使用MyBatis提供的Resources类加载mybatis的配置文件（它也加载关联的映射文件）
        //Reader reader = Resources.getResourceAsReader(resource); 
        //构建sqlSession的工厂
        //SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(reader);
        //创建能执行映射文件中sql的sqlSession
        SqlSession session = sessionFactory.openSession();
		
		String satament="com.shweb.mapping.userMapper.deleteUser";
		int i = session.delete(satament, "4");
		session.commit();
		session.close();
		System.out.println(i);
	}
	@Test
	public void updateUser() throws IOException {
		//mybatis的配置文件
        String resource = "SqlMapConfig.xml";
        //使用类加载器加载mybatis的配置文件（它也加载关联的映射文件）
        InputStream is = Test1.class.getClassLoader().getResourceAsStream(resource);
        //构建sqlSession的工厂
        SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(is);
        //使用MyBatis提供的Resources类加载mybatis的配置文件（它也加载关联的映射文件）
        //Reader reader = Resources.getResourceAsReader(resource); 
        //构建sqlSession的工厂
        //SqlSessionFactory sessionFactory = new SqlSessionFactoryBuilder().build(reader);
        //创建能执行映射文件中sql的sqlSession
        SqlSession session = sessionFactory.openSession();
		
		String satament="com.shweb.mapping.userMapper.updateUser";
		User user=new User();
		user.setId("5");		
		user.setCollege("北京大学6662");		
		user.setName("老宋");
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
