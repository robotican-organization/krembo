
#include "dac_button.h"

DACButton::DACButton()
{
  pinMode(BUTTON_LEG, INPUT);
}

uint16_t DACButton::read()
{
  return analogRead(BUTTON_LEG);
}
