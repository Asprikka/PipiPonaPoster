using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using PipiPonaPoster.Source.Enums;
using PipiPonaPoster.Source.View;
using PipiPonaPoster.Source.Model;
using PipiPonaPoster.Source.Model.MainMenu;

namespace PipiPonaPoster.Source.Presentor
{
    public class MainMenuPresentor : IMainMenuPresentor
    {
        private readonly IMainMenuView _view;
        private readonly IMainMenuService _model;


        public MainMenuPresentor()
        {
            _model = new MainMenuService();
            _view = new MainMenuForm();

            _view.StartNewMailing_OnClick += View_StartNewMailing_OnClick;
            _view.ContinueMailing_OnClick += View_ContinueMailing_OnClick;

            _view.PauseMailing_OnClick += () => _model.PauseMailing();
            _view.TerminateMailing_OnClick += () => _model.TerminateMailing();
            _view.RunMailingConfirmation += (ConfirmationState confirm) => _model.OnRunMailingConfirmation(confirm);

            _model.OnlineStatsChanged += (OnlineStatsArgs e) => _view.UpdateOnlineStats(e);
            _model.TimeLeftUntilEndChanged += (TimeSpan e) => _view.UpdateTimeLeftUntilEndLabel(e);
            _model.OutputTerminalUpdated += (string e) => _view.UpdateOutputTerminal(e);
            _model.ProgressBarUpdated += (int step) => _view.UpdateProgressBar(step);

            _model.MailingFinished += () => _view.OnMailingFinished();
            _model.MailingTerminated += () => _view.OnMailingTerminated();
            _model.PreparingFinished += () => _view.OnPreparingFinished();

            _model.OutputTerminalUpdatedAsync += (string e) => _view.UpdateOutputTerminalAsync(e);
            _model.ProgressBarUpdatedAsync += (int step) => _view.UpdateProgressBarAsync(step);
        }

        public void Run() => _view.Open();

        private async Task View_StartNewMailing_OnClick()
        {
            try { await _model.StartNewMailingAsync(); }
            catch (Exception ex) {
                MessageBox.Show("Перезапустите рассылку заново!\n\n" + ex.ToString(),
                    "Неизвестная ошибка!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task View_ContinueMailing_OnClick(ContinueMode mode)
        {
            try { await _model.ContinueMailingAsync(mode); }
            catch (Exception ex) {
                MessageBox.Show("Перезапустите рассылку заново!\n\n" + ex.ToString(), 
                    "Неизвестная ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
