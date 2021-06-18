namespace PipiPonaPoster.Source.Model.MailOptions
{
    public interface IMailOptionsService : IService
    {
        OptionsSaveChangesResponse HandleSaveChangesRequest(MailOptionsDataString fields);
    }
}
