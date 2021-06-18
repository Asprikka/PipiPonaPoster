using System;
using System.Threading.Tasks;

using PipiPonaPoster.Source.Enums;
using PipiPonaPoster.Source.Model.MainMenu;

namespace PipiPonaPoster.Source.Model
{
    public interface IMainMenuService : IService
    {
        event Action<OnlineStatsArgs> OnlineStatsChanged;
        event Action<TimeSpan> TimeLeftUntilEndChanged;
        event Action<string> OutputTerminalUpdated;
        event Func<string, Task> OutputTerminalUpdatedAsync;
        event Action<int> ProgressBarUpdated;
        event Func<int, Task> ProgressBarUpdatedAsync;
        event Action MailingFinished;
        event Action MailingTerminated;
        event Action PreparingFinished;

        Task StartNewMailingAsync();
        Task ContinueMailingAsync(ContinueMode mode);
        void PauseMailing();
        void TerminateMailing();
        void OnRunMailingConfirmation(ConfirmationState confirm);
    }
}
