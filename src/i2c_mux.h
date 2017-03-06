#ifndef I2C_MUX_H
#define I2C_MUX_H

#include "application.h"

#define MUX_ADDR 0x70

class I2CMux
{
private:

public:
  I2CMux()
  {
    Wire.begin();
  }

  bool select(uint8_t addr)
  {
    if (addr > 7)
      return false;
    Wire.beginTransmission(MUX_ADDR);
    Wire.write(1 << addr);
    Wire.endTransmission();
    return true;
  }
};

#endif //DEBUGER_H
