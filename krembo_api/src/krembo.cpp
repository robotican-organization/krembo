
#include "krembo.h"

Krembo::Krembo()
{
  //init rgba sensors (must select i2c_mux before rgba sensor init)
  i2c_mux_.select((uint8_t)SensorAddr::RGBA_SENSOR1);
  rgba1.init();
  i2c_mux_.select((uint8_t)SensorAddr::RGBA_SENSOR2);
  rgba2.init();
}

void Krembo::loop()
{
  
}
