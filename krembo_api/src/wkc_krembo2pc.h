#ifndef WKC_KREMBO2PC_H
#define WKC_KREMBO2PC_H

#include "application.h"
//package from krembo to pc
//WKC - wireless krembo communication protocol

/**************************************************************************
 * |--------------- N BYTES ARRAY ----------|
 * |0 (8 BITS FLAGS) |   1    |   2   |3-27 |
 * |   BC   |   BF   |   BL   |  BCL% | ID  |
 * |  0-1   |  0-1   | 0-100  | 0-100 |0-255|
 * |----------------------------------------|
 * ID = Photon string id in bytes
 * BC = Battery Charging = flage indicates whether battery is being charged
 * BF = Battery Full = flage indicates whether battery is Full
 * BL = Battery Level %
 * BCL = Battery Charging Level % = current level from charger
 **************************************************************************/

#define FLAGS_INDX 0
#define BAT_LVL_INDX 1
#define BAT_CHRG_LVL_INDX 2
#define ID_START_INDX 3
#define ID_SIZE 24 //size of photon hardware id

#define KREMBO2PC_MSG_SIZE 3 + ID_SIZE //size bytes arr


class WKCKrembo2PC
{
private:
  String id_;
public:
  WKCKrembo2PC();
  uint8_t bat_lvl,
          bat_chrg_lvl;

  bool is_bat_chrgng,
       is_bat_full;
  void toBytes(byte bytes_arr[]);
  uint16_t size();
};

#endif
