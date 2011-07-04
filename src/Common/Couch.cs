using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using System.Text;
using System.IO;


public static class Couch
{
    public static string Database
    {
        get { return ConfigurationManager.AppSettings["Couch.Database"]; }
    }

    public static Uri Uri
    {
        get { return new Uri(Database); }
    }

    public static string Put(this Uri uri, string path, string data)
    {
        return doRequest(uri, "PUT", path, data);
    }

    public static string Post(this Uri uri, string path, string data)
    {
        return doRequest(uri, "POST", path, data);
    }

    public static string Get(this Uri uri, string path)
    {
        var destination = new Uri(uri, path);
        var client = new WebClient();
        return client.DownloadString(destination);
    }

    static string doRequest(Uri uri, string method, string path, string data)
    {
        var destination = new Uri(uri, path);
        var request = WebRequest.Create(destination);
        request.Method = method;

        var bytes = Encoding.UTF8.GetBytes(data);
        request.ContentType = "application/json; charset=utf-8";
        request.ContentLength = bytes.Length;

        var writer = request.GetRequestStream();
        writer.Write(bytes, 0, bytes.Length);
        writer.Close();

        var response = request.GetResponse();

        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            var result = reader.ReadToEnd();
            response.Close();
            return result;
        }
    }
}
