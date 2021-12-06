using System.Globalization;
using System.IO.Ports;

var serialPort = new SerialPort();
serialPort.PortName = "COM6";
serialPort.BaudRate = 9600;
serialPort.ReadTimeout = 500;
serialPort.WriteTimeout = 500;

var readThread = new Thread(Read);

serialPort.Open();
readThread.Start();

Console.ReadLine();

readThread.Join();
serialPort.Close();

void Read()
{
    while (true)
    {
        try
        {
            var message = serialPort.ReadLine();

            var parts = message.Split(' ');
            if (parts.Contains("Repeat") || parts.Contains("Protocol=UNKNOWN"))
            {
                continue;
            }

            var valueHex = parts[2].Substring(8);
            var value = Convert.ToInt32(valueHex , 16);

            Console.WriteLine(value);
        }
        catch (TimeoutException) { }
    }
}