using Newtonsoft.Json;
using System.IO;

public class ConfigReader
{
    public string GmailUsername { get; set; }
    public string GmailPassword { get; set; }
    public string AttachmentPath { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string GmailUrl { get; set; }

    public static ConfigReader ReadConfig(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<ConfigReader>(json);
    }
}