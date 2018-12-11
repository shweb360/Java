<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>JSP 语法</title>
</head>
<body>
<% int day=3; %>

<%
if(day==1||day==7)
{
%>
<p>今天是周末</p>

<%
}
else{
%>
<p>今天是工作日</p>
<%
}%>
</body>
</html>