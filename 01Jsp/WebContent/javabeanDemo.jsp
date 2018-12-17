<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ page import="com.runoob.Student"%>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>JavaBean 程序示例</title>
</head>
<body>
	<h1>1、使用普通方式创建JavaBean的实例</h1>
	<%
		Student st = new Student();
		st.setName("wushuang");
		st.setPwd("123456");
	%>
	用户名：<%=st.getName() %>
	<br>
	 密码：<%=st.getPwd() %>
	<hr>
	<h1>2、JavaBean</h1>
	
	<%-- <jsp:useBean id="标识符" class="java类名" scope="作用范围"/> --%>
	
	<jsp:useBean id="myStudent" class="com.runoob.Student" scope="page"></jsp:useBean>
	<jsp:setProperty property="name" name="myStudent" value="ww"/>
	<jsp:setProperty property="pwd" name="myStudent" value="123"/>
	用户名：<jsp:getProperty property="name" name="myStudent" /><br>
	密码：<jsp:getProperty property="pwd" name="myStudent"/>
</body>
</html>