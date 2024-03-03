namespace PaginationTutorial_AspNet_Learning.Wrappers
{
    public class ResponseAPI<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }

        public ResponseAPI()
        {

        }
        public ResponseAPI(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
    }
}
