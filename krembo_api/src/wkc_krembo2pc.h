#ifndef WKC_KREMBO2PC_H
#define WKC_KREMBO2PC_H

#include "application.h"
#include "bit_converter.h"
#include "dac_bumpers.h"
//package from krembo to pc
//WKC - wireless krembo communication protocol

/**************************************************************************
 * |--------------------- N BYTES ARRAY ------------------|
 * |       0 (8 BITS FLAGS)        |   1    |   2   |3-27 |
 * |   |   |FB |REB|LB |RIB|BC |BF |   BL   |  BCL% | ID  |
 * |0-1|0-1|0-1|0-1|0-1|0-1|0-1|0-1| 0-100  | 0-100 |0-255|
 * |------------------------------------------------------|
 * ID = 24 bytes of Photon string id in bytes
 *
 * BC = Battery Charging = flage indicates whether battery is being charged
 * BF = Battery Full = flage indicates whether battery is Full
 * FB = Front Bumper = flag indicates whether bumper was pressed
 * RIB = Right Bumper = flag indicates whether bumper was pressed
 * REB = Rear Bumper = flag indicates whether bumper was pressed
 * RB = Right Bumper = flag indicates whether bumper was pressed
 * LB = Left Bumper = flag indicates whether bumper was pressed
 * BL = Battery Level %
 * BCL = Battery Charging Level % = current level from charger
 **************************************************************************/

#define FLAGS_INDX 0
  #define BAT_FULL_BIT 0
  #define BAT_CHARGING_BIT 1
  #define BUMP_RIGHT_BIT 2
  #define BUMP_LEFT_BIT 3
  #define BUMP_REAR_BIT 4
  #define BUMP_FRONT_BIT 5
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

  bool is_bat_chrgng = false,
       is_bat_full = false;

  BumpersRes bumps;

  void toBytes(byte bytes_arr[]);
  uint16_t size();
};

#endif
