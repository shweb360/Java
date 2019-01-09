
<%
String path = request.getContextPath();
String basePath = request.getScheme()+"://"+request.getServerName()+":"+request.getServerPort()+path+"/";
out.println("path: "+path+"<br>");
out.println("getScheme: "+request.getScheme()+"<br>");
out.println("basePath: "+basePath+"<br>");
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>My first jsp Page</title>
</head>
<body>

<%

out.println("Your IP address is "+request.getRemoteAddr());
%>

<jsp:scriptlet>
out.println("hahah ww956");
</jsp:scriptlet>
</body>
</html>