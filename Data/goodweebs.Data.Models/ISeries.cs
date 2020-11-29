using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public interface ISeries
    {
        int Id { set; }

        string Title { set; }


        int CurrentCount { set; }


        int FinishedCount { set; }

      
    }
}
