
#include "accel_gyro.h"

AccelGyro::AccelGyro() : accel_gyro_()
{
  Wire.begin();
  //I2Cdev::setup(400, true);
  accel_gyro_.initialize();
  // verify connection
  Serial.println("Testing device connections...");
  Serial.println(accel_gyro_.testConnection() ?
                "MPU6050 connection successful" : "MPU6050 connection failed");
}

void AccelGyro::updateValues()
{
  accel_gyro_.getMotion6(&ax_, &ay_, &az_, &gx_, &gy_, &gz_);
}

int16_t AccelGyro::getRoll()
{
  updateValues();
  return atan2(ax_, az_) * 180 / PI;
}

void AccelGyro::print()
{
  updateValues();
  Serial.print("ax: "); Serial.print(ax_);
  Serial.print("\t | ay: "); Serial.print(ay_);
  Serial.print("\t | az: "); Serial.print(az_);
  Serial.print("\t | gx: "); Serial.print(gx_);
  Serial.print("\t | gy: "); Serial.print(gy_);
  Serial.print("\t | gz: "); Serial.println(gz_);
}
