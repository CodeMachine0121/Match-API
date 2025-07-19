using System;

namespace ESportsMatchTracker.API.Data.Entities
{
    public class ActionLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ActionType { get; set; }
        public string TableName { get; set; }
        public string RecordId { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

