#ifndef RGBA_SENSOR_H
#define RGBA_SENSOR_H

#include "SparkFun_APDS9960.h"
#define MUX_ADDR 0x70


class RGBASensor
{
private:
  uint16_t ambient_light_;
  uint16_t red_light_;
  uint16_t green_light_;
  uint16_t blue_light_;
  uint8_t proximity_; //distance

  uint8_t addr_;

  SparkFun_APDS9960 apds_;

  bool updateVals();

  bool i2cMuxSelectMe();

public:
  void init(uint8_t addr);
  uint16_t getAmbient();
  uint16_t getRed();
  uint16_t getGreen();
  uint16_t getBlue();
  uint8_t getDistance();
  void print();

};

#endif //DEBUGER_H
