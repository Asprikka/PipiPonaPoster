namespace PipiPonaPoster.Source.Model.SendingOptions
{
    public interface ISendingOptionsService : IService
    {
        OptionsSaveChangesResponse HandleSaveChangesRequest(SendingOptionsDataString fields);
    }
}
