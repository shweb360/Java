package com.mybatis.entity;

/**
 * @author wushuang
 * @Description: TODO(��������չ��,ͨ������ӳ�䶩�����û��Ĳ�ѯ���,�ô���̳��ֶν϶��ʵ����)
 */
public class OrdersCustom extends Orders {
	 // �����û�������
    private String username;
	private String sex;
    private String address;
    public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
}