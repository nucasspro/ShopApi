using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Models
{
    public class CcTransaction
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public SalesOrder OrderId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Processor { get; set; }
        public string ProcessorTransactionId { get; set; }
        public int Amount { get; set; }
        public string CcNum { get; set; }
        public string CcType { get; set; }
        public string Response { get; set; }
        public DateTime InsertedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
