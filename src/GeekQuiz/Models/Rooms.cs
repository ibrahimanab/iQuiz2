using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekQuiz.Models
{
    public class Rooms
    {
        public enum Catrgory {
            SPORT=1,
            HISTORY=2,
            

        }

        [ DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RulesID { get; set; }
        
        [Display(Name = "number of question")]
        public int NumOfQuestion { get; set; }

        [Display(Name = "time per qustion")]
        public int timeperquestion { get; set; }

        public string player1id { get; set; }

        public string player2id { get; set; }

        public int lastquestionid { get; set; }

        public Catrgory catgory { get; set; }
    }
}
