
#include "krembo.h"

Krembo::Krembo()
{
  id_was_sent = false;
  //init rgba sensors (must select i2c_mux before rgba sensor init)
  i2c_mux_.select((uint8_t)SensorAddr::RGBA_SENSOR1);
  rgba1.init();
  i2c_mux_.select((uint8_t)SensorAddr::RGBA_SENSOR2);
  rgba2.init();
}

void Krembo::loop()
{
  if (!com.isConnected())
  {
    com.connect(MASTER_IP, MASTER_PORT);
    id_was_sent = false;
  }
  else
  {
    if (!id_was_sent)
    {
        sendWKC();
        id_was_sent = true;
    }

    if (com.bytesWaiting())
    {
      char ch = com.read();

    }
  }
}

void Krembo::sendWKC()
{
  WKC wkc_msg;
  wkc_msg.id = getID();

  byte buff[wkc_msg.size()];
  wkc_msg.toBytes(buff);
  com.write(buff, wkc_msg.size());
}
