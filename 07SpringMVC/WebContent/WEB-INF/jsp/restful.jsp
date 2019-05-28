<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Restful测试</title>
<script src="https://cdn.staticfile.org/jquery/1.10.2/jquery.min.js"></script>
<script>
function search(){
	var id=$("#number").val();
	$.ajax({
		url:"${pageContext.request.contextPath}/user/"+id,
		type:"GET",
		dataType:"json",
		success:function(data){
			if(data.username!=null){
				alert("您查询的用户是："+data.username);
				
			}
			else{
				alert("没有找到id为："+id+"的用户！");
			}
		}
	});
}
</script>
</head>
<body>
<form>
编号：<input type="text" name="number" id="number"/>
<input type="button" value="搜索" onclick="search()"/>
</form>
</body>
</html>