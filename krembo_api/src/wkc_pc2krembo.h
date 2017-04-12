#ifndef WKC_PC2KREMBO_H
#define WKC_PC2KREMBO_H

#include "bit_converter.h"

/***************************************************************************************************************
* |----------------------------------------------N BYTES ARRAY-------------------------------------------------|
* Index |  0  |  1 (8 BITS FLAGS) |  2  |  3  |  4  |
* Data  |  ID | | | | |JC |DR |TL | JX  | JY  |  MS |
* Values|0-255|       |0-1|0-1|0-1|0-255|0-255|0-255|
* -------------------------------------------------------------------------------------------------------------|
* Flags:
* ID = addressee krembo ID
* JC = JOY CONTROL = indicates whether master request to control base with joystick
* DR = DATA REQUEST = master asks for sensors/Krembo state data
* TL = TOGGLE LED = master asks to turn on/off led
* JX = JOY X = joystick x value
* JY = JOY Y = joystick y value
* MS = MESSAGE SIZE = user message size
**************************************************************************************************************/


#define PC2KREMBO_MSG_SIZE 5 //size bytes arr

#define ID_INDX 0
#define FLAGS_INDX 1
        #define DATA_REQ_BIT 0 //master askes photon to send sensors data
        #define TOGGLE_LED_BIT 1
        #define JOY_CTRL_BIT 2
#define JOY_X_INDX 2
#define JOY_Y_INDX 3
#define USER_MSG_SIZE_INDX 4

class WKCPC2Krembo
{
private:

public:

  uint8_t id,
          joy_x,
          joy_y,
          user_msg_size;
  bool data_req,
       toggle_led,
       joy_control;

  void fromBytes(byte bytes_arr[]);
  uint16_t size() { return PC2KREMBO_MSG_SIZE; }
  void print();
  //TODO: add content printing function
};

#endif
