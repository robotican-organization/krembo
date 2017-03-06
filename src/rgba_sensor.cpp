
#include "rgba_sensor.h"

void RGBASensor::init()
{
  apds_ = SparkFun_APDS9960();

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

bool RGBASensor::updateVals()
{
  // Read the light levels (ambient, red, green, blue)
  if (  !apds_.readAmbientLight(ambient_light_) ||
      !apds_.readRedLight(red_light_) ||
      !apds_.readGreenLight(green_light_) ||
      !apds_.readBlueLight(blue_light_) ||
      !apds_.readProximity(proximity_) )
      {
          Serial.println("Error reading light\proximity values");
          return false;
      }
    /*  else
      {
  Serial.print("Ambient: ");
  Serial.print(ambient_light_);
  Serial.print(" Red: ");
  Serial.print(red_light_);
  Serial.print(" Green: ");
  Serial.print(green_light_);
  Serial.print(" Blue: ");
  Serial.print(blue_light_);
  Serial.print(" Proximity: ");
  Serial.println(proximity_data_);*/
  return true;
    //}
}

/****************************void print()***************************
|@Goal: print rgba sensor values: ambient, red, green, blue, proximity
|@Comment: invoke read() before print() for updated values printing
********************************************************************/
void RGBASensor::print()
{
  Serial.println("------------RGBA Sensor Values------------");
  Serial.print("Ambient: "); Serial.print(ambient_light_);
  Serial.print(" | Red: ");   Serial.print(red_light_);
  Serial.print(" | Green: ");   Serial.print(green_light_);
  Serial.print(" | Blue: ");  Serial.print(blue_light_);
  Serial.print(" | Proximity: ");  Serial.println(proximity_);
}
