#ifndef DAC_BUMPERS_H
#define DAC_BUMPERS_H

class DacBumpers
{
private:
  DacBumpers();
public:
  void print();
  void printRawVals();
  uint16_t getRawBumper();
  void getRawBumpers();
  bool isBumperPressed();
  bool isAnyBumperPressed();
  void getBumpers(bool [] bumpers);
};

#endif
