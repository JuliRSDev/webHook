using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WbHooksCroydon.Domain.Yuju.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string nickname { get; set; }
        public string customer_id { get; set; }
        public string doc_number { get; set; }
        public string doc_type { get; set; }
    }
}