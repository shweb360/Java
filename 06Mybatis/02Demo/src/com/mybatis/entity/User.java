package com.mybatis.entity;

import java.util.Date;
import java.util.List;

/**
 * @author wushuang
 * 用户实体
 */
public class User {
    private Integer id;
    // 姓名
    private String username;
    // 性别
    private String sex;
    // 地址
    private String address;
    // 生日
    private Date birthday;
    // 用户创建的订单列表
    private List<Orders> ordersList;
}
