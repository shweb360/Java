package com.myapp;
import java.sql.*;
public class LessonJDBCInsert {

	public static void main(String[] args) throws SQLException {
		// TODO �Զ����ɵķ������

		Conn con=new Conn();
		Connection cc=con.getConnection();
		PreparedStatement  sql=cc.prepareStatement("insert into pmw_admin (username,password,nickname,question,answer,levelname,loginip,logintime) values (?,?,?,?,?,?,?,?)");
	    sql.setString(1,"wushuang");
	    sql.setString(2,"123456");
	    sql.setString(3,"��ˬ");
	    sql.setString(4,"1");
	    sql.setInt(5,1);
	    sql.setInt(6,1);
	    sql.setString(7,"�Ļ���");
	    sql.setInt(8,1521360013);
	    int i=sql.executeUpdate();
	    System.out.println(i);
	    
	    sql=cc.prepareStatement("update pmw_admin set username=? where id=?");
	    sql.setString(1, "wushuang_gs");
	    sql.setInt(2, 2);
	    i=sql.executeUpdate();
	    System.out.println(i);
	    
	    sql=cc.prepareStatement("delete from pmw_admin where id=?");
	    sql.setInt(1, 2);
	    i=sql.executeUpdate();
	    System.out.println(i);
	}

}
