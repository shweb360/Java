package com.student.dbc;
import java.sql.* ;

//连接数据库
public class DatabaseConnection {

	private static final String DBDRIVER="com.mysql.jdbc.Driver";
	private static final String DBURL="jdbc:mysql://localhost:3306/suoyuan_db?useUnicode=true&characterEncoding=UTF-8";
	private static final String DBUSER="root";
	private static final String DBPASSWORD="root";
	
	private Connection conn;
	
	public Connection getConnection(){
        return this.conn ;
    }

	public DatabaseConnection() throws Exception {
		try {
			Class.forName(DBDRIVER);
			this.conn=DriverManager.getConnection(DBURL, DBUSER, DBPASSWORD);
		} catch (Exception e) {
			throw e;
		}	
		
	}
	public void close() throws Exception{
		try {
			if(this.conn!=null) {
				this.conn.close();				
			}
		} catch (Exception e) {
			throw e;
		}
	}
}
