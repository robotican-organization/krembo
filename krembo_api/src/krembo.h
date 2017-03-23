#ifndef KREMBO_H
#define KREMBO_H


#include "application.h"
#include "battery.h"
#include "i2c_mux.h"
#include "mobile_base.h"
#include "rgb_led.h"
#include "rgba_sensor.h"
#include "com_layer.h"
#include "wkc.h"

/*TODO:
1. add connection between photons
2. add errors checking
3. implement wkp class
4. implement connection between master and photon (protocol)
5. add documentation
6. add documentation of Kiril wirings
7. add documentation of how to solve problems like breathing green, and how to flash version 0.6.1
8. add photon light functions from photon api
9. add photon timer functions from photon api
10. add photon logging functions from photon api
*/

enum class SensorAddr //TODO: extract this to krembo, and make constructor here take int8
{
  RGBA_SENSOR1 = 0,
  RGBA_SENSOR2 = 1
};

class Krembo
{
private:

  I2CMux i2c_mux_;


public: //TODO: try to use objects instead of methods. make sure object are doing encapsulation. see public com object for example

  Krembo();
  void loop();
  MobileBase base;
  RGBASensor rgba1;
  RGBASensor rgba2;
  Battery bat;
  RGBLed led;
  COMLayer com;
};

#endif //KREMBO_H
