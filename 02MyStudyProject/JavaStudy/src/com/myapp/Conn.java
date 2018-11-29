package com.myapp;

import java.sql.Connection;
import java.sql.DriverManager;

public class Conn {
	Connection con;
	// JDBC 驱动名及数据库 URL
	static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";
	static final String DB_URL = "jdbc:mysql://localhost:3306/suoyuan_db";

	// 数据库的用户名与密码，需要根据自己的设置
	static final String USER = "root";
	static final String PASS = "root";

	public Connection getConnection() {
		try {
			// 注册 JDBC 驱动
			Class.forName(JDBC_DRIVER);
		} catch (ClassNotFoundException e) {

			e.printStackTrace();
		}
		try {
			// 打开链接
			System.out.println("连接数据库...");
			con = DriverManager.getConnection(DB_URL, USER, PASS);
			System.out.println("数据库连接成功");

		} catch (Exception e) {
			e.printStackTrace();

		}

		return con;
	}
}
