using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check
{
    //public class ResponseReceiptMessage
    //{
    //    public ResponseReceiptEntity responseMessage;
    //}

    public class ResponseReceiptEntity:ResponseEntity
    {
        public ResponseReceiptInfo data;
    }

    public class ResponseReceiptInfo
    {
        public int id;
        public string receiptCode;
        public string warehouseCode;
        public string companyCode;
        public int leadingSts;
        public int trailingSts;
        public int itemQty;
        public int totalQty;
        public int openQty;
        public string prefCode;
        public string autoAssignLPN;
        public List<Item> items;
        // public string receiptType;
       // public List<string> serialNumbers;
    }
    

    public class Item
    {
        public int id;
        public string itemCode;
        public List<string> barcodes;
        public string itemName;
        public int totalQty;
        public int openQty;
        public string unit;
        public string inventorySts;
        public Boolean allowOverReceiving;
        public Boolean isCtrSerialNumber;
        public Boolean isAttributeTemplate;
        public List<Unit> units;
        public List<Template> templates;
        public List<Dictionary<string,string>> inventoryStsList;
        //public string kitFlag;
    }
    public class Template
    {
        public string code;
        public string name;
        public string autoFill;
        public string autoFillFormat;
        public string pattern;
        public Boolean readOnly;

    }
    

    public class Unit
    {
        public string code;
        public string name;
        public string conventQty;
    }

    
}
