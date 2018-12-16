<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>九九乘法表-运用表达式和脚本</title>
</head>
<body>
	<h1>1、表达式</h1>
	<%!
	
	String printStr() {
		String str = "";
		for (int i = 1; i <=9; i++) {
			for (int j = 1; j <= i; j++) {
				str += i + "*" + j + "=" + (i * j) + "&nbsp;&nbsp;&nbsp;&nbsp;";				
			}
			str +="<br>";
		}
		return str;

	}
	%>
	<%=printStr() %>
	<hr>
	<h1>2、脚本</h1>
	<%!
	   void printStr2(JspWriter out) throws Exception  {		
		for (int i = 1; i <=9; i++) {
			for (int j = 1; j <= i; j++) {
				out.println(i + "*" + j + "=" + (i * j) + "&nbsp;&nbsp;&nbsp;&nbsp;");				
			}
			out.println("<br>");
		}
	}
	%>
	<%
	 printStr2(out);
	%>
</body>
</html>