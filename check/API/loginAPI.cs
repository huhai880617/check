using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check
{
    public class loginAPI:API
    {
        public loginAPI(string serverUrl)
        {
            server = serverUrl;
            controllerName = @"/rf/login";
            
        }
        public ResponseWarehouseEntity logInWarehouse(string methed)
        {
            string url = string.Format("{0}{1}/{2}", server, controllerName, methed);
            string str = TTX_WebAPI_Helper.getReturnJson(url);
            ResponseWarehouseEntity rsp = JsonToolEx.ToObject<ResponseWarehouseEntity>(str.Replace("default", "flag"));
            return rsp;
        }
    }
}
