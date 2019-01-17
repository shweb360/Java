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
<%
String id=request.getParameter("id");
Student student=StudentAction.getStudent(id); %>
<body>
 <div class="box col-md-3">
        <div class="box-inner">
            <div class="box-header well" data-original-title="学生信息">
                <h2><i class="glyphicon glyphicon-edit"></i>修改学生信息</h2>
            </div>
            <div class="box-content">
                <form action="updateStudent" method="post" role="form">
                    <div class="form-group">
                       <label>学号</label>
                        <input type="text" class="form-control" name="id" value="<%=student.getId() %>">
                        <label>姓名</label>
                        <input type="text" class="form-control" name="name" value="<%=student.getName() %>">
                        <label>年龄</label>  <input type="text" class="form-control"  name="age" value="<%=student.getAge() %>">
                           <label>性别</label><% if(student.getSex()==1){%>
                             男<%}else{ %>
                            女
                            <%} %>
                             <select  class="form-control" name="sex"><option  value="1">--------性别--------</option><option value="1">男</option><option value="0">女</option></select>
                         <label>专业</label> <input type="text" class="form-control"  name="major" value="<%=student.getMajor()%>">
                       
                        <label>学院</label>  <input type="text" class="form-control"  name="college" value="<%=student.getCollege()%>">
                        <label for="exampleInputEmail1">简介</label>
                        <textarea class="form-control" rows="5" name="introduction" placeholder=" <%=student.getIntroduction()%>" style="
resize: none;" ><%=student.getIntroduction()%></textarea>
                    </div>
             
                    <button type="submit" class="btn btn-default">更新信息</button>
                </form>

            </div>
        </div>
    </div>
  
  <form action="updateStudent" method="post">

<table >
<tr><td>学号</td><td><input type="text" name="id" value="<%=id %>" readonly="true" ></td></tr>
<tr><td>姓名</td><td><input type="text" name="name" value="<%=student.getName() %>"></td></tr>
<tr><td>年龄</td><td><input type="text" name="age" value="<%=student.getAge()%>"></td></tr>
<tr><td>性别</td><td><select name="sex"><option value="1">男</option><option value="0">女</option></select></td></tr>
<tr><td>专业</td><td><input type="text" name="major" value="<%=student.getMajor()%>"></td></tr>
<tr><td>学院</td><td><input type="text" name="college" value="<%=student.getCollege()%>"></td></tr>
<tr><td>简介</td><td><textarea  rows="10" cols="30" name="introduction" ><%=student.getIntroduction() %></textarea></td></tr>
<tr><td colspan="2"><input type="submit" value="提交"></td></tr>
</table>
</form>

</body>
</html>