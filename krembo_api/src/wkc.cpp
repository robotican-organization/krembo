
#include "wkc.h"

void WKC::toBytes(byte bytes_arr[])
{
  //char ch_arr[name.length()];
  //name.toCharArray(ch_arr, name.length()+1); //seems there is a bug in particle function toCharArray it only filles n-1 indexes instead of n. thats why the +1
  //Serial.println(ch_arr);

  //for (uint16_t i=0; i<name.length(); i++)
  //  bytes_arr[i] = (byte)ch_arr[i];

  bytes_arr[ID_INDX] = id;
}
