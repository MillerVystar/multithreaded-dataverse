using System;
using System.Collections.Generic;

namespace DataverseBulkUpdater.Models
{
    public class RecordModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string EntityName { get; set; } // Added for DataverseService compatibility
        public Dictionary<string, object> Properties { get; set; } // Added for DataverseService compatibility
    }
}