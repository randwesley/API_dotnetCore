using System;
using System.Collections.Generic;
using System.Text;

namespace Randerson.Application.Commands.CustomerGeneric
{

    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
