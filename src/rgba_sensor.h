#ifndef RGBA_SENSOR_H
#define RGBA_SENSOR_H

#include "SparkFun_APDS9960.h"
#include "i2c_mux.h"



class RGBASensor
{
private:
  uint16_t ambient_light_;
  uint16_t red_light_;
  uint16_t green_light_;
  uint16_t blue_light_;
  uint8_t proximity_; //distance

  I2CMux i2c_mux_;
  SparkFun_APDS9960 apds_;

public:
  void init();
  bool updateVals();
  uint16_t getAmbient() { return ambient_light_; }
  uint16_t getRed() { return red_light_; }
  uint16_t getGreen() { return green_light_; }
  uint16_t getBlue() { return blue_light_; }
  uint8_t getDistance() { return proximity_; }
  void print();

};

#endif //DEBUGER_H
