using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CF.ProjectService.Application.Entities.Base
{
    public class BaseEntity
    {
       
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public Guid CreatedByUserId { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public Guid? DeletedByUserId { get; set; }

       
        public AppUser CreatedByUser { get; set; }
        public AppUser ModifiedByUser { get; set; }
        public AppUser DeletedByUser { get; set; }
    }
}
