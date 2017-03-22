
#include "com_layer.h"

bool COMLayer::connect(byte server_addr[], uint16_t port)
{
  return client_.connect(server_addr, port);
}

bool COMLayer::bytesWaiting() { return client_.available(); }

void COMLayer::write(byte val)
{
  client_.write(val);
}

void COMLayer::write(byte buff[], size_t len)
{
  client_.write(buff, len);
}

byte COMLayer::read() { return client_.read(); }

uint32_t COMLayer::readBuff(byte buff[], size_t len)
{
  return client_.read(buff, len);
}
