namespace PRG_4_API.Model
{
    public class ResponseModel
    {
        public int status { get; set; }

        public String? message { get; set; }

        public object? data { get; set; }
    }
}
