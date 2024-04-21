namespace AspXReactApp.Server.Service
{
    public class ActionInfo
    {
        public int InfoId { get; set; }
        public string Message {  get; set; }
        public object Data { get; set; }

        public ActionInfo WithData(object data)
        {
            this.Data = data;
            return this;
        }

        public static ActionInfo SystemException(string message) => new ActionInfo() { InfoId = -1, Message = message };

        public static ActionInfo EmailTaked => new ActionInfo()
        {
            InfoId = 0,
            Message = "User with this Email Exist"
        };

        public static ActionInfo UserCreated => new ActionInfo()
        {
            InfoId = 1,
            Message = "User created successfully"
        };

        public static ActionInfo UserNotFound => new ActionInfo()
        {
            InfoId = 2,
            Message = "User not found"
        };
    }
}
