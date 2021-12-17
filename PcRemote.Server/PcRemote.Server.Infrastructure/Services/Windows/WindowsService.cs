using System.Diagnostics;
using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Infrastructure.Services.Windows;

public class WindowsService : IOsService
{
    public IOsInputService Input { get; }

    public WindowsService(IOsInputService osInputService)
        => Input = osInputService;



    public void ShutDown(TimeSpan delay)
    {
        var cliCommand = "shutdown -s";

        if (delay != TimeSpan.Zero)
        {
            cliCommand += $" -t {delay.TotalSeconds}";
        }

        RunInCmd(cliCommand);
    }

    private void RunInCmd(string command)
    {
        var processInfo = new ProcessStartInfo("cmd.exe", "/K " + command)
        {
            CreateNoWindow = false,
            UseShellExecute = false
        };

        Process.Start(processInfo);
    }
}