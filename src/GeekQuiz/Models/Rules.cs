using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekQuiz.Models
{
    public class Rules
    {
        [ DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RulesID { get; set; }
        
        [Display(Name = "number of question")]
        public int NumOfQuestion { get; set; }

        [Display(Name = "time per qustion")]
        public int timeperquestion { get; set; }

       
    }
}
