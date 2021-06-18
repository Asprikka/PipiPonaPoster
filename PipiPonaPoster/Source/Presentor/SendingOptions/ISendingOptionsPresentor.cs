using System;

namespace PipiPonaPoster.Source.Presentor
{
    interface ISendingOptionsPresentor : IPresentor
    {
        public event Action OptionsChanged;
    }
}
