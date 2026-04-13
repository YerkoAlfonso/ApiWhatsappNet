using Microsoft.AspNetCore.Mvc;
using WhatsaapNet.Api.Models.WhatsAppCloud;
using WhatsaapNet.Api.Services.WhatsAppCloud.SendMessage;
using WhatsaapNet.Api.Util;

namespace WhatsaapNet.Api.Controllers
{
    [ApiController]
    [Route("api/whatsaap")]
    public class WhatsappController : Controller
    {
        private readonly IWhatsappCloudSendMessage _whatsappCloudSendMessage;
        private readonly IUtil _util;
        public WhatsappController(IWhatsappCloudSendMessage whatsappCloudSendMessage,IUtil util)
        {
            _whatsappCloudSendMessage = whatsappCloudSendMessage;
            _util = util;
            
        }

        [HttpGet("test")]
        public  async Task<IActionResult> sample()
        {
            var data = new
            {
                messaging_product= "whatsapp",
                to = "56930784717",
                type= "text",
                text = new
                {
                    body = "Yepa "
                }
            };


            var result = await _whatsappCloudSendMessage.Execute(data);
            return Ok("Ok Sample");
        }

        [HttpGet]
        public IActionResult VerifyToken()
        {
            string AccessToken = "WJTM4GCwiAtOp9Bd284E";

            var token = Request.Query["hub.verify_token"].ToString();
            var challenge = Request.Query["hub.challenge"].ToString();


            if(!String.IsNullOrEmpty(challenge)  && !String.IsNullOrEmpty(token) && token == AccessToken)
            {
                return Ok(challenge);
            }

            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> ReceivedMessager([FromBody] WhatsAppCloudModel body)
        {
            try
            {
                var Message = body.Entry[0]?.Changes[0]?.Value?.Messages[0];

                if(Message != null)
                {
                    var userNumber = Message.From;
                    var userText = GetUserText(Message);

                    List<object> ListobjetMessage = new List<object>();

                    #region prueba
                    //switch (userText.ToUpper())
                    //{
                    //    case "TEXT":
                    //        objetMessage = _util.TextMessage("Test mensaje de texto", userNumber);
                    //        break;
                    //    case "COMPRAR":
                    //        objetMessage = _util.TextMessage("Seleccionaste comprar", userNumber);
                    //        break;
                    //    case "IMAGE":
                    //        objetMessage = _util.ImageMessage("https://biostoragecloud.blob.core.windows.net/resource-udemy-whatsapp-node/image_whatsapp.png", userNumber);
                    //        break;
                    //    case "AUDIO":
                    //        objetMessage = _util.AudioMessage("https://www.myinstants.com/media/sounds/por-fin-apareciste-malnacido-picoro.mp3", userNumber);
                    //        break;
                    //    case "VIDEO":
                    //        objetMessage = _util.VideoMessage("https://biostoragecloud.blob.core.windows.net/resource-udemy-whatsapp-node/video_whatsapp.mp4", userNumber);
                    //        break;
                    //    case "DOCUMENT":
                    //        objetMessage = _util.DocumentMessage("https://biostoragecloud.blob.core.windows.net/resource-udemy-whatsapp-node/document_whatsapp.pdf", userNumber);
                    //        break;
                    //     case "LOCATION":
                    //        objetMessage = _util.LocationMessage("-33.46741261958292", "-70.60987844107528","Estadio nacional", "Av. Grecia 2001, 7780464 Ñuñoa, Región Metropolitana", userNumber);
                    //        break;
                    //    case "BUTTON":
                    //        objetMessage = _util.ButtonsMessage("BOTONES", userNumber);
                    //        break;
                    //    default:
                    //        objetMessage = _util.TextMessage("Lo siento no puedo entenderte", userNumber);
                    //        break;
                    //}
                    #endregion

                    if (userText.ToUpper().Contains("HOLA"))
                    {
                       var objetMessage = _util.TextMessage("Hola, En en que te puedo ayudar? :)", userNumber);
                       var objetMessage2 = _util.TextMessage("Respondere todas tus preguntas)", userNumber);
                        ListobjetMessage.Add(objetMessage);
                        ListobjetMessage.Add(objetMessage2);
                    }
                    else if(userText.ToUpper().Contains("GRACIAS"))
                    {
                        var objetMessage = _util.TextMessage("Gracias a ti por escribir", userNumber);
                        ListobjetMessage.Add(objetMessage);

                    }
                    else if (userText.ToUpper().Contains("ADIOS"))
                    {
                        var objetMessage = _util.TextMessage("Adios bebe", userNumber);
                        ListobjetMessage.Add(objetMessage);

                    }
                    else
                    {
                        var objetMessage = _util.TextMessage("Lo siento no puedo entenderte :(", userNumber);
                        ListobjetMessage.Add(objetMessage);

                    }

                    foreach(var item in ListobjetMessage)
                    {
                        await _whatsappCloudSendMessage.Execute(item);

                    }

                }

                return Ok("EVENT_RECEIVED");
            }
            catch (Exception ex)
            {

                return Ok("EVENT_RECEIVED");
            }

        }

        private string GetUserText(Message message)
        {
            string TypeMessage = message.Type;

            if(TypeMessage.ToUpper() == "TEXT")
            {
                return message.Text.Body;
            }else if(TypeMessage.ToUpper() == "INTERACTIVE")
            {
                string InteractiveType = message.Interactive.Type;

                if(InteractiveType.ToUpper() == "LIST_REPLY")
                {
                    return message.Interactive.List_Reply.Title;
                }
                else if(InteractiveType.ToUpper() == "BUTTON_REPLY")
                {
                    return message.Interactive.Button_Reply.Title;
                }
                else
                {
                    return string.Empty;
                }
            }

            return string.Empty;


        }
    }
}
