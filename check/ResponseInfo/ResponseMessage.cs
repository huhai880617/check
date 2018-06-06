using System;
using System.Collections.Generic;
using System.Linq;

namespace check
{
    public class ResponseMessage<T> : ResponseEntity
    {
        public T data;
    }
}
