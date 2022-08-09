using MessagePack;

using Microsoft.AspNetCore.Mvc;

using System.Text.Json;

namespace Resp.App.Extension.Server.Controllers;

[ApiController]
[Route("data-formatters")]
public class FormattersController : ControllerBase
{
    private const string _MsgPack = "msgpack";
    private const string _ContentType_Json = "application/json";
    //private const string _ContentType_OctetStream = "application/octet-stream";

    [HttpGet]
    public IEnumerable<VersionOutModel> Get()
    {
        return new VersionOutModel[]
        {
            new VersionOutModel
            {
                Id = _MsgPack,
                Name = "MsgPack .NET 6.0",
                ReadOnly = true
            }
        };
    }

    #region MsgPack
    [HttpPost($"{_MsgPack}/decode")]
    public IActionResult Decode([FromBody] DecodeInModel model)
    {
        if (model == null || string.IsNullOrWhiteSpace(model.Data))
        {
            return new JsonResult(new { Error = "Content is empty" })
            {
                StatusCode = 400,
                ContentType = _ContentType_Json
            };
        }

        try
        {
            var bytes = Convert.FromBase64String(model.Data);
            var json = MessagePackSerializer.ConvertToJson(bytes);

            return new JsonResult(JsonDocument.Parse(json))
            {
                StatusCode = 200,
                ContentType = _ContentType_Json
            };
        }
        catch (Exception e)
        {
            return new JsonResult(new { Error = e.Message })
            {
                StatusCode = 400,
                ContentType = _ContentType_Json
            };
        }
    }

    [HttpPost($"{_MsgPack}/encode")]
    public IActionResult Encode([FromBody] EncodeInModel model)
    {
        if (model == null || string.IsNullOrWhiteSpace(model.Data))
        {
            return new JsonResult(new { Error = "Content is empty" })
            {
                StatusCode = 400,
                ContentType = _ContentType_Json
            };
        }

        try
        {
            #region TODO
            //var bytes = Convert.FromBase64String(model.Data);
            //var json = MessagePackSerializer.Serialize(bytes);

            //return new ContentResult
            //{
            //    StatusCode = 200,
            //    ContentType = _ContentType_OctetStream,
            //    Content = Encoding.ASCII.GetString(json)
            //};
            #endregion

            return new JsonResult(new { Error = "NOT support" })
            {
                StatusCode = 400,
                ContentType = _ContentType_Json
            };
        }
        catch (Exception e)
        {
            return new JsonResult(new { Error = e.Message })
            {
                StatusCode = 400,
                ContentType = _ContentType_Json
            };
        }
    }
    #endregion
}
