package com.mybatis.entity;

import java.util.Date;
import java.util.List;

/**
 * @author wushuang
 * �û�ʵ��
 */
public class User {
    private Integer id;
    // ����
    private String username;
    // �Ա�
    private String sex;
    // ��ַ
    private String address;
    // ����
    private Date birthday;
    // �û������Ķ����б�
    private List<Orders> ordersList;
}
