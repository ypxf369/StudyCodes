import redis.RedisUtil;
import redis.clients.jedis.Jedis;
import redis.clients.jedis.Transaction;

import java.util.List;
import java.util.Set;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 * Created by yepeng on 2019/04/20.
 * <p>
 * redis乐观锁实例
 */
public class OptimisticLockTest {
    public static void main(String[] args) {
        long starTime = System.currentTimeMillis();

        initProduct();
        initClient();
        printResult();

        long enTime = System.currentTimeMillis();
        long time = enTime - starTime;
        System.out.println("程序运行时间：" + time + "ms");
    }


    /**
     * 打印结果
     */
    public static void printResult() {
        Set<String> set = RedisUtil.getInstance().smembers("clientList");

        int i = 1;
        for (String value : set) {
            System.out.println("第" + i++ + "个抢到商品，" + value + " ");
        }
    }

    /**
     * 初始化客户开始抢商品
     */
    public static void initClient() {
        ExecutorService executorService = Executors.newCachedThreadPool();
        int clientNum = 20; //模拟客户数目
        for (int i = 0; i < clientNum; i++) {
            executorService.execute(new ClientThread(i));
        }
        executorService.shutdown();

        while (true) {
            if (executorService.isTerminated()) {
                System.out.println("所有的线程都结束了！");
                break;
            }
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    /**
     * 初始化商品个数
     */
    public static void initProduct() {
        int prdNum = 10;// 商品个数
        String key = "prdNum";
        String clientList = "clientList";// 抢购到商品的顾客列表
        Jedis jedis = RedisUtil.getInstance().getJedis();

        if (jedis.exists(key)) {
            jedis.del(key);
        }

        if (jedis.exists(clientList)) {
            jedis.del(clientList);
        }

        jedis.set(key, String.valueOf(prdNum));// 初始化
        //RedisUtil.returnResource(jedis);
    }

}

/**
 * 顾客线程
 */
class ClientThread implements Runnable {
    Jedis jedis;
    String key = "prdNum";// 商品主键
    String clientList = "clientList";// 抢购到商品的顾客主键列表
    String clientName;

    public ClientThread(int num) {
        clientName = "编号=" + num;
        jedis = RedisUtil.getInstance().getJedis();
    }

    public void run() {
        try {
            Thread.sleep((int) (Math.random() * 5000));// 随机睡眠一下
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        while (true) {
            System.out.println("顾客：" + clientName + "开始抢购商品");

            try {
                jedis.watch(key);
                int prdNum = Integer.parseInt(jedis.get(key));// 当前商品个数
                if (prdNum > 0) {
                    Transaction transaction = jedis.multi();
                    transaction.set(key, String.valueOf(prdNum - 1));
                    List<Object> result = transaction.exec();
                    if (result == null || result.isEmpty()) {
                        // 可能是watch-key被外部修改，或者是数据操作被驳回
                        System.out.println("悲剧了，顾客" + clientName + "没有抢到商品");
                    } else {
                        // 抢到商品记录一下
                        jedis.sadd(clientList, clientName);
                        System.out.println("恭喜顾客" + clientName + "抢到了商品");
                        break;
                    }
                } else {
                    break;
                }
            } catch (Exception e) {
                e.printStackTrace();
            } finally {
                jedis.unwatch();
                //RedisUtil.returnResource(jedis);
            }
        }
    }
}
