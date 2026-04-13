namespace WhatsaapNet.Api.Services.WhatsAppCloud.SendMessage
{
    public interface IWhatsappCloudSendMessage
    {
        Task<bool> Execute(object model);
    }
}
