package com.myapp;

import java.sql.*;;

public class LessonJDBC {

	public static void main(String[] args) throws SQLException {

		Conn conn = new Conn();
		Connection c = conn.getConnection();

		Statement sql = c.createStatement();
		// ִ�в�ѯ
		ResultSet rs = sql.executeQuery("select * from pmw_admin");
		// չ����������ݿ�
		while (rs.next()) {
			int id = rs.getInt("id");
			String username = rs.getString("username");
			System.out.println("id:" + id);
			System.out.println("username:" + username);
		}
		rs.close();
		sql.close();

	}

}
