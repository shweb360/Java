package com.myapp;

import java.sql.Connection;
import java.sql.DriverManager;

public class Conn {
	Connection con;
	// JDBC �����������ݿ� URL
	static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";
	static final String DB_URL = "jdbc:mysql://localhost:3306/suoyuan_db";

	// ���ݿ���û��������룬��Ҫ�����Լ�������
	static final String USER = "root";
	static final String PASS = "root";

	public Connection getConnection() {
		try {
			// ע�� JDBC ����
			Class.forName(JDBC_DRIVER);
		} catch (ClassNotFoundException e) {

			e.printStackTrace();
		}
		try {
			// ������
			System.out.println("�������ݿ�...");
			con = DriverManager.getConnection(DB_URL, USER, PASS);
			System.out.println("���ݿ����ӳɹ�");

		} catch (Exception e) {
			e.printStackTrace();

		}

		return con;
	}
}
