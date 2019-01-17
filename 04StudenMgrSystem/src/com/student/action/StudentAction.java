package com.student.action;

import java.sql.*;
import java.util.ArrayList;

import com.student.dbc.DatabaseConnection;
import com.student.vo.Student;

public class StudentAction {

	public static Connection conn = null;

	/**
	 * 增加学生
	 * 
	 * @param id
	 * @param name
	 * @param age
	 * @param sex
	 * @param major
	 * @param college
	 * @param introduction
	 * @return
	 */
	public static boolean addStudent(String id, String name, int age, int sex, String major, String college,
			String introduction) {
		try {
			java.sql.Connection conn = new DatabaseConnection().getConnection();
			PreparedStatement st = conn.prepareStatement("insert into student values(?,?,?,?,?,?,?)");

			st.setString(1, id);
			st.setString(2, name);
			st.setInt(3, age);
			st.setInt(4, sex);
			st.setString(5, major);
			st.setString(6, college);
			st.setString(7, introduction);

			st.execute();
			conn.close();
			return true;
		} catch (Exception e) {
			return false;
		}

	}

	/**
	 * 更新学生
	 * 
	 * @param id
	 * @param name
	 * @param age
	 * @param sex
	 * @param major
	 * @param college
	 * @param introduction
	 * @return
	 */
	public static boolean updateStudent(String id, String name, int age, int sex, String major, String college,
			String introduction) {
		try {
			java.sql.Connection conn = new DatabaseConnection().getConnection();
			PreparedStatement st = conn.prepareStatement(
					"update student set name=?,age=?,sex=?,major=?,college=?,introduction=? where id=?");

			st.setString(1, name);
			st.setInt(2, age);
			st.setInt(3, sex);
			st.setString(4, major);
			st.setString(5, college);
			st.setString(6, introduction);
			st.setString(7, id);

			st.execute();
			conn.close();
			return true;

		} catch (Exception e) {
			// TODO: handle exception
			return false;
		}
	}

	/**
	 * 删除
	 * 
	 * @param id
	 * @return
	 */
	public static boolean deleteStudent(String id) {
		try {

			java.sql.Connection conn = new DatabaseConnection().getConnection();
			PreparedStatement st = conn.prepareStatement("delete from student where id=?");

			st.setString(1, id);

			st.execute();

			conn.close();
			return true;
		} catch (Exception e) {
			// TODO: handle exception
			return false;
		}
	}

	/**
	 * 获取全部学生
	 * 
	 * @return
	 */

	public static ArrayList getAllstudent() {
		ArrayList students = new ArrayList();

		try {
			java.sql.Connection conn = new DatabaseConnection().getConnection();
			PreparedStatement st = conn.prepareStatement("select * from student");
			st.execute();
			ResultSet rs = st.getResultSet();
			while (rs.next()) {
				Student student = new Student();
				student.setId(rs.getString("id"));
				student.setName(rs.getString("name"));
				student.setAge(rs.getInt("age"));
				student.setSex(rs.getInt("sex"));
				student.setMajor(rs.getString("major"));
				student.setCollege(rs.getString("college"));
				student.setIntroduction(rs.getString("introduction"));
				students.add(student);

			}
			conn.close();

		} catch (Exception e) {
			// TODO: handle exception
		}
		return students;
	}

	/**
	 * 按学号查询学生
	 * 
	 * @param id
	 * @return
	 */
	public static Student getStudent(String id) {

		Student student = null;
		try {
			java.sql.Connection conn = new DatabaseConnection().getConnection();
			PreparedStatement st = conn.prepareStatement("select * from student where id=?");

			st.setString(1, id);
			st.execute();
			ResultSet rs = st.getResultSet();
			while (rs.next()) {
				student = new Student();

				student.setId(rs.getString("id"));
				student.setName(rs.getString("name"));
				student.setAge(rs.getInt("age"));
				student.setSex(rs.getInt("sex"));
				student.setMajor(rs.getString("major"));
				student.setCollege(rs.getString("college"));
				student.setIntroduction(rs.getString("introduction"));

			}
			conn.close();

		} catch (Exception e) {
			// TODO: handle exception
		}
		return student;
	}
}
