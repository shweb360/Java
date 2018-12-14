<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ page import="java.io.*,java.util.*" %>

<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>HTTP 头部请求实例</title>
</head>
<body>
	<table width="100%" border="1" align="center">
		<tr bgcolor="#949494">
			<th>Header Name</th>
			<th>Header Value</th>
		</tr>
		<%
		 Enumeration headerNames = request.getHeaderNames();
		   while(headerNames.hasMoreElements()) {
		      String paramName = (String)headerNames.nextElement();
		      out.print("<tr><td>" + paramName + "</td>\n");
		      String paramValue = request.getHeader(paramName);
		      out.println("<td> " + paramValue + "</td></tr>\n");
		   }
		%>	
		
	</table>
	<%=request.getParameter("name")%>
	<%=request.getParameter("url")%>
</body>
</html>