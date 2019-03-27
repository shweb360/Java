package com.shweb.mapping;

import java.util.List;

import com.shweb.mybtis.model.User;


/**
 * @author wushuang
 * mapper������(ֻ��Ҫmapper�ӿڣ��൱��dao�ӿ�)
 */
public interface StudentMapper {

	/** ����ID��ѯ�û���Ϣ */
    public User findUserById(int id);

    /** �����û�����ģ����ѯ�û���Ϣ */
    public List<User> findUserByName(String username);

    /** ����û� */
    public void insertUser(User user);

    /** ����IDɾ���û� */
    public void deleteUser(Integer id);

    /** ����ID�����û� */
    public void updateUser(User user);
}
