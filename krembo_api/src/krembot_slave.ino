#include "krembot.h"

//declare only one krembot instance in your code
Krembot krembot;

void setup()
{
  krembot.setup("10.0.0.11");
}

void loop()
{
  krembot.loop();
}
