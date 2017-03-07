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

  bool updateVals();

public:
  void init();
  uint16_t getAmbient();
  uint16_t getRed();
  uint16_t getGreen();
  uint16_t getBlue();
  uint8_t getDistance();
  void print();

};

#endif //DEBUGER_H
