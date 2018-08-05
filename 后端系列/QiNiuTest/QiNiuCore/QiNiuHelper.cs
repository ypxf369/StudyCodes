using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Qiniu.Auth.digest;
using Qiniu.Conf;
using Qiniu.IO;
using Qiniu.IO.Resumable;
using Qiniu.RPC;
using Qiniu.RS;
using Qiniu.RSF;
using Qiniu.Util;

namespace QiNiuCore
{
    public class QiNiuHelper
    {
        private static readonly string _bucket = "test";
        private static readonly string _domain;
        //private readonly string _qiniuDomain;
        //private static readonly Mac _mac;
        //private readonly BucketManager _bm;
        //private readonly Auth _auth;
        //private readonly HttpManager _httpManager;
        static QiNiuHelper()
        {
            Config.ACCESS_KEY = "giahtqQ2Iuhvv3O1q7jzY8XzkQCDz8NGMkXXIeL4";
            Config.SECRET_KEY = "ejDxTAqeXQYITYHi5xII3jbKcLYwfLeArqFGcxCB";
            Config.API_HOST = "pcyzulxo0.bkt.clouddn.com";
            _domain = Config.API_HOST;
            Config.Init();
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileName">文件名，img.jpg</param>
        /// <param name="stream">文件流</param>
        /// <returns>文件外链</returns>
        public static async Task<string> PutAsync(string fileName, Stream stream)
        {
            PutPolicy policy = new PutPolicy(_bucket, 3600);
            PutExtra extra = new PutExtra();
            IOClient client = new IOClient();

            string upToken = policy.Token();
            //{"Hash":"FitWtFODTKK9qlXzOqHi7cpQgLFp","key":"LR6MCJ3YZ3T2.jpg","StatusCode":200,"Exception":null,"Response":"{\"hash\":\"FitWtFODTKK9qlXzOqHi7cpQgLFp\",\"key\":\"LR6MCJ3YZ3T2.jpg\"}","OK":true}
            var putRet = await client.PutAsync(upToken, fileName, stream, extra);
            return putRet.StatusCode == HttpStatusCode.OK ? $"{Config.API_HOST}/{putRet.key}" : null;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="localFile">文件路径</param>
        /// <returns>文件外链</returns>
        public static async Task<string> PutFileAsync(string localFile)
        {
            var policy = new PutPolicy(_bucket, 3600);
            string upToken = policy.Token();
            PutExtra extra = new PutExtra();
            IOClient client = new IOClient();
            var putRet = await client.PutFileAsync(upToken, new FileInfo(localFile).Name, localFile, extra);
            return putRet.StatusCode == HttpStatusCode.OK ? $"{Config.API_HOST}/{putRet.key}" : null;
        }

        /// <summary>
        /// 断点续传
        /// </summary>
        /// <param name="localFile"></param>
        /// <returns></returns>
        public static async Task<string> ResumablePutFileAsync(string localFile)
        {
            PutPolicy policy = new PutPolicy(_bucket, 3600);
            string upToken = policy.Token();
            Settings setting = new Settings();
            ResumablePutExtra extra = new ResumablePutExtra();
            ResumablePut client = new ResumablePut(setting, extra);
            CallRet callRet = await client.PutFileAsync(upToken, localFile, new FileInfo(localFile).Name);
            return callRet.StatusCode == HttpStatusCode.OK ? $"{Config.API_HOST}/{((dynamic)JObject.Parse(callRet.Response)).key}" : null;
        }

        /// <summary>
        /// Amr文件转Mp3
        /// </summary>
        /// <param name="fileName">文件名，aa.amr</param>
        /// <param name="stream">文件流</param>
        /// <param name="notifyUrl">七牛转码成功后用于接收通知的url</param>
        /// <returns>文件外链</returns>
        public static async Task<string> PutAmrToMp3Async(string fileName, Stream stream, string notifyUrl)
        {
            PutPolicy policy = new PutPolicy(_bucket, 3600);
            PutExtra extra = new PutExtra();
            IOClient client = new IOClient();

            //对转码后的文件进行使用saveas参数自定义命名，也可以不指定,文件会默认命名并保存在当前空间。
            fileName = fileName.Split('.')[0] + ".mp3";
            string urlbase64 = Base64URLSafe.Encode(_bucket + ":" + fileName);

            //一般指文件要上传到的目标存储空间（Bucket）。若为“Bucket”，
            //表示限定只能传到该Bucket（仅限于新增文件）；若为”Bucket:Key”，表示限定特定的文件，可修改该文件。
            policy.Scope = _bucket + ":" + fileName;
            // 可选。 若非0, 即使Scope为 Bucket:Key 的形式也是insert only.
            policy.InsertOnly = 0;
            // "|"竖线前是你要转换格式的命令；竖线后是转换完成后，文件的命名和存储的空间的名称！
            policy.PersistentOps = "avthumb/mp3/ab/128k/ar/44100/acodec/libmp3lame|saveas/" + urlbase64;
            //规定文件要在那个“工厂”进行改装，也就是队列名称！
            //policy.PersistentPipeline = "LittleBai";
            //音视频转码持久化完成后，七牛的服务器会向用户发送处理结果通知。这里指定的url就是用于接收通知的接口。
            //设置了`persistentOps`,则需要同时设置此字段
            policy.PersistentNotifyUrl = "http://wwwtest.rupeng.cn:9090/upload/uploadFile";

            string upToken = policy.Token();
            var putRet = await client.PutAsync(upToken, fileName, stream, extra);
            return putRet.StatusCode == HttpStatusCode.OK ? $"{Config.API_HOST}/{putRet.key}" : null;
        }

        /// <summary>
        /// 获得文件下载链接
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static string Download(string fileName)
        {
            string baseUrl = GetPolicy.MakeBaseUrl(_domain, fileName);
            string privateUrl = GetPolicy.MakeRequest(baseUrl);
            return privateUrl;
        }

        /// <summary>
        /// 查看单个文件的属性信息
        /// </summary>
        /// <param name="fileName">文件名。aa.jpg</param>
        /// <returns></returns>
        public static async Task StatAsync(string fileName)
        {
            RSClient client = new RSClient();
            Entry entry = await client.StatAsync(new EntryPath(_bucket, fileName));
            if (entry.OK)
            {
                Console.WriteLine("Hash: " + entry.Hash);
                Console.WriteLine("Fsize: " + entry.Fsize);
                Console.WriteLine("PutTime: " + entry.PutTime);
                Console.WriteLine("MimeType: " + entry.MimeType);
                Console.WriteLine("Customer: " + entry.Customer);
            }
            else
            {
                Console.WriteLine("Failed to Stat");
            }
        }

        /// <summary>
        /// 批量查看文件的属性信息
        /// </summary>
        /// <param name="fileNames">文件名集合。aa.jpg</param>
        /// <returns></returns>
        public static async Task BatchStatAsync(IEnumerable<string> fileNames)
        {
            RSClient client = new RSClient();
            List<BatchRetItem> entryList = await client.BatchStatAsync(fileNames.Select(i => new EntryPath(_bucket, i)).ToArray());
            foreach (var entry in entryList)
            {
                Console.WriteLine("Hash: " + entry.data.Hash);
                Console.WriteLine("Fsize: " + entry.data.FSize);
                Console.WriteLine("PutTime: " + entry.data.PutTime);
                Console.WriteLine("MimeType: " + entry.data.Mime);
                Console.WriteLine("Customer: " + entry.data.EndUser);
            }
        }

        /// <summary>
        /// 复制单个文件
        /// </summary>
        /// <param name="bucketSrc">需要复制的文件所在的空间名</param>
        /// <param name="fileNameSrc">需要复制的文件名</param>
        /// <param name="bucketDest">目标文件所在的空间名</param>
        /// <param name="fileNameDest">目标文件名</param>
        public static async Task<bool> CopyAsync(string bucketSrc, string fileNameSrc, string bucketDest, string fileNameDest)
        {
            RSClient client = new RSClient();
            CallRet ret = await client.CopyAsync(new EntryPathPair(bucketSrc, fileNameSrc, bucketDest, fileNameDest));
            return ret.OK;
        }

        /// <summary>
        /// 批量复制文件
        /// </summary>
        /// <param name="batchObjs"></param>
        /// <returns></returns>
        public static async Task<bool> BatchCopyAsync(IEnumerable<BatchObj> batchObjs)
        {
            RSClient client = new RSClient();
            CallRet ret = await client.BatchCopyAsync(batchObjs.Select(i => new EntryPathPair(i.BucketSrc, i.FileNameSrc, i.BucketDest, i.FileNameDest)).ToArray());
            return ret.OK;
        }

        /// <summary>
        /// 移动单个文件
        /// </summary>
        /// <param name="bucketSrc">需要移动的文件所在的空间名</param>
        /// <param name="keySrc">需要移动的文件</param>
        /// <param name="bucketDest">目标文件所在的空间名</param>
        /// <param name="keyDest">目标文件</param>
        public static async Task<bool> MoveAsync(string bucketSrc, string keySrc, string bucketDest, string keyDest)
        {
            Console.WriteLine("\n===> Move {0}:{1} To {2}:{3}",
            bucketSrc, keySrc, bucketDest, keyDest);
            RSClient client = new RSClient();
            CallRet ret = await client.MoveAsync(new EntryPathPair(bucketSrc, keySrc, bucketDest, keyDest));
            return ret.OK;
        }

        /// <summary>
        /// 批量移动文件
        /// </summary>
        /// <param name="batchObjs"></param>
        /// <returns></returns>
        public static async Task<bool> BatchMoveAsync(IEnumerable<BatchObj> batchObjs)
        {
            RSClient client = new RSClient();
            CallRet ret = await client.BatchMoveAsync(batchObjs.Select(i => new EntryPathPair(i.BucketSrc, i.FileNameSrc, i.BucketDest, i.FileNameDest)).ToArray());
            return ret.OK;
        }

        /// <summary>
        /// 删除单个文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        public static async Task<bool> DeleteAsync(string fileName)
        {
            RSClient client = new RSClient();
            CallRet ret = await client.DeleteAsync(new EntryPath(_bucket, fileName));
            return ret.OK;
        }

        /// <summary>
        /// 删除单个文件
        /// </summary>
        /// <param name="fileNames">文件名集合</param>
        public static async Task<bool> BatchDeleteAsync(IEnumerable<string> fileNames)
        {
            RSClient client = new RSClient();
            CallRet ret = await client.BatchDeleteAsync(fileNames.Select(i => new EntryPath(_bucket, i)).ToArray());
            return ret.OK;
        }

        /// <summary>
        /// 获取bucket下的文件列表
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="markerIn"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<string>> ListAsync(string prefix = "", string markerIn = "", int limit = 0)
        {
            RSFClient client = new RSFClient(_bucket);
            DumpRet dumpRet = await client.ListPrefixAsync(_bucket, prefix, markerIn, limit);
            return dumpRet.Items.Select(i => i.Key);
        }

        #region 数据处理接口，待完善
        /*
         
            数据处理接口
服务端或客户端使用。

七牛支持在云端对图像, 视频, 音频等富媒体进行个性化处理。使用数据处理接口需要引入Qiniu.FileOp命名空间。

using Qiniu.FileOp;

图像

查看图像属性
	string domain = "domain";
	string key = key;
	Console.WriteLine("\n===> FileOp.ImageInfo");
	//生成base_url
	string url = Qiniu.RS.GetPolicy.MakeBaseUrl(domian, key);
	//生成fop_url
	string imageInfoURL = ImageInfo.MakeRequest(url);
	//对其签名，生成private_url。如果是公有bucket此步可以省略
	imageInfoURL = GetPolicy.MakeRequest(imageInfoURL);
	ImageInfoRet infoRet = ImageInfo.Call(imageInfoURL);
	if (infoRet.OK)
	{
		Console.WriteLine("Format: " + infoRet.Format);
		Console.WriteLine("Width: " + infoRet.Width);
		Console.WriteLine("Heigth: " + infoRet.Height);
		Console.WriteLine("ColorModel: " + infoRet.ColorModel);
	}
	else
	{
		Console.WriteLine("Failed to ImageInfo");
	}

查看图片EXIF信息
	string exifURL = Exif.MakeRequest(url);
	ExifRet exifRet = Exif.Call(exifURL);
	if (exifRet.OK)
	{
		Console.WriteLine("ApertureValue.val: " + exifRet["ApertureValue"].val);
		Console.WriteLine("ApertureValue.type: " + exifRet["ApertureValue"].type.ToString());
		Console.WriteLine("ExifInfo: " + exifRet.ToString());
	}
	else
	{
	    Console.WriteLine("Failed to ImageExif");
	}

生成图片预览
	ImageView imageView = new ImageView { Mode = 0, Width = 200, Height = 200, Quality = 90, Format = "gif" };
	string viewUrl = imageView.MakeRequest(url);
	viewUrl = GetPolicy.MakeRequest(viewUrl);
	Console.WriteLine("ImageViewURL:" + viewUrl);

图片高级处理(缩略、裁剪、旋转、转化)
	ImageMogrify imageMogr = new ImageMogrify
	{
		Thumbnail = "!50x50r",
		Gravity = "center",
		Rotate = 90,
		Crop = "!50x50",
		Quality = 80,
		AutoOrient = true
	};
	string mogrUrl = imageMogr.MakeRequest(url);
	mogrUrl = GetPolicy.MakeRequest(mogrUrl);
	Console.WriteLine("ImageMogrifyURL:" + mogrUrl);

图像水印接口
	//文字水印
	WaterMarker marker = new TextWaterMarker("hello,qiniu cloud!","","red");
	string MarkerUrl = marker.MakeRequest(url);
	//图片水印
	marker = new ImageWaterMarker("http://www.b1.qiniudn.com/images/logo-2.png");
	MarkerUrl = marker.MakeRequest(url);

         */
        #endregion
    }

    public class BatchObj
    {
        public string BucketSrc { get; set; }
        public string BucketDest { get; set; }
        public string FileNameSrc { get; set; }
        public string FileNameDest { get; set; }
    }
}
