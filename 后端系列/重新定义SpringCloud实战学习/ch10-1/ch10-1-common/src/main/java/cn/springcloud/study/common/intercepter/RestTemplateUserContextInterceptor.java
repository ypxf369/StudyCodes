package cn.springcloud.study.common.intercepter;

import cn.springcloud.study.common.context.UserContextHolder;
import cn.springcloud.study.common.vo.User;
import org.springframework.http.HttpRequest;
import org.springframework.http.client.ClientHttpRequestExecution;
import org.springframework.http.client.ClientHttpRequestInterceptor;
import org.springframework.http.client.ClientHttpResponse;

import java.io.IOException;
import java.util.Map;

/**
 * RestTemplate传递用户上下文
 * Created by yepeng on 2018/11/26.
 */
public class RestTemplateUserContextInterceptor implements ClientHttpRequestInterceptor {
    @Override
    public ClientHttpResponse intercept(HttpRequest httpRequest, byte[] bytes, ClientHttpRequestExecution clientHttpRequestExecution) throws IOException {
        User user = UserContextHolder.currentUser();
        Map<String, String> headers = user.toHttpHeaders();
        for (Map.Entry<String, String> header : headers.entrySet()) {
            httpRequest.getHeaders().add(header.getKey(), header.getValue());
        }
        // 调用
        return clientHttpRequestExecution.execute(httpRequest, bytes);
    }
}
