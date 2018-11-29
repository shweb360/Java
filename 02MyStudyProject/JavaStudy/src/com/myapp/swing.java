package com.myapp;
import javax.swing.*;

public class swing {

	public static void main(String[] args) {		
		//显示应用GUI		
		javax.swing.SwingUtilities.invokeLater(new Runnable() {
			public void run() {
				createAndShowGui();
			}
		});

	}
	
	private static void createAndShowGui()
	{
		//确定一个外观；
		JFrame.setDefaultLookAndFeelDecorated(true);
		
		// 创建及设置窗口
		JFrame frame=new JFrame();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		frame.setSize(500, 350);   
		 // 添加 "Hello World" 标签
		JLabel lable=new JLabel("Hello Swing");
		
		frame.getContentPane().add(lable);
		
		//显示窗口
		
		frame.pack();
		frame.setVisible(true);
		
		
			
	}

}
