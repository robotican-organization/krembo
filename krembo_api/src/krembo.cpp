
#include "krembo.h"

Krembo::Krembo()
{
  //init I2C
  Wire.begin();

  //rgba & imu sensors can only be init after wire.begin
  IMU.init();
  RGBA_N.init(uint8_t(RGBAAddr::N));
  RGBA_NE.init(uint8_t(RGBAAddr::NE));
  RGBA_E.init(uint8_t(RGBAAddr::E));
  RGBA_SE.init(uint8_t(RGBAAddr::SE));
  RGBA_S.init(uint8_t(RGBAAddr::S));
  RGBA_SW.init(uint8_t(RGBAAddr::SW));
  RGBA_W.init(uint8_t(RGBAAddr::W));
  RGBA_NW.init(uint8_t(RGBAAddr::NW));

  id_was_sent_ = false;
  master_asks_for_data_ = false;
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
  wkc_msg.bat_lvl = Bat.getBatLvl();
  wkc_msg.bat_chrg_lvl = Bat.getChargeLvl();
  wkc_msg.is_bat_chrgng = Bat.isCharging();
  wkc_msg.is_bat_full = Bat.isFull();
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
    Led.write(0, 0, 255); //blue //TODO: add ability to send RGB to Bat in protocol

  if (wkc_msg.joy_control)
    Base.driveJoyCmd(wkc_msg.joy_x, wkc_msg.joy_y);
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
