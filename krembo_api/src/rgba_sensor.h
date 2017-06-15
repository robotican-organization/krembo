#ifndef RGBA_SENSOR_H
#define RGBA_SENSOR_H

#include "SparkFun_APDS9960.h"
#define MUX_ADDR 0x70


struct RGBAResult
{
  uint16_t Ambient;
  uint16_t Red;
  uint16_t Green;
  uint16_t Blue;
  uint8_t Distance;
  uint8_t ErrCode;
  bool IsReadOk;
};


class RGBASensor
{
private:
  /*uint16_t ambient_light_;
  uint16_t red_light_;
  uint16_t green_light_;
  uint16_t blue_light_;
  uint8_t proximity_; //distance*/

  uint8_t addr_;

  SparkFun_APDS9960 apds_;
  //bool updateVals();
  bool i2cMuxSelectMe();
  /*uint8_t ambient();
  uint8_t red();
  uint8_t green();
  uint8_t blue();
  uint8_t distance();*/

public:

  void init(uint8_t addr);
  RGBAResult read();
  void print();

};




#endif //DEBUGER_H
