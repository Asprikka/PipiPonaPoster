using System;

using PipiPonaPoster.Source.Model;
using PipiPonaPoster.Source.Model.SendingOptions;

namespace PipiPonaPoster.Source.View
{
    public interface ISendingOptionsView : IView
    {
        event EventHandler SaveOptionsChanges;

        void ShowExistingSettings(SendingOptionsData settings);
        SendingOptionsDataString GetRequiredFieldsInputData();
        void HandleSaveChangesResponse(OptionsSaveChangesResponse result);
    }
}
