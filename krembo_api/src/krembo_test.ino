#include "krembo.h"
#include "test_suit.h"

Krembo krembo;
TestSuit test_suit;

void setup()
{
  Serial.begin(9600);
}

void loop()
{
  krembo.loop();
  //test_suit.testAllTogether();
}
