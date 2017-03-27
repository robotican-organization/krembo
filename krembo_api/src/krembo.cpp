
#include "krembo.h"

Krembo::Krembo()
{
  id_was_sent_ = false;
  master_asks_for_data_ = false;
  //init rgba sensors (must select i2c_mux before rgba sensor init)
  i2c_mux_.select((uint8_t)SensorAddr::RGBA_SENSOR1);
  rgba1.init();
  i2c_mux_.select((uint8_t)SensorAddr::RGBA_SENSOR2);
  rgba2.init();
  //i2c_mux_.select((uint8_t)SensorAddr::RGBA_SENSOR3);
  //rgba3.init();
}

void Krembo::loop()
{
  if (!com.isConnected())
  {
    com.connect(MASTER_IP, MASTER_PORT);
    id_was_sent_ = false;
  }
  else
  {
    if (!id_was_sent_) //send id only on once after connection
    {
        sendWKC();
        id_was_sent_ = true;
    }
    else if (master_asks_for_data_)
    {
        sendWKC();
    }

    if (com.bytesWaiting())
    {
      char ch = com.read();

    }
  }
}

void Krembo::sendWKC()
{
  //build WKC msg
  WKCKrembo2PC wkc_msg;
  wkc_msg.id = getID();
  wkc_msg.bat_lvl = bat.getBatLvl();
  wkc_msg.bat_chrg_lvl = bat.getChargeLvl();

  byte buff[wkc_msg.size()];
  wkc_msg.toBytes(buff);
  com.write(buff, wkc_msg.size());
}
