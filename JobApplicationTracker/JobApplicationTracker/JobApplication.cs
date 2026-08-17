using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker
{
    public class JobApplication
    {
        // Properties to hold the details of a job application
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string WorkModel { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
    }
}