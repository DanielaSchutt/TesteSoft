using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteSoftDesign.Domain.Entity
{
    public abstract class AbstractEntity
    {
        [Key]
        public int Id { get; set; }
    }
}