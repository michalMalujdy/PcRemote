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

            dynamic ws = Microsoft.VisualBasic.Interaction.CreateObject("WScript.Shell", "");
            if (value == 22)
            {
                ws.SendKeys("\u00AD"); // mute or unmute
            }
            if (value == 74)
            {
                ws.SendKeys("\u00B3"); // start stop
            }
            if (value == 27)
            {
                ws.SendKeys("\u00AF"); // vol up
            }
            if (value == 26)
            {
                ws.SendKeys("\u00AE"); // vol down
            }

        }
        catch (TimeoutException) { }
    }
}