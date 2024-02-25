using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyFunctionApp.Models;

namespace MyFunctionApp.Functions;

public class HelloWorld
{
    public HelloWorld(
        IOptions<FuncSettings> settings)
    {
        this.Settings = settings;
    }
    
    /// <summary>
    /// Gets the settings.
    /// </summary>
    private IOptions<FuncSettings> Settings { get; }
    
    [Function("HelloWorld")]
    public async Task RunAsync([TimerTrigger("0 */5 * * * *", RunOnStartup = false)] TimerInfo timerInfo, FunctionContext context)
    {
        var logger = context.GetLogger("MyFunction");

        logger.LogInformation($"Hello World");
        logger.LogInformation($"You found this setting: {this.Settings.Value.MySpecialSetting}");
    }
}