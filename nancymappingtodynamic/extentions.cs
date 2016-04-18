using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace nancymappingtodynamic
{
    public static class Extentions
    {
        public static void RemoveFromLowestPossibleParent(this JToken node)
        {
            if (node == null)
                throw new ArgumentNullException();
            var contained = node.AncestorsAndSelf().FirstOrDefault(t => t.Parent is JArray || t.Parent is JObject);
            contained?.Remove();
        }

        public static void MoveTo(this JToken token, JObject newParent)
        {
            if (newParent == null)
                throw new ArgumentNullException();
            var toMove = token.AncestorsAndSelf().OfType<JProperty>().First(); // Throws an exception if no parent property found.
            toMove.Remove();
            newParent.Add(toMove);
        }

        public static Dictionary<string, object> DeserializeAndFlatten(string json)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            JToken token = JToken.Parse(json);
            FillDictionaryFromJToken(dict, token, "");
            return dict;
        }

        private static void FillDictionaryFromJToken(Dictionary<string, object> dict, JToken token, string prefix)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    foreach (JProperty prop in token.Children<JProperty>())
                    {
                        FillDictionaryFromJToken(dict, prop.Value, Join(prefix, prop.Name));
                    }
                    break;

                case JTokenType.Array:
                    int index = 0;
                    foreach (JToken value in token.Children())
                    {
                        FillDictionaryFromJToken(dict, value, Join(prefix, index.ToString()));
                        index++;
                    }
                    break;

                default:
                    dict.Add(prefix, ((JValue)token).Value);
                    break;
            }
        }

        private static string Join(string prefix, string name)
        {
            return (string.IsNullOrEmpty(prefix) ? name : prefix + "." + name);
        }
    }
}