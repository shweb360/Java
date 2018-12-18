package com.runoob;

import java.io.IOException;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.JspWriter;
import javax.servlet.jsp.tagext.SimpleTagSupport;

//继承SimpleTagSupport类并重写的doTag()方法来开发一个最简单的自定义标签

public class HelloTag extends SimpleTagSupport {

	//重写doTa方法
	public void doTag() throws IOException, JspException {
		JspWriter out=getJspContext().getOut();
		out.println("Hello Costom Tag!");
		getJspContext().setAttribute("message", "HAHA");
		getJspBody().invoke(null);
	}
}
