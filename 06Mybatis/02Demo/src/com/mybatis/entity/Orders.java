package com.mybatis.entity;

import java.util.Date;
import java.util.List;

/**
 * @author wushuang
 *����ʵ��
 */
public class Orders {
	/** ��������Id */
    private Integer id;
    /** �µ��û�id */
    private Integer userid;
    /** ������ */
    private String number;
    /** ��������ʱ�� */
    private Date createTime;
    /** ��ע */
    private String note;
    public Integer getId() {
		return id;
	}
	public void setId(Integer id) {
		this.id = id;
	}
	public Integer getUserid() {
		return userid;
	}
	public void setUserid(Integer userid) {
		this.userid = userid;
	}
	public String getNumber() {
		return number;
	}
	public void setNumber(String number) {
		this.number = number;
	}
	public Date getCreateTime() {
		return createTime;
	}
	public void setCreateTime(Date createTime) {
		this.createTime = createTime;
	}
	public String getNote() {
		return note;
	}
	public void setNote(String note) {
		this.note = note;
	}
	public User getUser() {
		return user;
	}
	public void setUser(User user) {
		this.user = user;
	}
	public List<OrderDetail> getOrderdetails() {
		return orderdetails;
	}
	public void setOrderdetails(List<OrderDetail> orderdetails) {
		this.orderdetails = orderdetails;
	}
	// �û���Ϣ
    private User user;
    // ������ϸ
    private List<OrderDetail> orderdetails;
}
