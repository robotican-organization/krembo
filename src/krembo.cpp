
#include "krembo.h"

Krembo::Krembo()
{
  //comment DEBUG_MODE in logger.h to disable Serial and debug printing
  #ifdef DEBUG_MODE
    Serial.begin(9600);
  #endif

  //init rgba sensors (must select i2c_mux before rgba sensor init)
  i2c_mux_.select((uint8_t)SensorAddr::RGBA_SENSOR1);
  rgba_sensor1_.init();
  i2c_mux_.select((uint8_t)SensorAddr::RGBA_SENSOR2);
  rgba_sensor2_.init();

}

//--------------mobile_base functions-----------------
bool Krembo::drive(int linear_spd, int angular_spd)
{
  return mobile_base_.drive(linear_spd, angular_spd);
}
void Krembo::standbyMotors() { mobile_base_.standby(); }
void Krembo::stopMotors() { mobile_base_.stop(); }


//--------------rgba_sensor functions-----------------
bool Krembo::updateSensorVals(SensorAddr sensor_addr)
{
  return (sensor_addr == SensorAddr::RGBA_SENSOR1) ?
          rgba_sensor1_.updateVals() : rgba_sensor2_.updateVals();
}

uint16_t Krembo::getSensorAmbient(SensorAddr sensor_addr)
{
  return (sensor_addr == SensorAddr::RGBA_SENSOR1) ?
          rgba_sensor1_.getAmbient() : rgba_sensor2_.getAmbient();
}

uint16_t Krembo::getSensorRed(SensorAddr sensor_addr)
{
  return (sensor_addr == SensorAddr::RGBA_SENSOR1) ?
          rgba_sensor1_.getRed() : rgba_sensor2_.getRed();
}

uint16_t Krembo::getSensorGreen(SensorAddr sensor_addr)
{
  return (sensor_addr == SensorAddr::RGBA_SENSOR1) ?
          rgba_sensor1_.getGreen() : rgba_sensor2_.getGreen();
}

uint16_t Krembo::getSensorBlue(SensorAddr sensor_addr)
{
  return (sensor_addr == SensorAddr::RGBA_SENSOR1) ?
          rgba_sensor1_.getBlue() : rgba_sensor2_.getBlue();
}

uint8_t Krembo::getSensorDistance(SensorAddr sensor_addr)
{
  return (sensor_addr == SensorAddr::RGBA_SENSOR1) ?
          rgba_sensor1_.getDistance() : rgba_sensor2_.getDistance();
}

void Krembo::printSensor(SensorAddr sensor_addr)
{
  return (sensor_addr == SensorAddr::RGBA_SENSOR1) ?
          rgba_sensor1_.print() : rgba_sensor2_.print();
}

//----------------battery function--------------------
float Krembo::readBatLvl() { return battery_.readBatLvl(); }
float Krembo::readChargelvl() { return battery_.readChargelvl(); }
bool Krembo::isCharging() { return battery_.isCharging(); }
bool Krembo::isBatFull() { return battery_.isFull(); }
void Krembo::printBatVals() { battery_.print(); }

//----------------rgb_led functions--------------------
void Krembo::writeRGBToLed(uint8_t red_val,
                   uint8_t green_val,
                   uint8_t blue_val)
{
  rgb_led_.write(red_val, green_val, blue_val);
}
