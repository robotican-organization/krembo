#ifndef WKC_KREMBO2PC_H
#define WKC_KREMBO2PC_H

#include "application.h"
//package from krembo to pc
//WKC - wireless krembo communication protocol

/***********************
 * |------------------- N BYTES ARRAY
 * |  0  |   1    |      2      |3 (8 BITS FLAGS) |
 * |  ID |BAT LVL%|BAT CHRG LVL%|BAT CHRG|BAT FULL|
 * |0-255| 0-255  |   0-255     |    0-1 |   0-1  |
 **********************/

#define MSG_SIZE 3 //size bytes arr

#define ID_INDX 0
#define BAT_LVL_INDX 1
#define BAT_CHRG_LVL_INDX 2

class WKCKrembo2PC
{
private:

public:
  String name;
  uint8_t id,
          bat_lvl,
          bat_chrg_lvl;

  bool is_bat_chrgng,
       is_bat_full;
  void toBytes(byte bytes_arr[]);
  uint16_t size() { return MSG_SIZE; }
};

#endif
