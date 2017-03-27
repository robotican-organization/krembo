
#include "wkc_krembo2pc.h"

void WKCKrembo2PC::toBytes(byte bytes_arr[])
{
  bytes_arr[ID_INDX] = id;
  bytes_arr[BAT_LVL_INDX] = bat_lvl;
  bytes_arr[BAT_CHRG_LVL_INDX] = bat_chrg_lvl;
}
