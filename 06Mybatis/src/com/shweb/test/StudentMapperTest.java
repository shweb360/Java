package com.shweb.test;
import java.io.InputStream;
import java.util.Date;
import java.util.List;

import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.junit.Before;
import org.junit.Test;

import com.shweb.mapping.StudentMapper;
import com.shweb.mybtis.model.User;

public class StudentMapperTest {

	private SqlSessionFactory sqlSessionFactory;

    // 此方法是在执行findUserByIdTest之前执行
    @Before
    public void setUp() throws Exception {
        String resource = "conf.xml";
        InputStream inputStream = Resources.getResourceAsStream(resource);
        // 创建SqlSessionFcatory
        sqlSessionFactory = new SqlSessionFactoryBuilder().build(inputStream);
    }
    @Test
    public void testFindUserById() {
        SqlSession sqlSession = sqlSessionFactory.openSession();
        // 创建StudentMapper对象，mybatis自动生成mapper代理对象
        StudentMapper mapper = sqlSession.getMapper(StudentMapper.class);
        User user = mapper.findUserById(3);
        System.out.println(user);
        sqlSession.close();
    }
    
    @Test
    public void testFindUserByName() {
        SqlSession sqlSession = sqlSessionFactory.openSession();
        // 创建Usermapper对象，mybatis自动生成mapper代理对象
        StudentMapper mapper = sqlSession.getMapper(StudentMapper.class);
        List<User> list = mapper.findUserByName("李");
        System.out.println(list);
        sqlSession.close();
    }

}
