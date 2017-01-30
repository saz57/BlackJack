using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace black_jack
{
    interface IDeck
    {
        Card GetCard();
        void Reset();
    }
}
