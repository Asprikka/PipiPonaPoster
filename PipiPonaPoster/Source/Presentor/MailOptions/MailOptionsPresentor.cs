using System;

using PipiPonaPoster.Source.View;
using PipiPonaPoster.Source.Model;
using PipiPonaPoster.Source.Model.MailOptions;

namespace PipiPonaPoster.Source.Presentor
{
    public class MailOptionsPresentor : IMailOptionsPresentor
    {
        private readonly IMailOptionsView _view;
        private readonly IMailOptionsService _model;

        public event Action OptionsChanged;

        public MailOptionsPresentor()
        {
            _view = new MailOptionsForm();
            _model = new MailOptionsService();

            _view.SaveOptionsChanges += View_SaveOptionChanges;
        }

        public void Run()
        {
            _view.ShowExistingSettings(Program.mailOptions);
            _view.Open();
        }


        private void View_SaveOptionChanges(object sender, EventArgs e)
        {
            MailOptionsDataString fields = _view.GetRequiredFieldsInputData();
            OptionsSaveChangesResponse result = _model.HandleSaveChangesRequest(fields);

            // Если ошибок нет, то нужно активировать событие
            // до обработки запроса _вьюшкой настроек_
            if (!result.HasErrors)
                OptionsChanged.Invoke();

            _view.HandleSaveChangesResponse(result);
        }
    }
}