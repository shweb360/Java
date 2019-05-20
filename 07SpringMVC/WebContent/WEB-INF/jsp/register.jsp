<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>注册</title>
</head>
<body>
<form action="${pageContext.request.contextPath}/registerUser" method="POST">

用户名：<input type="text" name="username"/><br/>
密 码：<input type="text" name="password"/><br/>
<input type="submit" value="注册"/>
</form>
</body>
</html>