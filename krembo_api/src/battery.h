#ifndef BATTERY_H
#define BATTERY_H

#include "application.h"

#define BATTERY_LVL_LEG A4
#define CHARGING_LVL_LEG A5
#define IS_FULL_CHARGE_LEG DAC
#define IS_CHARGINE_LEG D6

//TODO: update those vals with Kiril
#define MAX_BAT_LVL 5.0
#define MIN_BAT_LVL 3.6
#define MAX_CHRG_LVL 5.0
#define MIN_CHRG_LVL 0

class Battery
{
private:

public:

  Battery();
  float readBatLvl(); //lvl in Volt
  uint8_t getBatLvl(); //lvl in %
  float readChargelvl(); //lvl in Volt
  uint8_t getChargeLvl(); //lvl in %
  bool isCharging();
  bool isFull();
  void print();

};

#endif //BATTERY_H
