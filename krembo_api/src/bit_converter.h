#ifndef BIT_CONVERTER_H
#define BIT_CONVERTER_H

struct BitConverter
{

  static void fromInt8(int8_t value, byte bytes[], int16_t start_index)
  {
   //TODO: implement
  }

  static uint8_t toInt8(byte bytes[], int16_t start_index)
  {
    return (uint8_t)bytes[start_index];
  }

  static void fromInt16(int16_t value, byte bytes[], int16_t start_index)
  {
  	bytes[start_index] = value & 0xFF;
  	bytes[start_index + 1] = (value >> 8) & 0xFF;
  }

  static uint16_t toInt16(byte bytes[], int16_t start_index)
  {
  	return ((bytes[start_index + 1] << 8) | bytes[start_index]);
  }
};

#endif
