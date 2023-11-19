using System;
using System.Collections.Generic;
using System.Web.Http;

public class LogController : ApiController
{
    private static List<LogModel> logs = new List<LogModel>();

    
    public IHttpActionResult Post([FromBody] LogModel log)
    {        
        logs.Add(log);
        Console.WriteLine($"Received log: {log}");

        return Ok("Log ingested successfully");
    }
    
    public IHttpActionResult GetLogs()
    {
        return Ok(logs);
    }
}

public class LogModel
{
    public string Level { get; set; }
    public string Message { get; set; }
    public string ResourceId { get; set; }
    public DateTime Timestamp { get; set; }
    public string TraceId { get; set; }
    public string SpanId { get; set; }
    public string Commit { get; set; }
    public MetadataModel Metadata { get; set; }
}

public class MetadataModel
{
    public string ParentResourceId { get; set; }
}
