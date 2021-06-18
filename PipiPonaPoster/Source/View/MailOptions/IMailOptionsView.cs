using System;

using PipiPonaPoster.Source.Model;
using PipiPonaPoster.Source.Model.MailOptions;

namespace PipiPonaPoster.Source.View
{
    public interface IMailOptionsView : IView
    {
        event EventHandler SaveOptionsChanges;

        void ShowExistingSettings(MailOptionsData settings);
        MailOptionsDataString GetRequiredFieldsInputData();
        void HandleSaveChangesResponse(OptionsSaveChangesResponse result);
    }
}
