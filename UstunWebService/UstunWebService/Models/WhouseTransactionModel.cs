using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UstunWebService.Models
{
    public class WhouseTransactionModel
    {
        public int ProjectTransactionId { get; set; }
        public int IndependentEntryTransactionId { get; set; }
        public int IndependentOutTransactionId { get; set; }
        public int WhouseTransferTransactionId { get; set; }
        public int WhouseCountingTransactionId { get; set; }
    }
}