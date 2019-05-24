<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>测试Json交互</title>
<script src="https://cdn.staticfile.org/jquery/1.10.2/jquery.min.js"></script>
<script>
function test(){
	var username=$("#username").val();
	var password=$("#password").val();
	$.ajax({
		url:"${pageContext.request.contextPath}/testJson",
		type:"post",
		data:JSON.stringify({username:username,password:password}),
		contentType:"application/json",
		dataType:"json",
		success:function(data){
			if(data!=null){
				alert("您输入的用户名为："+data.username+"密码为："+data.password);
			}
		}
		
	});
}
</script>
</head>
<body>
<form>
用户名：<input type="text" name="username" id="username"><br/>
密码：<input type="password" name="password" id="password"><br/>
<input type="button" value="测试JSON交互" onclick="test()"/>
</form>        
</body>
</html>