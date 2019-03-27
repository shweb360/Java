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

    // �˷�������ִ��findUserByIdTest֮ǰִ��
    @Before
    public void setUp() throws Exception {
        String resource = "conf.xml";
        InputStream inputStream = Resources.getResourceAsStream(resource);
        // ����SqlSessionFcatory
        sqlSessionFactory = new SqlSessionFactoryBuilder().build(inputStream);
    }
    @Test
    public void testFindUserById() {
        SqlSession sqlSession = sqlSessionFactory.openSession();
        // ����StudentMapper����mybatis�Զ�����mapper�������
        StudentMapper mapper = sqlSession.getMapper(StudentMapper.class);
        User user = mapper.findUserById(3);
        System.out.println(user);
        sqlSession.close();
    }
    
    @Test
    public void testFindUserByName() {
        SqlSession sqlSession = sqlSessionFactory.openSession();
        // ����Usermapper����mybatis�Զ�����mapper�������
        StudentMapper mapper = sqlSession.getMapper(StudentMapper.class);
        List<User> list = mapper.findUserByName("��");
        System.out.println(list);
        sqlSession.close();
    }

}
