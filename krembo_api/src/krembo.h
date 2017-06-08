#ifndef KREMBO_H
#define KREMBO_H

#include "application.h"
#include "battery.h"
#include "mobile_base.h"
#include "rgb_led.h"
#include "rgba_sensor.h"
#include "com_layer.h"
#include "wkc_krembo2pc.h"
#include "wkc_pc2krembo.h"
#include "bluesky_timer.h"
#include "imu_sensor.h"

/*TODO:
1. add connection between photons
2. add errors checking in code
4. implement connection between master and photon (protocol)
5. add documentation
6. add documentation of Kiril wirings
7. add documentation of how to solve problems like breathing green, and how to flash version 0.6.1
8. add photon light functions from photon api
9. add photon timer functions from photon api
10. add photon logging functions from photon api
11. add documentation of wkp protocol
12. add getting photon details functions from photon api (linke name)
13. change rgba_sensor to color_sensor
14. initiate Serial.begin inside photon and encapsulte Serial methods
*/
#define MASTER_IP "10.0.0.5"
#define MASTER_PORT 8000
#define SEND_DATA_INTERVAL 1000 //ms

enum class RGBAAddr //TODO: extract this to krembo, and make constructor here take int8
{
  N = 0,
  NE = 1
  //RGBA_SENSOR3 = 2
};

class Krembo
{
private:

  bool id_was_sent_,
       master_asks_for_data_;
  COMLayer com_;
  void sendWKC();
  void rcveWKC();
  void handleWKCFromPC(WKCPC2Krembo wkc_msg);
  BlueSkyTimer send_data_timer_;

public: //TODO: try to use objects instead of methods. make sure object are doing encapsulation. see public com object for example

  MobileBase Base;
  RGBASensor RGBA_N;
  //RGBASensor RGBA_NE;
  //RGBASensor rgba3;
  Battery Bat;
  RGBLed Led;
  IMUSensor IMU;
  Krembo();
  void loop();
  String getParticleID() { return System.deviceID(); }

};

#endif //KREMBO_H
