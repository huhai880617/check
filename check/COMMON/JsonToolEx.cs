using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace check
{
    ///<summary>

    ///主要使用了Newtonsoft.Json使用了对象与Json字符串之间的互转

    ///</summary>

    public class JsonToolEx

    {

        public static string ToJson(object obj, string dateTimeFormat = "yyyy-MM-dd")

        {

            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();

            timeConverter.DateTimeFormat = dateTimeFormat;

            return JsonConvert.SerializeObject(obj, timeConverter);

        }



        public static T ToObject<T>(string json)

        {

            return JsonConvert.DeserializeObject<T>(json);

        }

        //public static DataTable toDataTable(string[] columns, string json)
        //{
        //    DataTable dataTable = new DataTable();
        //    DataTable result;
        //    try
        //    {
        //        foreach (string s in columns)
        //        {
        //            dataTable.Columns.Add(s);
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        LogExecute.WriteExceptionLog("toDataTable",ex);
        //    }
        //    result = dataTable;
        //    return result;
        //}

    }
}
