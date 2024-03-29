﻿using CoreBusiness;
using CoreBusiness.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class TimeCardViewModel : ITimeCardViewModel
    {
        public string Id { get; set; }

        public string? UserName { get; set; }

        public string? ProjectName { get; set; }

        [Required]
        [MaxLength(1250)]
        public string? TaskName { get; set; }

        [MaxLength(2500)]
        public string? Notes { get; set; }

        [Required]
        public TimeCardStatus Status { get; set; }

        public TimeSpan TimeSpent { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastModifiedOn { get; set; }

        public DateTime ClosedOn { get; set; }

        public bool IsRunning { get; set; }

        public TimeSpan StopwatchValue { get; set; }

        public TimeCard Transform() =>
            new()
            {
                Id = this.Id,
                UserName = this.UserName,
                ProjectName = this.ProjectName,
                TaskName = this.TaskName,
                Notes = this.Notes,
                Status = this.Status,
                TimeSpent = this.TimeSpent,
                CreatedBy = this.CreatedBy,
                CreatedOn = this.CreatedOn,
                LastModifiedOn = this.LastModifiedOn,
                ClosedOn = this.ClosedOn,
            };
    }
}
