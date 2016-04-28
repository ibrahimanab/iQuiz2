using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;




namespace GeekQuiz.Models
{
    public class Rules
    {
        [ScaffoldColumn(false)]
        public int RulesID { get; set; }
        [Required]
        [Display(Name = "number of question")]
        public int NumOfQuestion { get; set; }

        [Display(Name = "time per qustion")]
        public int timeperquestion { get; set; }

       
    }
}
