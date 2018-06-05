using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check
{
    //public class ResponseWarehouseMessage
    //{
    //    public ResponseWarehouseEntity responseMessage;
    //}

    public class ResponseWarehouseEntity:ResponseEntity
    {
        public List<ResponseWarehouse> data;
    }
    

    public class ResponseWarehouse
    {
        private string code;
        private string name;
        private bool flag;

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool Flag
        {
            get
            {
                return flag;
            }

            set
            {
                flag = value;
            }
        }

        public ResponseWarehouse(string code, string name, bool flag)
        {
            this.Code = code;
            this.Name = name;
            this.Flag = flag;
        }
    }
}
