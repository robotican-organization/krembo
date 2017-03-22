#ifndef COM_LAYER
#define COM_LAYER

#include "application.h"


//WKC - wireless krembo communication protocol
class COMLayer
{
private:
  TCPClient client_;

public:
  //COMLayer();
  bool connect(byte server_addr[], uint16_t port);
  bool bytesWaiting();
  void write(byte val);
  void write(byte buff[], size_t len);
  byte read();
  uint32_t readBuff(byte buff[], size_t len);
};

#endif
