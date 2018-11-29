package com.myapp;

public class AnimalDog extends Animal {
	public int age=20;
    @Override
	public String toString() {
		return "AnimalDog [age=" + age + "]";
	}
	public static void eat() {
    	System.out.println("Dog has eating");
    }
}
