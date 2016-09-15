using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cq.Features.CommandStore
{
    public class SerializedCommand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Json { get; set; }
        public DateTime StoredAt { get; set; }
    }
}