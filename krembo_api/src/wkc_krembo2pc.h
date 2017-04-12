#ifndef WKC_KREMBO2PC_H
#define WKC_KREMBO2PC_H

#include "application.h"
//package from krembo to pc
//WKC - wireless krembo communication protocol

/**************************************************************************
 * |------------------- N BYTES ARRAY -------------
 * |  0  |1 (8 BITS FLAGS) |   2    |      3      |
 * |  ID |   BC   |   BF   |   BL   |    BCL%     |
 * |0-255|  0-1   |  0-1   | 0-100  |   0-100     |
 * |----------------------------------------------|
 * ID = This Krembo ID
 * BC = Battery Charging = flage indicates whether battery is being charged
 * BF = Battery Full = flage indicates whether battery is Full
 * BL = Battery Level %
 * BCL = Battery Charging Level % = current level from charger
 **************************************************************************/

#define KREMBO2PC_MSG_SIZE 4 //size bytes arr

#define ID_INDX 0
#define FLAGS_INDX 1
#define BAT_LVL_INDX 2
#define BAT_CHRG_LVL_INDX 3

class WKCKrembo2PC
{
private:

public:
  uint8_t id,
          bat_lvl,
          bat_chrg_lvl;

  bool is_bat_chrgng,
       is_bat_full;
  void toBytes(byte bytes_arr[]);
  uint16_t size() { return KREMBO2PC_MSG_SIZE; }
};

#endif
