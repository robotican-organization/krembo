
#include "application.h"
#include "test_suit.h"

TestSuit test_suit;

void setup() {

}

void loop() {

  test_suit.testEngns();
  test_suit.testRGBSensors();
  test_suit.testIMU();
  test_suit.testRGBLeds();
  test_suit.testBattery();

}
