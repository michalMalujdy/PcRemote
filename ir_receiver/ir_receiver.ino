#include <IRremote.h>

int IR_RECEIVE_PIN = 11;
int previousCommand = INT8_MIN;

void setup()
{
  Serial.begin(9600);
  IrReceiver.begin(IR_RECEIVE_PIN, ENABLE_LED_FEEDBACK);

}

void loop()
{
  if (IrReceiver.decode()) {
    
    if(IrReceiver.decodedIRData.protocol != UNKNOWN && IrReceiver.decodedIRData.protocol != PULSE_DISTANCE && IrReceiver.decodedIRData.protocol != RC5)
    {
      Serial.println(buildJsonMessage());
    }
    
    previousCommand = IrReceiver.decodedIRData.command;
    IrReceiver.resume();
  }
}

String buildJsonMessage()
{
  return "{\"command\":" + String(IrReceiver.decodedIRData.command) + String(",\"isRepeat\":") + boolToString(previousCommand == IrReceiver.decodedIRData.command) + String("}");
}

String boolToString(bool value)
{
  return value ? "true" : "false";
}
