package com.myapp;
import javax.swing.*;

public class swing {

	public static void main(String[] args) {		
		//��ʾӦ��GUI		
		javax.swing.SwingUtilities.invokeLater(new Runnable() {
			public void run() {
				createAndShowGui();
			}
		});

	}
	
	private static void createAndShowGui()
	{
		//ȷ��һ����ۣ�
		JFrame.setDefaultLookAndFeelDecorated(true);
		
		// ���������ô���
		JFrame frame=new JFrame();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		frame.setSize(500, 350);   
		 // ��� "Hello World" ��ǩ
		JLabel lable=new JLabel("Hello Swing");
		
		frame.getContentPane().add(lable);
		
		//��ʾ����
		
		frame.pack();
		frame.setVisible(true);
		
		
			
	}

}
