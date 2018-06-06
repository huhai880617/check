using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check
{
    public class receiptAPI:API
    {
        public receiptAPI(string serverUrl)
        {
            server = serverUrl;
            controllerName = @"/rf/inbound/checkIn";

        }
        public ResponseReceiptEntity searchReceipt(string methed,string receiptCode,string prefCode)
        {
            string url = string.Format("{0}{1}/{2}?receiptCode={3}&prefCode={4}", server, controllerName, methed,receiptCode,prefCode);
            string str = TTX_WebAPI_Helper.getReturnJson(url);
            ResponseReceiptEntity rsp = JsonToolEx.ToObject<ResponseReceiptEntity>(str);
            return rsp;
        }


        public ResponseEntity checkReceiptContainer(string methed, string containerCodec)
        {
            string url = string.Format("{0}{1}/{2}?containerCodec={3}", server, controllerName, methed,containerCodec);
            string str = TTX_WebAPI_Helper.getReturnJson(url);
            ResponseEntity rsp = JsonToolEx.ToObject<ResponseEntity>(str);
            return rsp;
        }
        

        public ResponseEntity confirmReceipt(string methed,ReceiptConfirmRequest request)
        {
            string body = JsonToolEx.ToJson(request);
            string url = string.Format("{0}{1}/{2}", server, controllerName, methed);
            string str = TTX_WebAPI_Helper.postReturnJson(url, body);
            ResponseEntity rsp = JsonToolEx.ToObject<ResponseEntity>(str);
            return rsp;
        }
    }
}
