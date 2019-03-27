package com.shweb.mapping;

import java.util.List;

import com.shweb.mybtis.model.User;


/**
 * @author wushuang
 * mapper代理方法(只需要mapper接口，相当于dao接口)
 */
public interface StudentMapper {

	/** 根据ID查询用户信息 */
    public User findUserById(int id);

    /** 根据用户名称模糊查询用户信息 */
    public List<User> findUserByName(String username);

    /** 添加用户 */
    public void insertUser(User user);

    /** 根据ID删除用户 */
    public void deleteUser(Integer id);

    /** 根据ID更新用户 */
    public void updateUser(User user);
}
