

#include "wkc_pc2krembo.h"

void WKCPC2Krembo::fromBytes(byte bytes_arr[])
{
  //extract flags
  data_req = BitConverter::getBitInByte(bytes_arr[FLAGS_INDX],
                                       DATA_REQ_BIT);
  toggle_led = BitConverter::getBitInByte(bytes_arr[FLAGS_INDX],
                                          TOGGLE_LED_BIT);
  joy_control = BitConverter::getBitInByte(bytes_arr[FLAGS_INDX],
                                          JOY_CTRL_BIT);

  //extract joystick axes
  joy_x = (uint8_t)bytes_arr[ROLL_INDX];
  joy_y = (uint8_t)bytes_arr[PITCH_INDX];
  user_msg_size = (uint8_t)bytes_arr[USER_MSG_SIZE_INDX];
}
