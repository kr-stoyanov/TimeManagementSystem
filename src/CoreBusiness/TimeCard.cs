﻿using CoreBusiness.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    [BsonIgnoreExtraElements]
    public class TimeCard
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        [BsonElement("project")]
        public string? ProjectName { get; set; }

        [Required]
        [MaxLength(1250)]
        [BsonElement("task")]
        public string? TaskName { get; set; }

        [MaxLength(2500)]
        [BsonElement("notes")]
        public string? Notes { get; set; }

        [BsonElement("status")]
        public TimeCardStatus Status { get; set; }

        [BsonElement("timeSpent")]
        public TimeSpan TimeSpent { get; set; }

        [BsonElement("createdBy")]
        public string? CreatedBy { get; set; }

        [BsonElement("userName")]
        public string? UserName { get; set; }

        [BsonElement("userId")]
        public Guid? UserId { get; set; }

        [BsonElement("createdOn")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("lastModifiedOn")]
        public DateTime LastModifiedOn { get; set; }

        [BsonElement("closedOn")]
        public DateTime ClosedOn { get; set; }
    }
}
