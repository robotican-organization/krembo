#ifndef MOBILE_BASE_H
#define MOBILE_BASE_H

#include "application.h"

#define LEFT_MOTOR_DIR_LEG1 D4
#define LEFT_MOTOR_DIR_LEG2 D6
#define LEFT_MOTOR_PWM_LEG D2
#define RIGHT_MOTOR_DIR_LEG1 A2
#define RIGHT_MOTOR_DIR_LEG2 A3
#define RIGHT_MOTOR_PWM_LEG D3
#define MOTOR_STBY_LEG A1

class MobileBase
{
private:
  enum Motor {RIGHT, LEFT};
  enum Direction {FORWARD, BACKWARD};
  void setMotorDirection(Motor motor, Direction direction);
public:
  MobileBase();
  bool drive(int linear_spd, int angular_spd);
  void standby();
  void stop();
};

#endif
