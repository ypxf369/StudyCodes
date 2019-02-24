package com.yp.runner.test;

import org.springframework.boot.ApplicationArguments;
import org.springframework.boot.ApplicationRunner;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.stereotype.Component;

/**
 * Created by yepeng on 2019/02/24.
 */
@Component //第一种方法
public class MyRunner implements ApplicationRunner {
    @Override
    public void run(ApplicationArguments args) throws Exception {
        System.out.println("runner first ");
    }

    @Bean //第三种方法
    public CommandLineRunner init(){
        return (String... args)->{
          System.out.println("third way...");
        };
    }
    
    @Bean
    public ApplicationRunner init2(){
        return (ApplicationArguments args)->{
            System.out.println("fourth way...");
        };
    }

    @Component //第二种方法
    class MyRunnerCommandLine implements CommandLineRunner{

        @Override
        public void run(String... args) throws Exception {
            System.out.println("commandLine runner first "+args);
        }
    }
}
