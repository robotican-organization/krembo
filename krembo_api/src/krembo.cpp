
#include "krembo.h"

Krembo::Krembo()
{
  //init I2C
  Wire.begin();
  Serial.begin(38400);

  //rgba & imu sensors can only be init after wire.begin
  //IMU.init();

  RgbaFront.init(uint8_t(RGBAAddr::Front));
  /*RgbaFrontRight.init(uint8_t(RGBAAddr::FrontRight));
  RgbaRight.init(uint8_t(RGBAAddr::Right));
  RgbaRearRight.init(uint8_t(RGBAAddr::RearRight));
  RgbaRear.init(uint8_t(RGBAAddr::Rear));
  RgbaRearLeft.init(uint8_t(RGBAAddr::RearLeft));
  RgbaLeft.init(uint8_t(RGBAAddr::Left));
  RgbaFrontLeft.init(uint8_t(RGBAAddr::FrontLeft));*/

  id_was_sent_ = false;
  master_asks_for_data_ = false;
  skip_led_gui_cmds_ = false;
  skip_base_gui_cmds_ = false;
}

void Krembo::loop()
{
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

  //rgba sensors
  wkc_msg.rgba_front = RgbaFront.read();



/*
  wkc_msg.bumps = Bumpers.read();




  wkc_msg.rgba_rear = RgbaRear.read();
  wkc_msg.rgba_right = RgbaRight.read();
  wkc_msg.rgba_left = RgbaLeft.read();
  wkc_msg.rgba_front_right = RgbaFrontRight.read();
  wkc_msg.rgba_front_left = RgbaFrontLeft.read();
  wkc_msg.rgba_rear_right = RgbaRearRight.read();
  wkc_msg.rgba_rear_left = RgbaRearLeft.read();

  wkc_msg.bat_lvl = Bat.getBatLvl();
  wkc_msg.bat_chrg_lvl = Bat.getChargeLvl();
  wkc_msg.is_bat_chrgng = Bat.isCharging();
  wkc_msg.is_bat_full = Bat.isFull();
*/
  byte buff[wkc_msg.size()];

  //Serial.println(System.freeMemory());

  wkc_msg.toBytes(buff);

  Serial.println("buff: ");
  for (int i=0; i<wkc_msg.size(); i++)
  {
    Serial.print(buff[i]);
    Serial.print(", ");
  }
  Serial.println();


  com_.write(buff, wkc_msg.size());

  Serial.println(wkc_msg.size());

  Serial.println("after2");

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
  {
    Led.write(wkc_msg.led_red,
              wkc_msg.led_green,
              wkc_msg.led_blue);
    skip_led_gui_cmds_ = false;
  }
  else if (!skip_led_gui_cmds_)
  {
    skip_led_gui_cmds_ = true;
    Led.write(0, 0, 0);
  }

  if (wkc_msg.joy_control)
  {
    Base.driveJoyCmd(wkc_msg.joy_x, wkc_msg.joy_y);
    skip_base_gui_cmds_ = false;
  }
  else if (!skip_base_gui_cmds_)
  {
    //Base.driveJoyCmd(128,128);
    Base.stop();
    skip_base_gui_cmds_ = true;
  }

  if (wkc_msg.user_msg_size > 0) //get user message
  {
    byte user_msg_buff[wkc_msg.user_msg_size];
    com_.read(user_msg_buff, wkc_msg.user_msg_size);
    for (int i=0; i < wkc_msg.user_msg_size; i++)
    {
      Serial.print((char)user_msg_buff[i]); //TODO: delete msg printing after done testing
    }
    Serial.println();
    //TODO: do something with user_msg_buff - contains user msg
  }
}
