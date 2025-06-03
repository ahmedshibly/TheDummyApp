using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDummyApp.FPractices.AImmutability.Models
{
    public class ImmutableReport
    {
        public string Title { get; } 

        public ImmutableReport(string title)
        {
            Title = title;
        }

        public ImmutableReport WithFinalizedTitle()
        {
            return new ImmutableReport(Title.Replace("(Draft)", "(Final)"));
        }
    }
}
