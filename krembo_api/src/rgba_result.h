#ifndef RGBA_RESULT_H
#define RGBA_RESULT_H

#include "application.h"

struct RGBAResult
{
  uint16_t Ambient;
  uint16_t Red;
  uint16_t Green;
  uint16_t Blue;
  uint8_t Distance;
  uint8_t ErrCode;
  bool IsReadOk;
};

#endif //RGBA_RESULT_H
