#ifndef BATTERY_H
#define BATTERY_H

#include "application.h"

#define BATTERY_LVL_LEG A4
#define CHARGING_LVL_LEG A5
#define IS_FULL_CHARGE_LEG DAC
#define IS_CHARGINE_LEG D5

class Battery
{
private:

public:

  Battery();
  float readBatLvl();
  float readChargelvl();
  bool isCharging();
  bool isFull();
  void print();

};

#endif //BATTERY_H
