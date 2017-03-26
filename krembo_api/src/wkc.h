#ifndef WKC_H
#define WKC_H

#include "application.h"
//package from krembo to pc
//WKC - wireless krembo communication protocol

#define MSG_SIZE 1 //size of const size data (i.e. name is not const size, therfore not included)
#define ID_INDX 0

class WKC
{
private:

public:
  String name;
  uint8_t id;
  void toBytes(byte bytes_arr[]);
  uint16_t size() { return MSG_SIZE; }
};

#endif
