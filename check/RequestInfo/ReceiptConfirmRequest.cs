using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check
{
  public  class ReceiptConfirmRequest
    {
        public string receiptCode;
        public string prefCode;
        public string containerCodec;
        //public string receivingCartId;
        public List<ReceiptConfirmRequest.Item> items;
        

        public class Item
        {
            public string itemCode;
            public int qty;
            public string unit;
            public string inventorySts;
            public Dictionary<string, string> templateValue;
            public List<string> serialNumbers;
        }
    }
}
