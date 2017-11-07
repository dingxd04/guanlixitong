//需要用到的命名空间
using System;
using System.IO;
using System.Net;
using System.Text;

/// <summary>
///SMS 发送短信类
/// </summary>
public class SMS
{
    public SMS()
    {
    }
    //调用时只需要把调用地址拼成的URL传给该函数即可。判断返回值即可
    public string GetHtmlFromUrl(string url)
    {
        string strRet = null;

        if (url == null || url.Trim().ToString() == "")
        {
            return strRet;
        }
        string targeturl = url.Trim().ToString();
        try
        {
            HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
            hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
            hr.Method = "GET";
            hr.Timeout = 30 * 60 * 1000;
            WebResponse hs = hr.GetResponse();
            Stream sr = hs.GetResponseStream();
            StreamReader ser = new StreamReader(sr, System.Text.Encoding.Default);
            strRet = "<br/>resp=" + ser.ReadToEnd();
        }
        catch (Exception ex)
        {
            strRet = null;
        }
        return strRet;
    }

}
