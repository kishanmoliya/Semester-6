using System;
using System.Collections.Generic;

namespace TaskManagementSoftware.Areas.User_Registration.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? PersonAge { get; set; }
        public string? PersonStd { get; set; }
    }
}
