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
<title>查看学生信息</title>
        <link id="bs-css" href="css/bootstrap-cerulean.min.css" rel="stylesheet">

    <link href="css/charisma-app.css" rel="stylesheet">
</head>
<%
String id=request.getParameter("id");
Student student=StudentAction.getStudent(id); %>
<body>
<div class="box col-md-3">
        <div class="box-inner">
            <div class="box-header well" data-original-title="学生信息">
                <h2><i class="glyphicon glyphicon-edit"></i>学生信息</h2>
               
                        &nbsp;<a href="index.jsp" ><h5 align="right">返回</h5></a>
                      
                              
                  
            </div>
            <div class="box-content">
                <form action="#" method="post" role="form">
                    <div class="form-group">
                       <label>学号</label>
                        <input type="text" class="form-control" name="id" placeholder="<%=student.getId() %>" readonly="readonly">
                        <label>姓名</label>
                        <input type="text" class="form-control" name="name" placeholder="<%=student.getName() %>" readonly="readonly">
                        <label>年龄</label>  <input type="text" class="form-control"  name="age" placeholder="<%=student.getAge() %>" readonly="readonly">
                           <label>性别</label><% if(student.getSex()==1){%>
                             <input type="text" class="form-control"  placeholder="男" readonly="readonly"><%}else{ %>
                            <input type="text" class="form-control"  placeholder="女" readonly="readonly"></td>
                            <%} %>
                         <label>专业</label> <input type="text" class="form-control"  name="major" placeholder="<%=student.getMajor()%>" readonly="readonly">
                       
                        <label>学院</label>  <input type="text" class="form-control"  name="college" placeholder="<%=student.getCollege()%>" readonly="readonly">
                        <label for="exampleInputEmail1">简介</label>
                        <textarea type="text" class="form-control" rows="5" name="introduction" placeholder=" <%=student.getIntroduction()%>" style="
resize: none;" readonly="readonly"></textarea>
                    </div>
             
                </form>

            </div>
        </div>
    </div>
</body>
</html>