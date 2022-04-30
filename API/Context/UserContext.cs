namespace API.Context
{
    public class UserContext
    {
        public int? userId { get; set; }
        public string ClientIpAddress { get; set; }
        public UserContext(string clientIp)
        {
            ClientIpAddress = clientIp;
        }
        public UserContext(int? userId, string clientIp)
        {
            ClientIpAddress = clientIp;
            this.userId = userId;
        }
    }
}
