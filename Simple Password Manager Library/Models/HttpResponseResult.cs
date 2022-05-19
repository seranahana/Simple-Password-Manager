namespace SimplePM.Library.Models
{
    internal class HttpResponseResult
    {
        internal bool IsSuccessfull { get; init; }
        internal string ResponseMessage { get; init; }

        internal HttpResponseResult(bool isSuccessfull, string responseMessage)
        {
            IsSuccessfull = isSuccessfull;
            ResponseMessage = responseMessage;
        }
    }
}
