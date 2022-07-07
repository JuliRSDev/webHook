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
        public object nickname { get; set; }
        public object customer_id { get; set; }
        public string doc_number { get; set; }
        public object doc_type { get; set; }
    }
}