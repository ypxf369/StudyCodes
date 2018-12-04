package cn.springcloud.study.core.service.intercepter;

import cn.springcloud.study.core.service.vo.User;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpRequest;
import org.springframework.http.client.ClientHttpRequestExecution;
import org.springframework.http.client.ClientHttpRequestInterceptor;
import org.springframework.http.client.ClientHttpResponse;

import java.io.IOException;

/**
 * 用于调用时传递上下文信息
 * Created by yepeng on 2018/12/04.
 */
public class RestTemplateUserContextInterceptor implements ClientHttpRequestInterceptor {
    @Override
    public ClientHttpResponse intercept(HttpRequest httpRequest, byte[] bytes, ClientHttpRequestExecution clientHttpRequestExecution) throws IOException {
        User user = UserContextHolder.currentUser();
        HttpHeaders headers = httpRequest.getHeaders();
        headers.add("x-user-id", user.getUserId());
        headers.add("x-user-name", user.getUserName());
        headers.add("x-user-serviceName", httpRequest.getURI().getHost());
        return clientHttpRequestExecution.execute(httpRequest, bytes);
    }
}
