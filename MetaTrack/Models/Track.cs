using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MetaTrack.Models
{
    public class Track
    {
        public string Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime ActiveDate { get; set; }

    }
}
