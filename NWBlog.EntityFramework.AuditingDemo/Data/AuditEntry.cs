using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NWBlog.EntityFramework.AuditingDemo.Data
{
    [Table(nameof(AuditEntry))]
    public class AuditEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string EntityName { get; set; }
        public string ActionType { get; set; }
        public string Username { get; set; }
        public DateTime TimeStamp { get; set; }
        public string EntityId { get; set; }
        public string Changes { get; set; }
    }
}
