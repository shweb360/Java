package com.runoob;

import java.io.IOException;

import javax.servlet.jsp.JspException;
import javax.servlet.jsp.JspWriter;
import javax.servlet.jsp.tagext.SimpleTagSupport;

//�̳�SimpleTagSupport�ಢ��д��doTag()����������һ����򵥵��Զ����ǩ

public class HelloTag extends SimpleTagSupport {

	//��дdoTa����
	public void doTag() throws IOException, JspException {
		JspWriter out=getJspContext().getOut();
		out.println("Hello Costom Tag!");
		getJspContext().setAttribute("message", "HAHA");
		getJspBody().invoke(null);
	}
}
