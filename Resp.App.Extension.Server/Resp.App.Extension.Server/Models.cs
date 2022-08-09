using System.Text.Json.Serialization;

namespace Resp.App.Extension.Server;

public class VersionOutModel
{
    public string Id { get; set; }

    public string Name { get; set; }

    [JsonPropertyName("read-only")]
    public bool ReadOnly { get; set; }
}

public class DecodeInModel
{
    public string Data { get; set; }

    [JsonPropertyName("redis-key-name")]
    public string KeyName { get; set; }

    [JsonPropertyName("redis-key-type")]
    public string KeyType { get; set; }
}

public class EncodeInModel
{
    public string Data { get; set; }

    public string Metadata { get; set; }
}
