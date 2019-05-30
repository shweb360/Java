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
 * 文件上传
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
		//判断所上传的文件是否存在
		if (!uploadfile.isEmpty() && uploadfile.size() > 0) {
			//循环输出上传文件
			for (MultipartFile file : uploadfile) {
				//获取上传文件的原始名称
				String originalFilename = file.getOriginalFilename();
				//设置上传文件的保存地址目录
				String dirPath = request.getServletContext().getRealPath("/upload/");
				File filePath = new File(dirPath);
				if (!filePath.exists()) {
					filePath.mkdirs();

				}
				//使用MultipartFile接口的方法完成问卷上传到制定目录
				String newFilename = name + "_" + UUID.randomUUID() + "_" + originalFilename;
				try {
					file.transferTo(new File(dirPath + newFilename));
				} catch (Exception ex) {
					ex.printStackTrace();
					return "error";
				}
			}
			// 跳转成功页
			return "success";
		} else {
			return "error";
		}

	}
}
