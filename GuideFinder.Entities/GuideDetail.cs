using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideFinder.Entities
{

    public class GuideDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GuideId { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(250)]
        public string Location { get; set; }
        [StringLength(250)]
        public string Explanation { get; set; }
    }
}