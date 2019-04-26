package com.mybatis.test;

import java.io.IOException;
import java.io.InputStream;
import java.util.List;

import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.junit.Before;
import org.junit.jupiter.api.Test;

import com.mybatis.entity.*;
import com.mybatis.Mapper.OrdersCustomMapper;

/**
 * @author wushuang
 *
 */
public class OrdersCustomMapperTest {
	private SqlSessionFactory sqlSessionFactory;

	// �˷�������ִ��findUserByIdTest֮ǰִ��
	@Before
	public void setUp() throws Exception {
		String resource = "SqlMapConfig.xml";
		InputStream inputStream = Resources.getResourceAsStream(resource);
		// ����SqlSessionFcatory
		sqlSessionFactory = new SqlSessionFactoryBuilder().build(inputStream);
	}

	// ��ѯ������������ѯ�û���Ϣ��ʹ��resultTypeʵ�ֵĲ���
	@Test
	public void TestFindOrdersUser() {

		SqlSession sqlSession = sqlSessionFactory.openSession();
		// �����������
		OrdersCustomMapper oc = sqlSession.getMapper(OrdersCustomMapper.class);
		// ����mapper�ķ���
		List<OrdersCustom> list = oc.findOrdersUser();
		System.out.println(list);
		sqlSession.close();
	}

	// ��ѯ������������ѯ�û���Ϣ��ʹ��resultMapʵ�ֵĲ���
	@Test
	public void TestFindOrdersUserResultMap() {
		SqlSession sqlSession = sqlSessionFactory.openSession();
		// �����������
		OrdersCustomMapper oc = sqlSession.getMapper(OrdersCustomMapper.class);
		// ����mapper�ķ���
		List<Orders> list = oc.findOrdersUserResultMap();
		System.out.println(list);
		sqlSession.close();

	}
	// ��ѯ�����������û����Լ�������ϸ�Ĳ���
    @Test
    public void TestFindOrdersAndOrderDetailResultMap() throws IOException {
    	String resource = "SqlMapConfig.xml";
		InputStream inputStream = Resources.getResourceAsStream(resource);
		// ����SqlSessionFcatory
		sqlSessionFactory = new SqlSessionFactoryBuilder().build(inputStream);
        SqlSession sqlSession = sqlSessionFactory.openSession();
        // �����������
        OrdersCustomMapper oc = sqlSession.getMapper(OrdersCustomMapper.class);
        // ����mapper�ķ���
        List<Orders> list = oc.findOrdersAndOrderDetailResultMap();
        System.out.println(list);
        sqlSession.close();  
    }
 // ��ѯ�û����û��������Ʒ����Ϣ
    @Test
    public void TestFindUserAndItemsResultMap() throws IOException {
    	String resource = "SqlMapConfig.xml";
		InputStream inputStream = Resources.getResourceAsStream(resource);
		// ����SqlSessionFcatory
		sqlSessionFactory = new SqlSessionFactoryBuilder().build(inputStream);
		
        SqlSession sqlSession = sqlSessionFactory.openSession();
        // �����������
        OrdersCustomMapper oc = sqlSession.getMapper(OrdersCustomMapper.class);
        // ����mapper�ķ���
        List<User> list = oc.findUserAndItemsResultMap();
        System.out.println(list);
        sqlSession.close();
    }
}
