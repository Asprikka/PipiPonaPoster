using System;
using System.Threading.Tasks;

using PipiPonaPoster.Source.Enums;

namespace PipiPonaPoster.Source.View
{
    public interface IMainMenuView : IView
    {
        event Func<Task> StartNewMailing_OnClick;
        event Func<ContinueMode, Task> ContinueMailing_OnClick;
        event Action PauseMailing_OnClick;
        event Action TerminateMailing_OnClick;
        event Action<ConfirmationState> RunMailingConfirmation;

        void UpdateOnlineStats(Model.MainMenu.OnlineStatsArgs e);
        void UpdateTimeLeftUntilEndLabel(TimeSpan e);
        void UpdateOutputTerminal(string e);
        Task UpdateOutputTerminalAsync(string e);
        void UpdateProgressBar(int step);
        Task UpdateProgressBarAsync(int step);

        void OnPreparingFinished();
        void OnMailingFinished();
        void OnMailingTerminated();
        void OnOptionsChanged();
    }
}
