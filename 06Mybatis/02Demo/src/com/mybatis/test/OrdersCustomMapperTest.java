package com.mybatis.test;

import java.io.InputStream;
import java.util.List;

import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.junit.Before;
import org.junit.jupiter.api.Test;

import com.mybatis.entity.Orders;
import com.mybatis.entity.OrdersCustom;
import com.mybatis.Mapper.OrdersCustomMapper;

/**
 * @author wushuang
 *
 */
public class OrdersCustomMapperTest {
	private SqlSessionFactory sqlSessionFactory;

	// 此方法是在执行findUserByIdTest之前执行
	@Before
	public void setUp() throws Exception {
		String resource = "SqlMapConfig.xml";
		InputStream inputStream = Resources.getResourceAsStream(resource);
		// 创建SqlSessionFcatory
		sqlSessionFactory = new SqlSessionFactoryBuilder().build(inputStream);
	}

	// 查询订单，关联查询用户信息，使用resultType实现的测试
	@Test
	public void TestFindOrdersUser() {

		SqlSession sqlSession = sqlSessionFactory.openSession();
		// 创建代理对象
		OrdersCustomMapper oc = sqlSession.getMapper(OrdersCustomMapper.class);
		// 调用mapper的方法
		List<OrdersCustom> list = oc.findOrdersUser();
		System.out.println(list);
		sqlSession.close();
	}

	// 查询订单，关联查询用户信息，使用resultMap实现的测试
	@Test
	public void TestFindOrdersUserResultMap() {
		SqlSession sqlSession = sqlSessionFactory.openSession();
		// 创建代理对象
		OrdersCustomMapper oc = sqlSession.getMapper(OrdersCustomMapper.class);
		// 调用mapper的方法
		List<Orders> list = oc.findOrdersUserResultMap();
		System.out.println(list);
		sqlSession.close();

	}
}
