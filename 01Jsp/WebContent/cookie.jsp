<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    <%@ page import="java.net.*" %>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Cookie</title>
</head>
<body>
<%

//一、创建
//JSP Cookie 处理需要对中文进行编码与解码，方法如下：
String   encodeStr   =   java.net.URLEncoder.encode("无双","UTF-8");            //编码
String   decodeStr   =   java.net.URLDecoder.decode("编码后的字符串","UTF-8");   // 解码

Cookie name = new Cookie("name",encodeStr);
Cookie age = new Cookie("age","20");
//设置过期时间 24小时；
name.setMaxAge(60*60*60);
response.addCookie(name);
response.addCookie(age);
//二、获取cookie
Cookie cookie=null;
Cookie[] cookies=null;
cookies=request.getCookies();
if(cookies!=null){
	out.print("<h2>查找Cookie名与值</h2>");
	for(Cookie c:cookies){
		out.print("参数名："+c.getName());
		out.print("<br>");
		out.print("参数值："+URLDecoder.decode(c.getValue(), "utf-8") +" <br>");
		out.print("------------------------------------<br>");
	}
}

//三、删除
/* 删除cookie非常简单。如果您想要删除一个cookie，按照下面给的步骤来做就行了：
获取一个已经存在的cookie然后存储在Cookie对象中。
将cookie的有效期设置为0。
将这个cookie重新添加进响应头中。 
*/
if(cookies!=null)
{
	for(Cookie c:cookies){
		if(c.getName().equals("age")){
			c.setMaxAge(0);
			response.addCookie(c);
            out.print("删除 Cookie: " + 
            c.getName( ) + "<br/>");
		}
		out.print("参数名："+c.getName());
		out.print("<br>");
		out.print("参数值："+URLDecoder.decode(c.getValue(), "utf-8") +" <br>");
		out.print("------------------------------------<br>");
	}
}
%>
</body>
</html>