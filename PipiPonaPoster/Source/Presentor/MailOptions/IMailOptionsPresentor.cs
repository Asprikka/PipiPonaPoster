using System;

namespace PipiPonaPoster.Source.Presentor
{
    interface IMailOptionsPresentor : IPresentor
    {
        public event Action OptionsChanged;
    }
}
