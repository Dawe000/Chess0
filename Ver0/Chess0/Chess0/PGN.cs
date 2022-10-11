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

        public PGN(string iWhite, string iBlack, string iEvent = "Chess0 Game", string iSite = "Chess0", DateTime iDate = default, int iRound = 1, string iResult = "*")
        {
            Event = iEvent;
            Site = iSite;

        }
    }
}
