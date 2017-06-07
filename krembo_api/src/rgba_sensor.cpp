
#include "rgba_sensor.h"

void RGBASensor::init(uint8_t addr)
{
  addr_ = addr;

  apds_ = SparkFun_APDS9960();

  i2cMuxSelectMe();
  //I2CMux::select((uint8_t)sensor_addr);

  if ( apds_.init() ) {
   Serial.print(F("APDS-9960 initialization complete sensor") );
   //Serial.print((int)sensor_addr);
   Serial.println();
    }
    else  {
   Serial.println(F("Something went wrong during APDS-9960 init sensor" ));
   //Serial.print((int)sensor_addr);
   Serial.println();
    }

 if ( apds_.enableLightSensor(false) ) {
   Serial.println(F("Light sensor is now running sensor" ));
   //Serial.print((int)sensor_addr);
   Serial.println();
 }
 else {
   Serial.println(F("Something went wrong during light sensor init! sensor" ));
   //Serial.print((int)sensor_addr);
   Serial.println();
 }
 if ( !apds_.setProximityGain(PGAIN_2X) ) {
   Serial.println(F("Something went wrong trying to set PGAIN sensor sensor" ));
   //Serial.print((int)sensor_addr);
   Serial.println();
 }
   if ( apds_.enableProximitySensor(false) ) {
   Serial.println(F("Proximity sensor is now running sensor sensor"));
   //Serial.print((int)sensor_addr);
   Serial.println();
 } else {
   Serial.println(F("Something went wrong during sensor init! sensor"));
   //Serial.print((int)sensor_addr);
   Serial.println();
 }
}

bool RGBASensor::i2cMuxSelectMe()
{
  if (addr_ > 7)
    return false;
  Wire.beginTransmission(MUX_ADDR);
  Wire.write(1 << addr_);
  Wire.endTransmission();
  return true;
}

bool RGBASensor::updateVals()
{
  i2cMuxSelectMe();
  //Read and update the light levels (ambient, red, green, blue)
  if (!apds_.readAmbientLight(ambient_light_) ||
      !apds_.readRedLight(red_light_) ||
      !apds_.readGreenLight(green_light_) ||
      !apds_.readBlueLight(blue_light_) ||
      !apds_.readProximity(proximity_))
      return false; //Error reading sensor
  return true;
}

uint16_t RGBASensor::getAmbient()
{
  if (updateVals())
    return ambient_light_;
  return 0;
}

uint16_t RGBASensor::getRed()
{
  if (updateVals())
    return red_light_;
  return 0;
}

uint16_t RGBASensor::getGreen()
{
  if (updateVals())
    return green_light_;
  return 0;
}

uint16_t RGBASensor::getBlue()
{
  if (updateVals())
    return blue_light_;
  return 0;
}

uint8_t RGBASensor::getDistance()
{
  if (updateVals())
    return proximity_;
  return 0;
}

/****************************void print()***************************
|@Goal: print rgba sensor values: ambient, red, green, blue, proximity
|@Comment: invoke read() before print() for updated values printing
********************************************************************/
void RGBASensor::print()
{
  if (updateVals())
  {
    Serial.println("------------RGBA Sensor Values------------");
    Serial.print("Ambient: "); Serial.print(ambient_light_);
    Serial.print(" | Red: ");   Serial.print(red_light_);
    Serial.print(" | Green: ");   Serial.print(green_light_);
    Serial.print(" | Blue: ");  Serial.print(blue_light_);
    Serial.print(" | Proximity: ");  Serial.println(proximity_);
  }
  else
    Serial.println("[RGBSensor]: Error while trying to read from sensor");
}
