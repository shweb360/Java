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
<title>学生管理系统</title>
  <link id="bs-css" href="css/bootstrap-cerulean.min.css" rel="stylesheet">

    <link href="css/charisma-app.css" rel="stylesheet">
</head>
<body>

<div class="box col-md-12" >
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-user"></i> 学生管理系统</h2>
                     <div class="box-icon">
                        <a href="addstudent.jsp" class="btn btn-minimize btn-round btn-default"><i
                                class="glyphicon glyphicon-chevron-up"></i>添加学生</a>
                      
                              
                    </div>  
                </div>
                <div class="box-content">
                    <table class="table table-striped table-bordered responsive" width="80%">
                        <thead>
                        <tr>
                              <th class="center">&nbsp;&nbsp;&nbsp;&nbsp;学号</th>
                              <th class="center">&nbsp;&nbsp;&nbsp;&nbsp;姓名</th>
                              <th>&nbsp;&nbsp;&nbsp;&nbsp;年龄</th>
                              <th>&nbsp;&nbsp;&nbsp;&nbsp;性别</th>
                              <th>&nbsp;&nbsp;&nbsp;&nbsp;专业</th>
                              <th>&nbsp;&nbsp;&nbsp;&nbsp;学院</th>
                              <th>&nbsp;&nbsp;&nbsp;&nbsp;简介</th>
                            <th>&nbsp;&nbsp;&nbsp;&nbsp;操作</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr>
                        <% ArrayList students=StudentAction.getAllstudent();
            for(int i=0;i<students.size();i++){
                Student student=(Student)students.get(i);%>
                
                            <td class="center">&nbsp;&nbsp;&nbsp;&nbsp;<%=student.getId() %></td>
                            <td class="center">&nbsp;&nbsp;&nbsp;&nbsp;<%=student.getName() %></td>
                            <td class="center">&nbsp;&nbsp;&nbsp;&nbsp;<%=student.getAge()%></td>
                            <% if(student.getSex()==1){%>
                            <td class="center">&nbsp;&nbsp;&nbsp;&nbsp;男</td><%}else{ %>
                            <td class="center">&nbsp;&nbsp;&nbsp;&nbsp;女</td>
                            <%} %>
                            <td class="center">&nbsp;&nbsp;&nbsp;&nbsp;<%=student.getMajor()%></td>
                            <td class="center">&nbsp;&nbsp;&nbsp;&nbsp;<%=student.getCollege()%></td>
                            <td class="center">&nbsp;&nbsp;&nbsp;&nbsp;<%=student.getIntroduction()%>...</td>
                        <td >
                              <a class="btn btn-success"href="StudentServlet/viewstudent?id=<%=student.getId()%>">
                                    <i class="glyphicon glyphicon-zoom-in icon-white"></i>
                                    查看
                                </a>
                                
                                <a class="btn btn-info" href="updatestudent.jsp?id=<%=student.getId()%>">
                                    <i class="glyphicon glyphicon-edit icon-white"></i>
                                    修改
                                </a>
                                <a class="btn btn-danger" href="deleteStudent?id=<%=student.getId()%>">
                                    <i class="glyphicon glyphicon-trash icon-white"></i>
                                    删除
                                </a>
                           </td>
                            
                        </tr>
                       
                        </tbody>
                            <%
        
    } %>
                    </table>
                </div>
            </div>
        </div>
</body>
</html>