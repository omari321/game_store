namespace Shared
{ 
    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}
