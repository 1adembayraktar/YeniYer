
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models

{
    public class RequestModel
    {

        [Display(Name = "Request ID")]
        public int ID { get; set; }

        [Display(Name = "Request Status")]
        public int Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM.DD.YYYY}")]
        [Display(Name = "Latest Offer Date")]
        public DateTime due_date { get; set; }




    }
}
