
#include "battery.h"

Battery::Battery()
{
  pinMode(BATTERY_LVL_LEG, INPUT);
  pinMode(CHARGING_LVL_LEG, INPUT);
  pinMode(IS_FULL_CHARGE_LEG, INPUT);
  pinMode(IS_CHARGINE_LEG, INPUT);
}

float Battery::readBatLvl()
{
  return (analogRead(BATTERY_LVL_LEG) * 3.3 * 1.5) / 4095.0;
}

float Battery::readChargelvl()
{
  return (analogRead(CHARGING_LVL_LEG) * 3.3 * (5.0 / 3.0)) / 4095.0;
}

void Battery::print()
{
  Serial.println("------------Battry Values------------");
  Serial.print("Battery level: "); Serial.print(readBatLvl());
  Serial.print(" | Charge Level: "); Serial.print(readChargelvl());
  Serial.print(" | Is Charging: "); Serial.print(isCharging() == false ? "No" : "Yes" );
  Serial.print(" | Is Full: "); Serial.println(isFull() == false ? "No" : "Yes" );
}

bool Battery::isCharging()
{
  return digitalRead(IS_CHARGINE_LEG) ==  LOW ? false : true;
}

bool Battery::isFull()
{
  return digitalRead(IS_FULL_CHARGE_LEG) == LOW ? false : true;
}

uint8_t Battery::getBatLvl()
{
  return (uint8_t)map(readBatLvl(),
                      MIN_BAT_LVL,
                      MAX_BAT_LVL,
                      0, 100);
}

uint8_t Battery::getChargeLvl()
{
  return (uint8_t)map(readChargelvl(),
                      MIN_CHRG_LVL,
                      MAX_CHRG_LVL,
                      0, 100);
}
