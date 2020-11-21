using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public interface ISeries
    {
        int Id { set; }
        string Title { set; }

        int Genre { set; }


        int CurrentCount { set; }


        int FinishedCount { set; }


        bool IsFinished { set; }


        DateTime DateStarted { set; }

        DateTime DateFinished { set; }

    }
}
