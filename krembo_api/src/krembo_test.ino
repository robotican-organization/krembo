#include "krembo.h"

Krembo krembo;
//TCPClient client; //part of photon lib
//byte server[] = { 10, 0,0,13 }; //server ip
bool connected = false;
void setup()
{

}

void loop()
{
  if (!connected)
  {
    connected = krembo.com.connect("10.0.0.13", 8000);
  }
  else
  {
    if (krembo.com.bytesWaiting())
    {
      char ch = krembo.com.read();
      if (ch == 'f')
        krembo.base.drive(100, 0);
      if (ch == 'b')
        krembo.base.drive(-100, 0);
    }
  }
  /*
  if (client.available())
  {
    char c = client.read();
    client.write(c);
  }

  if (!client.connected())
  {
    Serial.println();
    Serial.println("disconnecting.");
  //  client.stop();
    //for(;;);
  } */
}
