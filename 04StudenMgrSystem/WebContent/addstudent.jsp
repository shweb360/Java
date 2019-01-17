<%@page import="com.student.vo.Student"%>
<%@ page language="java" import="java.util.*" pageEncoding="utf-8"%>
<%@ page import="com.student.action.StudentAction"%>
<%
String path = request.getContextPath();
String basePath = request.getScheme()+"://"+request.getServerName()+":"+request.getServerPort()+path+"/";
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>添加学生信息</title>
       <link id="bs-css" href="css/bootstrap-cerulean.min.css" rel="stylesheet">

    <link href="css/charisma-app.css" rel="stylesheet">
</head>
<body>
 <div class="box col-md-3">
        <div class="box-inner">
            <div class="box-header well" data-original-title="">
                <h2><i class="glyphicon glyphicon-edit"></i>学生信息</h2>
            </div>
            <div class="box-content">
                <form action="addStudent" method="post" role="form">
                    <div class="form-group">
                       
                        <input type="text" class="form-control" name="id" placeholder="学号">
                        
                        <input type="text" class="form-control" name="name" placeholder="姓名">
                        <input type="text" class="form-control"  name="age" placeholder="年龄">
                      
                       
                         <select  class="form-control" name="sex"><option value="1" >--------性别--------</option><option value="1">男</option><option value="0">女</option></select>
                        <input type="text" class="form-control"  name="major" placeholder="专业">
                       
                        <input type="text" class="form-control"  name="college" placeholder="学院">
                        <label for="exampleInputEmail1">简介</label>
                        <textarea type="text" class="form-control" rows="5" name="introduction" style="
resize: none;" ></textarea>
                    </div>
             
                    <button type="submit" class="btn btn-default">提交</button>
                </form>

            </div>
        </div>
    </div>
</body>
</html>