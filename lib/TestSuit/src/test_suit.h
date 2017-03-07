#ifndef TEST_SUIT_H
#define TEST_SUIT_H

#include "krembo.h"

class TestSuit
{
private:
  Krembo krembo_;

public:
  void testEngns();
  void testRGBSensors();
  void testIMU();
  void testRGBLeds();
  void testBattery();

};

#endif //TEST_SUIT_H
