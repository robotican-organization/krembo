#ifndef BUTTON_H
#define BUTTON_H

#include "application.h"

#define BUTTON_LEG A0

class DACButton
{
private:

public:
  DACButton();
  uint16_t read();
};

#endif //BUTTON_H
