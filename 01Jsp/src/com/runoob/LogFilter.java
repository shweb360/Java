package com.runoob;
import java.io.*;
import javax.servlet.*;

public class LogFilter implements Filter {

	public void destroy() {
		System.out.println("First Filter------Destory");
	}
 
	public void doFilter(ServletRequest arg0, ServletResponse arg1,
			FilterChain arg2) throws IOException, ServletException {
		System.out.println("First Filter------doFilter start");
 
		arg2.doFilter(arg0, arg1);
		
		System.out.println("First Filter------doFilter end");
	}
 
	public void init(FilterConfig arg0) throws ServletException {
		System.out.println("First Filter------Init");
	}



}
