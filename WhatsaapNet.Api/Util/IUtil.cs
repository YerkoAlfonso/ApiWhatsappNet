namespace WhatsaapNet.Api.Util
{
    public interface IUtil
    {
        object TextMessage(string message, string number);
        object ImageMessage(string url, string number);
        object AudioMessage(string url, string number);
        object VideoMessage(string url, string number);
        object DocumentMessage(string url, string number);
        object LocationMessage(string latitude, string longitud, string name, string addres, string number);
        object ButtonsMessage(string title, string number);

    }
}
