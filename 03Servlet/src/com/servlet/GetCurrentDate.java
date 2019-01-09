package com.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class GetCurrentDate
 */
@WebServlet("/GetCurrentDate")
public class GetCurrentDate extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public GetCurrentDate() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
	    
		response.setContentType("text/html;charset=UTF-8");
		PrintWriter out=response.getWriter();
		String title="Current Date:";
		Date dt=new Date();
	    SimpleDateFormat df=new SimpleDateFormat("yyyy.MM.dd hh:mm:ss");
		String docType="<!DOCTYPE html> \n";
		out.println(docType+
				 "<html>\n" +
		            "<head><title>" + title + "</title></head>\n" +
		            "<body bgcolor=\"#f0f0f0\">\n" +
		            "<h1 align=\"center\">" + title + "</h1>\n" +
		            "<h2 align=\"center\">" + df.format(dt) + "</h2>\n" +
		            "</body></html>");
				
		
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
