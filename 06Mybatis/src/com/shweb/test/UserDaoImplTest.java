package com.shweb.test;

import java.io.InputStream;
import java.util.Date;
import java.util.List;
import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.junit.Before;
import org.junit.Test;

import com.shweb.mybtis.model.User;
import com.shweb.mybtis.model.UserDaoImpl;

public class UserDaoImplTest {

	private SqlSessionFactory sqlSessionFactory;

	@Before
	public void setUp() throws Exception {
		String resource = "conf.xml";
		InputStream inputStream = Resources.getResourceAsStream(resource);
		sqlSessionFactory = new SqlSessionFactoryBuilder().build(inputStream);
	}

	@Test
	public void findUserByIdTest() {
		UserDaoImpl userDao = new UserDaoImpl(sqlSessionFactory);
		User user = userDao.findeUserById(3);
		System.out.println(user);
	}

	
}
