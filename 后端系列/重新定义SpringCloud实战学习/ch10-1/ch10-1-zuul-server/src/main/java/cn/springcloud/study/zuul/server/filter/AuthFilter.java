package cn.springcloud.study.zuul.server.filter;

import cn.springcloud.study.common.exception.BaseException;
import cn.springcloud.study.common.exception.BaseExceptionBody;
import cn.springcloud.study.common.exception.CommonError;
import cn.springcloud.study.common.util.HttpConvertUtil;
import cn.springcloud.study.common.vo.User;
import com.alibaba.fastjson.JSONObject;
import com.netflix.zuul.ZuulFilter;
import com.netflix.zuul.context.RequestContext;
import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import javax.servlet.http.HttpServletRequest;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Map;

/**
 * Created by yepeng on 2018/11/26.
 */
public class AuthFilter extends ZuulFilter {
    private static final Logger logger = LoggerFactory.getLogger(AuthFilter.class);

    @Override
    public boolean shouldFilter() {
        // 判断是否需要进行处理
        return true;
    }

    @Override
    public Object run() {
        RequestContext rc = RequestContext.getCurrentContext();
        authUser(rc);
        return null;
    }

    @Override
    public String filterType() {
        return "pre";
    }

    @Override
    public int filterOrder() {
        return 0;
    }

    public static void authUser(RequestContext ctx) {
        HttpServletRequest request = ctx.getRequest();
        Map<String, String> header = HttpConvertUtil.httpRequestToMap(request);
        String userId = header.get(User.CONTEXT_KEY_USERID);
        if (StringUtils.isEmpty(userId)) {
            try {
                BaseException BaseException = new BaseException(CommonError.AUTH_EMPTY_ERROR.getCode(), CommonError.AUTH_EMPTY_ERROR.getCodeEn(), CommonError.AUTH_EMPTY_ERROR.getMessage(), 1L);
                BaseExceptionBody errorBody = new BaseExceptionBody(BaseException);
                ctx.setSendZuulResponse(false);
                ctx.setResponseStatusCode(401);
                ctx.setResponseBody(JSONObject.toJSON(errorBody).toString());
            } catch (Exception e) {
                logger.error("println message error", e);
            }
        } else {
            for (Map.Entry<String, String> entry : header.entrySet()) {
                ctx.addZuulRequestHeader(entry.getKey(), entry.getValue());
            }
        }
    }

}
