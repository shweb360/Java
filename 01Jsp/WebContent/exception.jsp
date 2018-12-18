<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<%@page import="jdk.internal.org.objectweb.asm.tree.TryCatchBlockNode"%>
<html>
<head>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.io.*,java.util.Locale" %>
<%@ page import="javax.servlet.*,javax.servlet.http.* "%>
<!-- 自动地调用错误页面 -->
<%@ page errorPage="exMsg.jsp" %>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>JSP 异常处理</title>
</head>
<body>

<%
try{
	
	out.println(10/0);
}
catch(Exception ex){
	out.print(ex.getMessage());
}
%>
</body>
</html>