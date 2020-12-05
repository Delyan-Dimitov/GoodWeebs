namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISeries
    {
        int Id { set; }

        string Title { set; }

        int CurrentCount { set; }

        int FinishedCount { set; }
    }
}
