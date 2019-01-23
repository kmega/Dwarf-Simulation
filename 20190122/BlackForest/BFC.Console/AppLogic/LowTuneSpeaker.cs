using BFC.Console.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFC.Console.AppLogic
{
    public class LowTuneSpeaker : Speaker
    {
        private IOutputWritter _presenter;
        public LowTuneSpeaker(IOutputWritter presenter)
        {
            _presenter = presenter ?? new WindowsConsole();
        }
        public void GenerateSound()
        {
            _presenter.WriteLine("Fireman generated alarm sound.");
        }
    }
}
