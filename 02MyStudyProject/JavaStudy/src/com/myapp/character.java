package com.myapp;

public class character {

	public static void main(String[] args) {

		int maxscore = getMaxAge();
		System.out.println("���ֵ��" + maxscore);
	}

	public static int getMaxAge() {

		int[] ages = { 18, 23, 21, 19, 25, 29, 17 };
		int max = ages[0];
		for (int i = 0; i < ages.length; i++) {
			if (ages[i] > max) {
				max = ages[i];
			}
		}
		return max;
	}

	public static void getws(int num) {

		int count = 0;
		System.out.println("next��ʽ���ܣ�");

		if (num >= 0 && num <= 999999999) {
			while (num != 0) {
				count++;
				num /= 10;
			}
			System.out.println("���Ǹ�" + count + "λ������");
		}
	}
}
