<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>文件上传</title>
<script type="text/javascript">
function check(){
	var name=document.getElementById("name").value;
	var file=document.getElementById("file").value;
	if(name==""){
		alert("请填写上传人");
		return flase;
		
	}
	if(file.length==0||file==""){
		alert("请选择上传文件");
		return flase;
	}
	return true;
}
</script>
</head>
<body>

<form action="${pageContext.request.contextPath}/fileUpload" method="post" enctype="multipart/form-data" onsubmit="return check()">
上传人:<input id="name" type="text" name="name"/><br/>
请选择文件：<input id="file" type="file" name="uploadfile" multiple="multiple"/>
<input type="submit" value="上传"/>
</form>
</body>
</html>