package com.myapp;

import java.awt.GridLayout;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

public class SwingLoginExample {

	public static void main(String[] args) {
		//确定一个外观；
		JFrame.setDefaultLookAndFeelDecorated(true);
		// 创建 JFrame 实例
        JFrame frame = new JFrame("Login Example");
        // Setting the width and height of frame
        frame.setSize(350, 200);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        /* 创建面板，这个类似于 HTML 的 div 标签
         * 我们可以创建多个面板并在 JFrame 中指定位置
         * 面板中我们可以添加文本字段，按钮及其他组件。
         */
        JPanel panel = new JPanel();    
        // 添加面板
        frame.add(panel);
        /* 
         * 调用用户定义的方法并添加组件到面板
         */
        placeComponents(panel);

        // 设置界面可见
        frame.setVisible(true);

	}

	private static void placeComponents(JPanel panel) {
		panel.setLayout(null);
		//创建 JLabel
		JLabel userLabel=new JLabel("User:");
		userLabel.setBounds(10,20,80,25);
		panel.add(userLabel);
		
		/*
		 * 创建文本域用于用户输入
		 */
		JTextField userText=new JTextField();
		userText.setBounds(100,20,165,25);		
		panel.add(userText);
		
		/*
		 * 密码输入文本域
		 */
		JLabel passwordLabel=new JLabel("Password:");
		passwordLabel.setBounds(10,50,80,25);
		panel.add(passwordLabel);
		
		/*
		 * 密码 输入文本框
		 */
		JPasswordField passwordText=new JPasswordField();
		 passwordText.setBounds(100,50,165,25);
		panel.add(passwordText);
		
		/*
		 * 创建登陆按钮
		 */
		JButton loginButton=new JButton("login");
		loginButton.setBounds(10, 80, 80, 25);
		panel.add(loginButton);
	}
}
