using System;
using Dapper.Contrib.Extensions;

namespace ClaimViewApp.Models
{
    [Table("LossTypes")]
    public class LossTypeModel
    {
        public int LossTtypeId { get; set; }
        public string LossTypeCode { get; set; }
        public string LossTypeDescription { get; set; }
        public bool Active { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        [Key]
        public int CreatedId { get; set; }
    }
}
