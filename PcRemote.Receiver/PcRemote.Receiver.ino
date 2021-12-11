#include <IRremote.h>

int IR_RECEIVE_PIN = 11;

void setup()
{
  Serial.begin(9600);
  IrReceiver.begin(IR_RECEIVE_PIN, ENABLE_LED_FEEDBACK);

}

void loop()
{
  if (IrReceiver.decode())
  {

    if (isReadingUnderstandable())
    {
      Serial.println(buildJsonMessage());
    }
    
    IrReceiver.resume();
  }
}

bool isReadingUnderstandable()
{
  return IrReceiver.decodedIRData.protocol != UNKNOWN && IrReceiver.decodedIRData.protocol != PULSE_DISTANCE && IrReceiver.decodedIRData.protocol != RC5;
}

String buildJsonMessage()
{
  return "{\"Command\":" + String(IrReceiver.decodedIRData.command) + String(",\"IsRepeat\":") + boolToString(IrReceiver.decodedIRData.flags & IRDATA_FLAGS_IS_REPEAT) + String("}");
}

String boolToString(bool value)
{
  return value ? "true" : "false";
}
