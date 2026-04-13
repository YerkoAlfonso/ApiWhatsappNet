using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace WhatsaapNet.Api.Services.WhatsAppCloud.SendMessage
{
    public class WhatsappCloudSendMessage: IWhatsappCloudSendMessage
    {

        public async Task<bool> Execute(object model)
        {
            var client = new HttpClient();
            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

            using (var content = new ByteArrayContent(byteData))
            {
                string endpoint = "https://graph.facebook.com";
                string phoneNumberId = "1015437081660646";
                string accesToken = "EAAL7CHnXe1QBRL2U8YqAn2PAIZALnZCkrkKh5Rge2mroWVAz9iEH8W6Jo7UdUU5BqdZATVIcPzZBBFPiWSZCa0nPFqqu9yav1HD4TY5HHm40odntUs90xM7IFbhSIFF3ojZAX2ZB5Mv1QfSh7y7HCEREF8rZC3JRvEMtXZAsZCVWn1cwg5696ht3NHZBInZBkuNRJxPlCwZDZD";
                string uri = $"{endpoint}/v22.0/{phoneNumberId}/messages";

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                client.DefaultRequestHeaders.Add("Authorization",$"Bearer {accesToken}");

                var response = await client.PostAsync(uri,content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
                

            }
        }
    }
}
