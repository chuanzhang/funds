using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace funds
{
    [DataContract]
    class QueryResult
    {
        [DataMember(Order = 0, IsRequired = true)]
        public String errorInfo { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        public int errorNo { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public List<List<Object>> results{ get;set;}
}
}
