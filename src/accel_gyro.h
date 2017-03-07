#ifndef ACCEL_GYRO_H
#define ACCEL_GYRO_H

// I2Cdev and MPU6050 must be installed as libraries, or else the .cpp/.h files
// for both classes must be in the include path of your project
// class default I2C address is 0x68
// specific I2C addresses may be passed as a parameter here
// AD0 low = 0x68 (default for InvenSense evaluation board)
// AD0 high = 0x69
#include "MPU6050.h"

// Arduino Wire library is required if I2Cdev I2CDEV_ARDUINO_WIRE implementation
// is used in I2Cdev.h
#include "application.h"
#define OUTPUT_READABLE_ACCELGYRO

class AccelGyro
{
private:
  int16_t ax_, ay_, az_;
  int16_t gx_, gy_, gz_;

  MPU6050 accel_gyro_;

  void updateValues();

public:
  AccelGyro();
  int16_t getRoll(); //gets roll angle
  void print();

};

#endif
