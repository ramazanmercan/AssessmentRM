using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuideFinder.API.Model
{
    public class ReportType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Location { get; set; }
        public int NumberOfContacts { get; set; }
        public int NumberOfPhoneNumbers { get; set; }
        public Guid? UUID { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Status { get; set; }

    }
}
