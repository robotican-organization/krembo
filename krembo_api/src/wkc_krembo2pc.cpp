
#include "wkc_krembo2pc.h"

WKCKrembo2PC::WKCKrembo2PC()
{
  id_ = System.deviceID(); //get 24 long id string
}

void WKCKrembo2PC::toBytes(byte bytes_arr[])
{

  BitConverter::setBitInByte(bytes_arr[FLAGS_INDX],
                             bump_front,
                             BUMP_FRONT_BIT);

  BitConverter::setBitInByte(bytes_arr[FLAGS_INDX],
                            bump_rear,
                            BUMP_REAR_BIT);

  BitConverter::setBitInByte(bytes_arr[FLAGS_INDX],
                             bump_right,
                             BUMP_REAR_BIT);

  BitConverter::setBitInByte(bytes_arr[FLAGS_INDX],
                            bump_left,
                            BUMP_LEFT_BIT);

  bytes_arr[BAT_LVL_INDX] = bat_lvl;
  bytes_arr[BAT_CHRG_LVL_INDX] = bat_chrg_lvl;

  byte id_bytes[ID_SIZE];
  //particle apigetbyte() function is buggy,
  //therefore adding one is needed to insure
  //last byte is returned to array
  id_.getBytes(id_bytes, ID_SIZE+1);
  for(int i=0; i < ID_SIZE; i++)
  {
    bytes_arr[i + ID_START_INDX] = id_bytes[i];
  }
}

uint16_t WKCKrembo2PC::size()
{
  return KREMBO2PC_MSG_SIZE;
}
