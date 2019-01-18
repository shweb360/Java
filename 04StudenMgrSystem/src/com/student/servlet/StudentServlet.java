package com.student.servlet;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import com.student.action.StudentAction;

/**
 * Servlet implementation class StudentServlet
 */

@WebServlet(name="StudentServlet",urlPatterns={"/StudentServlet","/addStudent","/viewstudent","/updateStudent","/deleteStudent"})
public class StudentServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		 doPost(request, response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		// TODO Auto-generated method stub
		request.setCharacterEncoding("utf-8");

		if (request.getRequestURI().endsWith("/viewStudent")) {
			RequestDispatcher dispatcher = request.getRequestDispatcher("viewstudent.jsp");
			dispatcher.forward(request, response);
		} else if (request.getRequestURI().endsWith("/addStudent")) {

			doAddStudent(request, response);
		} else if (request.getRequestURI().endsWith("/updateStudent")) {

			doUpdateStudent(request, response);
		} else if (request.getRequestURI().endsWith("/deleteStudent")) {
			doDeleteStudent(request, response);

		}
	}

	private void doAddStudent(HttpServletRequest request, HttpServletResponse response) throws IOException {
		String id = request.getParameter("id");
		String name = request.getParameter("name");
		String age = request.getParameter("age");
		String sex = request.getParameter("sex");
		String major = request.getParameter("major");
		String college = request.getParameter("college");
		String introduction = request.getParameter("introduction");

		StudentAction.addStudent(id, name, new Integer(age), new Integer(sex), major, college, introduction);
		response.sendRedirect("index.jsp");
	}

	private void doUpdateStudent(HttpServletRequest request, HttpServletResponse response) throws IOException {
		String id = request.getParameter("id");

		String name = request.getParameter("name");
		String age = request.getParameter("age");
		String sex = request.getParameter("sex");
		String major = request.getParameter("major");
		String college = request.getParameter("college");
		String introduction = request.getParameter("introduction");

		StudentAction.updateStudent(id, name, new Integer(age), new Integer(sex), major, college, introduction);
		response.sendRedirect("index.jsp");
	}

	private void doDeleteStudent(HttpServletRequest request, HttpServletResponse response) throws IOException {
		String id = request.getParameter("id");
		StudentAction.deleteStudent(id);
		response.sendRedirect("index.jsp");
	}

}
