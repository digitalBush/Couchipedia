using System;
using Newtonsoft.Json;

namespace Importer {
    public class DatabaseStats {
        [JsonProperty("db_name")]
        public string Name { get; set; }

        [JsonProperty("doc_count")]
        public int DocumentCount { get; set; }

        [JsonProperty("doc_del_count")]
        public int DeletedDocumentCount { get; set; }

        [JsonProperty("update_seq")]
        public int UpdateCount { get; set; }

        [JsonProperty("purge_seq")]
        public int PurgeCount { get; set; }

        [JsonProperty("compact_running")]
        public bool IsCompactRunning { get; set; }

        [JsonProperty("disk_size")]
        public long DiskSize {get;set;}

        //[JsonProperty("instance_start_time")]
        public DateTime StartTime{get;set;}

        [JsonProperty("disk_format_version")]
        public string DiskFormatVersion{get;set;}

        [JsonProperty("committed_update_seq")]
        public int CommittedUpdateCount{get;set;}
    }
}
