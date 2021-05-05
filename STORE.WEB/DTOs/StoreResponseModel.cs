using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.DTOs
{
    public class StoreResponseModel<Tentity> where Tentity : class
    {
        public Tentity Response { get; set; }
        public String StatusCode { get; set; }
        public String IsSuccess { get; set; }
        public String Message { get; set; }
    }
}
