using IrRemoteServer.Core.Infrastructure;
using IrRemoteServer.Core.Services;

var serialCommunication = new SerialCommunicationService();
var messageHandler = new MessageHandler();

serialCommunication.Start(messageHandler.Handle);