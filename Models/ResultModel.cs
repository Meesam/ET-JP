
namespace JobPortal.Models
{
    public static class ResultModel
    {
       public static string SUCCESS { get { return "success"; } }   
       public static string FAIL { get { return "fail"; } }
       public static string ERROR { get { return "error"; } }
       public static int DATACOUNT { get; set; }
       public static string SaveMessage()
       {
          return "Record added successfully";
       }
       public static string ErrorMessage(string Error)
       {
          return "Sorry ! Got an error " + Error;
       }
       public static string UpdateMessage()
       {
          return "Record updated successfully";
       }
        public static string DeleteMessage()
        {
            return "Record deleted successfully";
        }
        public static string CustomMessages(string MessageType,string Message)
        {
            return Message.Trim();
        }
    }

    public class ApiResult
    {
        public object ObjData { get; set; }
        public string Token { get; set; }
        public string Status { get; set; }
        public int Count { get; set; }
    }
}