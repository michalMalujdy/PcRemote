using System.IO.Ports;
using Microsoft.Extensions.Configuration;
using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Infrastructure.Services;

public class SerialCommunicationService : ISerialCommunicationService
{
    private readonly IConfiguration _configuration;

    private SerialPort _serialPort = null!;
    private Thread _serialThread = null!;
    private bool _isPortOpen;
    private Action<string> _onMessageReceived = null!;

    public SerialCommunicationService(IConfiguration configuration)
        => _configuration = configuration;

    public void Start(Action<string> onMessageReceived)
    {
        _onMessageReceived = onMessageReceived ?? throw new ArgumentNullException(nameof(onMessageReceived));
        _isPortOpen = true;

        _serialPort = new SerialPort();
        _serialPort.PortName = _configuration["PortName"];
        _serialPort.BaudRate = 9600;
        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;

        _serialThread = new Thread(Read);

        _serialPort.Open();
        _serialThread.Start();
    }

    public void Stop()
    {
        _serialThread.Join();
        _serialPort.Close();
    }

    private void Read()
    {
        while (_isPortOpen)
        {
            try
            {
                var message = _serialPort.ReadLine();
                _onMessageReceived(message);
            }
            catch (TimeoutException)
            {
            }
        }
    }
}