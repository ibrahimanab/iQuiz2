using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekQuiz.Models
{
    public class UserAtrr
    {
        public string userID { get; set; }

        public bool cratedGame { get; set; }

        public int?  startTime { get; set; }

        public int? endTime { get; set; }
    }
}
