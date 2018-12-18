<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8" isErrorPage="true"%>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>显示异常信息页面</title>
</head>
<body>
<h1>对不起，页面出现异常：</h1>
<% exception.printStackTrace(response.getWriter()); %>
</body>
</html>