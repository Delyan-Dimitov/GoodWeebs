using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Series : ISeries
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public int Genre { get; set; }
       
        public int CurrentCount { get; set; }
       
        public int FinishedCount { get; set; }
       
        public bool IsFinished { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime DateFinished { get; set; }
    }
}
