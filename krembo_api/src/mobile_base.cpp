
#include "mobile_base.h"

MobileBase::MobileBase()
{
//  Serial.println("initialization engines");
  pinMode(LEFT_MOTOR_DIR_LEG1, OUTPUT);
  pinMode(LEFT_MOTOR_DIR_LEG2, OUTPUT);
  pinMode(LEFT_MOTOR_PWM_LEG, OUTPUT);

  pinMode(RIGHT_MOTOR_DIR_LEG1, OUTPUT);
  pinMode(RIGHT_MOTOR_DIR_LEG2, OUTPUT);
  pinMode(RIGHT_MOTOR_PWM_LEG, OUTPUT);

  pinMode(MOTOR_STBY_LEG, OUTPUT);
  digitalWrite(MOTOR_STBY_LEG, LOW);
}

void MobileBase::setMotorDirection(Motor motor, Direction direction)
{
  if (motor == LEFT)
  {
    if (direction == Direction::FORWARD)
    {
      digitalWrite(LEFT_MOTOR_DIR_LEG1, HIGH);
      digitalWrite(LEFT_MOTOR_DIR_LEG2, LOW);
    }
    else //backward
    {
      digitalWrite(LEFT_MOTOR_DIR_LEG1, LOW);
      digitalWrite(LEFT_MOTOR_DIR_LEG2, HIGH);
    }
  }
  else //right motor
  {
    if (direction == Direction::FORWARD)
    {
      digitalWrite(RIGHT_MOTOR_DIR_LEG1, LOW);
      digitalWrite(RIGHT_MOTOR_DIR_LEG2, HIGH);
    }
    else //backward
    {
      digitalWrite(RIGHT_MOTOR_DIR_LEG1, HIGH);
      digitalWrite(RIGHT_MOTOR_DIR_LEG2, LOW);
    }
  }
}

void MobileBase::driveJoyCmd(uint8_t joy_x, uint8_t joy_y)
{
  //convert x and y to linear and angular speeds
  int8_t linear_spd = map(joy_x, 0, 255, -100, 100);
  int8_t angular_spd = map(joy_y, 0, 255, -100, 100);
  Serial.printf("linear_spd: %d\n", linear_spd);
  Serial.printf("angular_spd: %d\n", angular_spd);

  drive(linear_spd, angular_spd);
}

bool MobileBase::drive(int8_t linear_spd, int8_t angular_spd)
{
  digitalWrite(MOTOR_STBY_LEG, HIGH);
  if ((linear_spd < -100 || linear_spd > 100) ||
      (angular_spd < -100 || angular_spd > 100))
    return false;

  int linear_scale = int((linear_spd / 100.0) * 255.0);
  int angular_scale = int((angular_spd / 100.0) * 255.0);

  //Serial.print("linear_scale: "); Serial.println(linear_scale);
  //Serial.print("angular_scale: "); Serial.println(angular_scale);

  int left_cmd = linear_scale - angular_scale;
  int right_cmd = linear_scale + angular_scale;

  //Serial.print("left cmd: "); Serial.println(left_cmd);
  //Serial.print("right cmd: "); Serial.println(right_cmd);

  if (left_cmd > 255) left_cmd = 255;
  else if (left_cmd < -255) left_cmd = -255;

  if (right_cmd > 255) right_cmd = 255;
  else if (right_cmd<-255) right_cmd = -255;

  if (left_cmd > 0)
    setMotorDirection(Motor::LEFT, Direction::FORWARD);
  else
  {
    setMotorDirection(Motor::LEFT, Direction::BACKWARD);
    left_cmd = -left_cmd;
  }
  if (right_cmd > 0)
    setMotorDirection(Motor::RIGHT, Direction::FORWARD);
  else
  {
    setMotorDirection(Motor::RIGHT, Direction::BACKWARD);
    right_cmd = -right_cmd;
  }

  //Serial.print("left cmd=: "); Serial.println(left_cmd);
  //Serial.print("right cmd=: "); Serial.println(right_cmd);

  analogWrite(LEFT_MOTOR_PWM_LEG, left_cmd);
  analogWrite(RIGHT_MOTOR_PWM_LEG, right_cmd);
  return true;
}

void MobileBase::stop()
{
  digitalWrite(MOTOR_STBY_LEG, LOW);
}
