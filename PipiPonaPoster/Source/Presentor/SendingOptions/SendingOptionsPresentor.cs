using System;

using PipiPonaPoster.Source.View;
using PipiPonaPoster.Source.Model;
using PipiPonaPoster.Source.Model.SendingOptions;

namespace PipiPonaPoster.Source.Presentor
{
    public class SendingOptionsPresentor : ISendingOptionsPresentor
    {
        private readonly ISendingOptionsView _view;
        private readonly ISendingOptionsService _model;

        public event Action OptionsChanged;

        public SendingOptionsPresentor()
        {
            _view = new SendingOptionsForm();
            _model = new SendingOptionsService();

            _view.SaveOptionsChanges += View_SaveOptionChanges;
        }

        public void Run()
        {
            _view.ShowExistingSettings(Program.sendingOptions);
            _view.Open();
        }


        private void View_SaveOptionChanges(object sender, EventArgs e)
        {
            SendingOptionsDataString fields = _view.GetRequiredFieldsInputData();
            OptionsSaveChangesResponse result = _model.HandleSaveChangesRequest(fields);

            // Если ошибок нет, то нужно активировать событие
            // до обработки запроса _вьюшкой настроек_
            if (!result.HasErrors)
                OptionsChanged.Invoke();

            _view.HandleSaveChangesResponse(result);
        }
    }
}
