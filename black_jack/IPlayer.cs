using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace black_jack
{
    interface IPlayer
    {
        int Score { get; }
        void AskCard();
        void ShowHand();
        void Reset();
    }
}
