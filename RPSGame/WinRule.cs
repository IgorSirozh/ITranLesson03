using System;
using System.Collections.Generic;
using System.Text;

namespace RPSGame
{
    public class WinRule
    {
        public WinRule() { }      
        public string decideRPSWinner(int decider, int plMove, int pcMove)
        {
            if (plMove==pcMove)
                return "Draw";
            if (plMove > pcMove)
            {
                if ((plMove - pcMove) <= decider) { return "Win"; } else { return "Lose"; }
            }
            else 
            {
                if ((pcMove - plMove) <= decider) { return "Lose"; } else { return "Win"; }
            }
        }
    }
}
