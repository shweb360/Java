package com.itheima.controller;

import java.io.File;
import java.util.List;
import java.util.UUID;

import javax.servlet.http.HttpServletRequest;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.multipart.MultipartFile;

/**
 * �ļ��ϴ�
 * 
 * @author wushuang
 *
 */
@Controller
public class FileUploadController {

	@RequestMapping("/tofileUpload")
	public String toindex()
	{
		return "fileUpload";
	}
	
	@RequestMapping("/fileUpload")
	public String handleFormUpload(@RequestParam("name") String name, @RequestParam List<MultipartFile> uploadfile,
			HttpServletRequest request) {
		//�ж����ϴ����ļ��Ƿ����
		if (!uploadfile.isEmpty() && uploadfile.size() > 0) {
			//ѭ������ϴ��ļ�
			for (MultipartFile file : uploadfile) {
				//��ȡ�ϴ��ļ���ԭʼ����
				String originalFilename = file.getOriginalFilename();
				//�����ϴ��ļ��ı����ַĿ¼
				String dirPath = request.getServletContext().getRealPath("/upload/");
				File filePath = new File(dirPath);
				if (!filePath.exists()) {
					filePath.mkdirs();

				}
				//ʹ��MultipartFile�ӿڵķ�������ʾ��ϴ����ƶ�Ŀ¼
				String newFilename = name + "_" + UUID.randomUUID() + "_" + originalFilename;
				try {
					file.transferTo(new File(dirPath + newFilename));
				} catch (Exception ex) {
					ex.printStackTrace();
					return "error";
				}
			}
			// ��ת�ɹ�ҳ
			return "success";
		} else {
			return "error";
		}

	}
}
