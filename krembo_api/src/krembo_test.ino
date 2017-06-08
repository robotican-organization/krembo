#include "krembo.h"
//declare only one Krembo instance in your code !!!
Krembo krembo;

void testRGBSensors()
{
  Serial.println("------------TESTING RGB SENSORS------------");
  Serial.println("TEST 1: sensor NORTH");
  krembo.RGBA_N.print();
  Serial.println("\nTEST 2: sensor NORTH-EAST");
  krembo.RGBA_NE.print();
  Serial.println("\nTEST 3: sensor EAST");
  krembo.RGBA_E.print();
  Serial.println("\nTEST 4: sensor SOUTH-EAST");
  krembo.RGBA_SE.print();
  Serial.println("\nTEST 5: sensor SOUTH");
  krembo.RGBA_S.print();
  Serial.println("\nTEST 6: sensor SOUTH-WEST");
  krembo.RGBA_SW.print();
  Serial.println("\nTEST 7: sensor WEST");
  krembo.RGBA_W.print();
  Serial.println("\nTEST 8: sensor NORTH-WEST");
  krembo.RGBA_NW.print();
}

void testIMU()
{
  Serial.println("------------TESTING IMU SENSORS------------");
  krembo.IMU.print();
}

void testRGBLeds()
{
/*  Serial.println("------------TESTING RGB LEDS------------");
  Serial.println("TEST 1: red");
  krembo.writeRGBToLed(255, 0, 0);
  delay(1000);
  Serial.println("TEST 2: green");
  krembo.writeRGBToLed(0, 255, 0);
  delay(1000);
  Serial.println("TEST 3: blue");
  krembo.writeRGBToLed(0, 0, 255);
  delay(1000);*/
}

void testBattery()
{
/*  Serial.println("------------TESTING BATTERY------------");
  Serial.println("TEST 1: battery");
  krembo.bat.print();*/
}

void testEngns()
{
  /*Serial.println("------------TESTING ENGNGS------------");
  Serial.println("TEST 1: driving fwd");
  krembo.Base.drive(100, 0);
  delay(2000);
  Serial.println("TEST 2: driving bwd");
  krembo.Base.drive(-100, 0);
  delay(2000);
  Serial.println("TEST 3: driving right fast");
  krembo.Base.drive(100, 100);
  delay(2000);
  Serial.println("TEST 4: driving left fast");
  krembo.Base.drive(100, -100);
  delay(2000);
  Serial.println("TEST 5: driving right slow");
  krembo.Base.drive(70, 30);
  delay(2000);
  Serial.println("TEST 6: driving left slow");
  krembo.Base.drive(70, -30);*/
}

void setup()
{
  Serial.begin(9600);
}

void loop()
{
  krembo.loop();
  //testIMU();
  //testRGBSensors();
  //delay(1000);
}
