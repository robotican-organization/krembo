#ifndef KREMBO_H
#define KREMBO_H


#include "application.h"
#include "logger.h"
#include "battery.h"
#include "i2c_mux.h"
#include "mobile_base.h"
#include "rgb_led.h"
#include "rgba_sensor.h"
#include "com_layer.h"
#include "wkc.h"

//comment DEBUG_MODE in logger.h to disable Serial and debug printing

enum class SensorAddr //TODO: extract this to krembo, and make constructor here take int8
{
  RGBA_SENSOR1 = 0,
  RGBA_SENSOR2 = 1
};

class Krembo
{
private:
  MobileBase mobile_base_;
  I2CMux i2c_mux_;
  RGBASensor rgba_sensor1_;
  RGBASensor rgba_sensor2_;
  Battery battery_;
  RGBLed rgb_led_;

public:

  Krembo();

  //--------------mobile_base functions-----------------
  bool drive(int linear_spd, int angular_spd);
  void stopMotors();

  //--------------rgba_sensor functions-----------------
  uint16_t getSensorAmbient(SensorAddr sensor_addr);
  uint16_t getSensorRed(SensorAddr sensor_addr);
  uint16_t getSensorGreen(SensorAddr sensor_addr);
  uint16_t getSensorBlue(SensorAddr sensor_addr);
  uint8_t getSensorDistance(SensorAddr sensor_addr);
  void printSensor(SensorAddr sensor_addr);

  //----------------battery functions--------------------
  float readBatLvl();
  float readChargelvl();
  bool isCharging();
  bool isBatFull();
  void printBatVals();

  //----------------rgb_led functions--------------------
  void writeRGBToLed(uint8_t red_val,
                     uint8_t green_val,
                     uint8_t blue_val);

  //---------------accel_gyro functions------------------
  void printIMU();
};

#endif //KREMBO_H
