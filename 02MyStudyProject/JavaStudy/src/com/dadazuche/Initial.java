package com.dadazuche;

import java.util.Arrays;
import java.util.Scanner;

public class Initial {

	public static void main(String[] args) {
		Vehicle[] vehicle = { 
				new PassengerCar(1, "�µ�A4", 500, 3), 
				new Van(2, "����200", 500, 10),
				new Pickup(3, "Ƥ��", 300, 3, 5), 
				new PassengerCar(4, "�µ�A6", 600, 3), 
				new PassengerCar(5, "����", 300, 3),
				new Van(6, "���60", 500, 12), 
				new Pickup(7, "Ƥ��200", 600, 4, 8)

		};

		System.out.println("��ӭʹ�ô���⳵ϵͳ��");
		System.out.println("���Ƿ���Ҫ�⳵��1�� 0��");
		Scanner scanner = new Scanner(System.in);
		if (scanner.hasNextInt()) {
			int str = scanner.nextInt();
			if (str == 1) {
				System.out.println("�����⳵�����ͼ����Ŀ��");
				System.out.println("���" + "\t��������" + "\t���" + "\t�ؿ�" + "\t�ػ�");

				for (int i = 0; i < vehicle.length; i++) {
					System.out.println(vehicle[i].getNum() 
							+ "\t" + vehicle[i].getName() 
							+ "\t" + vehicle[i].getRental()
							+ "\t" + vehicle[i].getPeopleNum() 
							+ "\t" + vehicle[i].getWeight());

				}
				int totalPrice = 0;
				int rentdays = 0;
				String[] pc = new String[5];
				String[] tc = new String[4];
				int n = 0;
				int m = 0;
				System.out.println("��������Ҫ�⳵������");
				int carsNum = scanner.nextInt();
				for (int j = 0; j < carsNum; j++) {
					System.out.println("�������" + (j + 1) + "���������");
					int carNum = scanner.nextInt();
					totalPrice += vehicle[carNum - 1].getRental();
					if (vehicle[carNum - 1].peopleNum > 0) {
						pc[n] = vehicle[carNum - 1].getName();
						n = n + 1;
					}
					if (vehicle[carNum - 1].weight > 0) {
						tc[m] = vehicle[carNum - 1].getName();
						m = m + 1;
					}
				}

				System.out.println("�������⳵ʱ�䣺");
				rentdays = scanner.nextInt();
				scanner.close();
				System.out.println("�����˵���");
				System.out.println("*****�����˵ĳ���*****");
				System.out.println(Arrays.toString(pc));
				System.out.println("*****���ػ��ĳ���*****");
				System.out.println(Arrays.toString(tc));
				System.out.println("�⳵�ܼ۸�Ϊ��" + totalPrice * rentdays);
			} 
			else {

				System.exit(0);
			}
		}
		
	}

}
