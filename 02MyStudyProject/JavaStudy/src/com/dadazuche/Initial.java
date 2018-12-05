package com.dadazuche;

import java.util.Arrays;
import java.util.Scanner;

public class Initial {

	public static void main(String[] args) {
		Vehicle[] vehicle = { 
				new PassengerCar(1, "奥迪A4", 500, 3), 
				new Van(2, "东风200", 500, 10),
				new Pickup(3, "皮卡", 300, 3, 5), 
				new PassengerCar(4, "奥迪A6", 600, 3), 
				new PassengerCar(5, "丰田", 300, 3),
				new Van(6, "解放60", 500, 12), 
				new Pickup(7, "皮卡200", 600, 4, 8)

		};

		System.out.println("欢迎使用答答租车系统：");
		System.out.println("您是否需要租车：1是 0否");
		Scanner scanner = new Scanner(System.in);
		if (scanner.hasNextInt()) {
			int str = scanner.nextInt();
			if (str == 1) {
				System.out.println("您可租车的类型及其价目表");
				System.out.println("序号" + "\t汽车名称" + "\t租金" + "\t载客" + "\t载货");

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
				System.out.println("请输入你要租车的数量");
				int carsNum = scanner.nextInt();
				for (int j = 0; j < carsNum; j++) {
					System.out.println("请输入第" + (j + 1) + "辆车的序号");
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

				System.out.println("请输入租车时间：");
				rentdays = scanner.nextInt();
				scanner.close();
				System.out.println("您的账单：");
				System.out.println("*****可载人的车有*****");
				System.out.println(Arrays.toString(pc));
				System.out.println("*****可载货的车有*****");
				System.out.println(Arrays.toString(tc));
				System.out.println("租车总价格为；" + totalPrice * rentdays);
			} 
			else {

				System.exit(0);
			}
		}
		
	}

}
