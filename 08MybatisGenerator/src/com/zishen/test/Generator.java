package com.zishen.test;

import java.io.File;
import java.io.IOException;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import org.mybatis.generator.api.MyBatisGenerator;
import org.mybatis.generator.config.Configuration;
import org.mybatis.generator.config.xml.ConfigurationParser;
import org.mybatis.generator.exception.InvalidConfigurationException;
import org.mybatis.generator.exception.XMLParserException;
import org.mybatis.generator.internal.DefaultShellCallback;


/**
 * 参考
 * https://www.cnblogs.com/whgk/p/7140638.html
 *
 */
public class Generator {

	public static void main(String[] agrs) throws IOException, XMLParserException, InvalidConfigurationException {
		
		List<String> warnings = new ArrayList<String>();
		   boolean overwrite = true;
		   File configFile = new File("config/generatorConfig.xml");
		   ConfigurationParser cp = new ConfigurationParser(warnings);
		   Configuration config = cp.parseConfiguration(configFile);
		   DefaultShellCallback callback = new DefaultShellCallback(overwrite);
		   MyBatisGenerator myBatisGenerator = new MyBatisGenerator(config, callback, warnings);
		   try {
			myBatisGenerator.generate(null);
		} catch (SQLException | InterruptedException e) {
			// TODO 自动生成的 catch 块
			e.printStackTrace();
		}
	}
}
