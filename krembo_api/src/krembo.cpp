
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
/*  String id = System.deviceID();
  byte id_bytes[24];
  id.getBytes(id_bytes, ID_SIZE+1);
  for(int i=0; i < 24; i++)
  {
    Serial.print((char)id_bytes[i]);
  }
  Serial.println();*/


  if (!com_.isConnected())
  {
    com_.connect(MASTER_IP, MASTER_PORT);
    id_was_sent_ = false;
  }
  else
  {
    if (!id_was_sent_) //send id only once after connection
    {
      sendWKC();
      id_was_sent_ = true;
    }
    else if (master_asks_for_data_ && send_data_timer_.finished())
    {
      sendWKC();
      send_data_timer_.startOver();
    }

    if (com_.bytesWaiting())
    {
      rcveWKC();
    }
  }
}

void Krembo::sendWKC()
{
  //build WKC msg
  WKCKrembo2PC wkc_msg;
  wkc_msg.bat_lvl = bat.getBatLvl();
  wkc_msg.bat_chrg_lvl = bat.getChargeLvl();
  wkc_msg.is_bat_chrgng = bat.isCharging();
  wkc_msg.is_bat_full = bat.isFull();
  byte buff[wkc_msg.size()];
  wkc_msg.toBytes(buff);
  com_.write(buff, wkc_msg.size());
}

void Krembo::rcveWKC()
{
  WKCPC2Krembo wkc_msg;
  byte buff[wkc_msg.size()];
  com_.read(buff, wkc_msg.size());
  wkc_msg.fromBytes(buff);
  handleWKCFromPC(wkc_msg);
}

void Krembo::handleWKCFromPC(WKCPC2Krembo wkc_msg)
{
  wkc_msg.print();

  if (wkc_msg.data_req)
  {
    master_asks_for_data_ = true;
    send_data_timer_.start(SEND_DATA_INTERVAL);
  }
  else
    master_asks_for_data_ = false;

  if (wkc_msg.toggle_led)
    led.write(0, 0, 255); //blue //TODO: add ability to send RGB to led in protocol

  if (wkc_msg.joy_control)
    base.driveJoyCmd(wkc_msg.joy_x, wkc_msg.joy_y);
  if (wkc_msg.user_msg_size > 0) //get user message
  {
    byte user_msg_buff[wkc_msg.user_msg_size];
    com_.read(user_msg_buff, wkc_msg.user_msg_size);
    for (int i=0; i < wkc_msg.user_msg_size; i++)
    {
      Serial.print((char)user_msg_buff[i]); //TODO: delete msg printing after done testing
    }
    //TODO: do something with user_msg_buff - contains user msg
  }
}
