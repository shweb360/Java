package com.myapp;

import java.awt.print.PrinterJob;

import javax.print.attribute.HashPrintRequestAttributeSet;

public class Printer {

	public static void main(String[] args) {
		// TODO 自动生成的方法存根

		PrinterJob job=PrinterJob.getPrinterJob();
		HashPrintRequestAttributeSet attributes;
		attributes=new HashPrintRequestAttributeSet();
		job.printDialog(attributes);
	}

}
