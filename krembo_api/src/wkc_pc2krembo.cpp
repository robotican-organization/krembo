

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
  joy_x = (uint8_t)bytes_arr[JOY_X_INDX];
  joy_y = (uint8_t)bytes_arr[JOY_Y_INDX];

  led_red = (uint8_t)bytes_arr[LED_RED_INDX];
  led_green = (uint8_t)bytes_arr[LED_GREEN_INDX];
  led_blue = (uint8_t)bytes_arr[LED_BLUE_INDX];

  user_msg_size = (uint8_t)bytes_arr[USER_MSG_SIZE_INDX];
}

void WKCPC2Krembo::print()
{
  Serial.println("-------- WKCPC2Krembo pkg content: --------");
  Serial.printf("data_req?: %d\n", data_req);
  Serial.printf("toggle_led?: %d\n", toggle_led);
  Serial.printf("joy_control?: %d\n", joy_control);
  Serial.printf("joy_x: %d\n", joy_x);
  Serial.printf("joy_y: %d\n", joy_y);
  Serial.printf("led_red: %d\n", led_red);
  Serial.printf("led_green: %d\n", led_green);
  Serial.printf("led_blue: %d\n", led_blue);
  Serial.printf("user_msg_size: %d\n", user_msg_size);
  Serial.println("-------------------------------------------");
}
