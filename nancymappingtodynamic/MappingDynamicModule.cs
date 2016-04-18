using Nancy;

namespace nancymappingtodynamic
{
    public class MappingDynamicModule: NancyModule
    {
        public MappingDynamicModule()
        {
            

        }
        //public MappingDynamicModule() : base("/api/test")
        //{

        //    //Post["/"] = parameters =>
        //    //{
        //    ////var stringBody = Request.Body.AsString();

        //    ////var dict = Extentions.DeserializeAndFlatten(stringBody);
        //    ////var newObject = new Dictionary<string, object>();
        //    ////foreach (var kvp in dict)
        //    ////{
        //    ////    int i = kvp.Key.LastIndexOf(".");
        //    ////    string key = (i > -1 ? kvp.Key.Substring(i + 1) : kvp.Key);
        //    ////    Match m = Regex.Match(kvp.Key, @"\.([0-9]+)\.");
        //    ////    if (m.Success) key += m.Groups[1].Value;
        //    ////    newObject.Add(key, kvp.Value);
        //    ////}
        //    //////Now deserialize the preprocessed JObject to the final class
        //    //    return "";
        //    //};

        //}
    }
}