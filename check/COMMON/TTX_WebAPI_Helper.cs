﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Xml;

namespace check
{
    public static class TTX_WebAPI_Helper
    {
        public static string user = "hjk";

        public static string db = "twms";

        public static string warehouse = "W200286";


        public static string getReturnJson(string url)
        {
            StreamReader streamReader = null;
            string Rstring = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Proxy = null;
                request.Method = "GET";
               // request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";
                request.Headers.Add("X-User", user);
                request.Headers.Add("X-DB", db);
                WarehouseCode warehouseCode = new WarehouseCode(warehouse);
                string w = JsonConvert.SerializeObject(warehouseCode);
                request.Headers.Add("x-params", w);
                WebResponse response = (WebResponse)request.GetResponse();
                streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
               // XmlDocument doc = new XmlDocument();
                string s = streamReader.ReadToEnd();
                streamReader.Close();
                request.Abort();
                response.Close();
                // doc.LoadXml(s);
                //  Rstring = JsonConvert.SerializeXmlNode(doc);
                Rstring = s;
            }
            catch (Exception ex)
            {
                LogExecute.WriteExceptionLog("GET", ex);
            }
            return Rstring;

        }
        

        public static string postReturnJson(string url, IDictionary<string, string> parameters)
        {
            StreamReader streamReader = null;
            string Rstring = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
           // request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";
            //request.ContentType = "application/x-www-form-urlencoded";
            WarehouseCode warehousecode = new WarehouseCode(warehouse);
            request.Headers.Add("X-User", user);
            request.Headers.Add("X-DB", db);
            request.Headers.Add("x-params", JsonToolEx.ToJson(warehousecode));
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

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //  Stream myResponseStream = response.GetResponseStream();
            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
           
            Rstring = streamReader.ReadToEnd();
            streamReader.Close();
            request.Abort();
            response.Close();
            return Rstring;
        }

        //body是要传递的参数,格式"roleId=1&uid=2"
        //post的cotentType填写:
        //"application/x-www-form-urlencoded"
        //soap填写:"text/xml; charset=utf-8"
        public static string postReturnJson(string url, string body)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Proxy = null;
            httpWebRequest.ContentType = "application/json" ;
            httpWebRequest.Method = "POST";
           // httpWebRequest.Timeout = 20000;
            WarehouseCode warehousecode = new WarehouseCode(warehouse);
            httpWebRequest.Headers.Add("X-User", user);
            httpWebRequest.Headers.Add("X-DB", db);
            httpWebRequest.Headers.Add("x-params", JsonToolEx.ToJson(warehousecode));

            byte[] btBodys = Encoding.UTF8.GetBytes(body);
            httpWebRequest.ContentLength = btBodys.Length;
            httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();

            return responseContent;
        }

        private class WarehouseCode
        {
            private string _warehouse;
            public WarehouseCode(string Warehouse) {
                warehouse = Warehouse;
            }

            public string warehouse
            {
                get
                {
                    return _warehouse;
                }

                set
                {
                    _warehouse = value;
                }
            }
        }
    }
}


   
