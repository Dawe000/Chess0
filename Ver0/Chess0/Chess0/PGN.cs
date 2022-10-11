using System;
using System.Collections.Generic;
using System.Text;

namespace Chess0
{
    public class PGN
    {
        private string Event { get; set; }
        private string Site { get; set; }
        private DateTime Date { get; set; }
        private int Round { get; set; }
        private string White { get; set; }
        private string Black { get; set; }
        private string Result { get; set; }

        public PGN(string White, string Black, string Event = "Chess0 Game", string Site = "Chess0", DateTime Date = DateTime.Now, )
        {

        }
    }
}
