
#include "test_suit.h"

void TestSuit::testEngns()
{
  Serial.println("------------TESTING ENGNGS------------");
  Serial.println("TEST 1: driving fwd");
  krembo_.drive(100, 0);
  delay(2000);
  Serial.println("TEST 2: driving bwd");
  krembo_.drive(-100, 0);
  delay(2000);
  Serial.println("TEST 3: driving right fast");
  krembo_.drive(100, 100);
  delay(2000);
  Serial.println("TEST 4: driving left fast");
  krembo_.drive(100, -100);
  delay(2000);
  Serial.println("TEST 5: driving right slow");
  krembo_.drive(70, 30);
  delay(2000);
  Serial.println("TEST 6: driving left slow");
  krembo_.drive(70, -30);
  delay(2000);
  Serial.println("TEST 7: stoping engines");
  krembo_.stopMotors();
  delay(2000);
}

void TestSuit::testRGBSensors()
{
  Serial.println("------------TESTING RGB SENSORS------------");
  Serial.println("TEST 1: sensor 1");
  krembo_.printSensor(SensorAddr::RGBA_SENSOR1);
  Serial.println("TEST 2: sensor 2");
  krembo_.printSensor(SensorAddr::RGBA_SENSOR2);
  delay(2000);
}

void TestSuit::testIMU()
{
  Serial.println("------------TESTING IMU SENSORS------------");
  Serial.println("TEST 1: imu sensor");
  krembo_.printIMU();
  delay(2000);
}

void TestSuit::testRGBLeds()
{
  Serial.println("------------TESTING RGB LEDS------------");
  Serial.println("TEST 1: red");
  krembo_.writeRGBToLed(255, 0, 0);
  delay(2000);
  Serial.println("TEST 2: green");
  krembo_.writeRGBToLed(0, 255, 0);
  delay(2000);
  Serial.println("TEST 3: blue");
  krembo_.writeRGBToLed(0, 0, 255);
  delay(2000);
}

void TestSuit::testBattery()
{
  Serial.println("------------TESTING BATTERY------------");
  Serial.println("TEST 1: battery");
  krembo_.printBatVals();
  delay(2000);
}
