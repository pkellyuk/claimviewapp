using System;
using Dapper.Contrib.Extensions;

namespace ClaimViewApp.Models
{
    [Table("Claims")]
    public class ClaimModel
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int LossAdjusterId { get; set; }
        public string Policy { get; set; }
        public DateTime LossDate { get; set; }
        public int LossTypeId { get; set; }
        [Computed]
        public string LossTypeDesc { get; set; }
        public string LossLoc { get; set; }
        public bool Closed { get; set; }
        public DateTime ClosedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        [ExplicitKey]
        public int CreatedId { get; set; }
    }
}
