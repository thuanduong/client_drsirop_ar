using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServerDefinePath
{
    public static string API { get; private set; }
    public const string Horse = "horse-race";
    
    public static void SetAPI(string value)
    {
        API = value;
    }

    public static string GetPath(string api)
    {
        return $"{API}/{api}";
    }

    public static string GetPath(string category, string api)
    {
        return $"{API}/{category}/{api}";
    }

   
    public static string GetHorsePath(string api)
    {
        return GetPath(Horse, api);
    }
   
}
