﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace check
{
    public static class TTX_WebAPI_Helper
    {
        public static string user = "hjk";

        public static string db = "twms";

        public static string warehouse = "W200286";


        public static string getJson(string url)
        {
            StreamReader streamReader=null;
            string Rstring = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";
                request.Headers.Add("X-User", user);
                request.Headers.Add("X-DB", db);
                request.Headers.Add("x-params", warehouse);
                WebResponse response = (WebResponse)request.GetResponse();
                streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                Rstring = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                LogExecute.WriteExceptionLog("GET", ex);
            }
            return Rstring;
            
        }

        public static string postJson(string url, IDictionary<string, string> parameters)
        {
            StreamReader streamReader = null;
            string Rstring = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";
            //request.ContentType = "application/x-www-form-urlencoded";
          
            request.Headers.Add("X-User", user);
            request.Headers.Add("X-DB", db);
            request.Headers.Add("x-params", warehouse);
            //如果需要POST数据   
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
            }

            WebResponse response = (WebResponse)request.GetResponse();
            //  Stream myResponseStream = response.GetResponseStream();
            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            Rstring= streamReader.ReadToEnd();

            return Rstring;
        }
    }
}
