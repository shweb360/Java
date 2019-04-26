package com.ithema.pro;

public class Customer {
	private Integer Id;
	private String username;
	private String jobs;
	private String phone;
	public Integer getId() {
		return Id;
	}
	public void setId(Integer id) {
		this.Id = id;
	}
	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getJobs() {
		return jobs;
	}
	public void setJobs(String jobs) {
		this.jobs = jobs;
	}
	public String getPhone() {
		return phone;
	}
	public void setPhone(String phone) {
		this.phone = phone;
	}
	@Override
	public String toString() {
		return "Customer [id=" + Id + ", username=" + username + ", jobs=" + jobs + ", phone=" + phone + "]";
	}

}
