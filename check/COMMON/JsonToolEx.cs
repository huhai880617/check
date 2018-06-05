using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
