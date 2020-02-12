using System;
using System.Collections.Generic;
using System.Text;

namespace KickDo.Options
{
    public class PersonRegistrationOption
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int? DobYear { get; set; }
        public int? DobMonth { get; set; }
        public int? DobDay { get; set; }
    }
}
