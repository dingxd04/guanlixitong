using System;
using System.Web;
using System.Collections;
using System.IO;
using System.Text;

/// <summary> 
/// ReadFile 
/// </summary> 
public class ReadFile
{
    public ReadFile()
    {
        // 
        // TODO: Add constructor logic here 
        // 
    }
    public int[,] ReadFileToArray()
    {
        int[,] iret = null;
        ArrayList alNumLine = getFileContent();
        string[] strLineArr = null;
        if (alNumLine.Count > 0)
        {
            strLineArr = Convert.ToString(alNumLine[0]).Trim(',').Split('\n');
            iret = new int[alNumLine.Count, strLineArr.Length];
            for (int i = 0; i < alNumLine.Count; i++)
            {
                strLineArr = Convert.ToString(alNumLine[i]).Trim(',').Split(',');
                for (int j = 0; j < strLineArr.Length; j++)
                {
                    iret[i, j] = Convert.ToInt32(strLineArr[j]);
                }
            }
        }
        return iret;
    }
    public ArrayList getFileContent()
    {
        ArrayList alRet = new ArrayList();
        string strFilePath = HttpContext.Current.Server.MapPath("~") + "/array.txt";
        if (!File.Exists(strFilePath))
        {
            HttpContext.Current.Response.Write("文件[" + strFilePath + "]不存在。");
            return alRet;
        }
        try
        {
            //读出一行文本，并临时存放在ArrayList中 
            StreamReader sr = new StreamReader(strFilePath, Encoding.GetEncoding("gb2312"));
            string l;
            while ((l = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(l.Trim()))
                    alRet.Add(l.Trim());
            }
            sr.Close();
        }
        catch (IOException ex)
        {
            HttpContext.Current.Response.Write("读文件出错！请检查文件是否正确。");
            HttpContext.Current.Response.Write(ex.ToString());
        }
        return alRet;
    }
}
