using System;
using System.Collections.Generic;
using System.Text;

namespace barcosFinal.Interfaces
{
    interface IBattleField
    {
        char[] Board { get; set; }
        void DrawBoard();
    }
}
