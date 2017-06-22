#ifndef DAC_BUMPERS_H
#define DAC_BUMPERS_H

#define BUMPERS_LEG A0
#define ERR_MARGIN 20

#define NO_BUMP 0
#define LEFT 403
#define RIGHT 85
#define RIGHT_LEFT 480
#define REAR 1183
#define REAR_LEFT 1567
#define REAR_RIGHT 1253
#define REAR_LEFT_RIGHT 1630
#define FRONT 2145
#define FRONT_LEFT 2520
#define FRONT_RIGHT 2203
#define FRONT_RIGHT_LEFT 2570
#define FRONT_REAR 3279
#define FRONT_REAR_LEFT 3630
#define FRONT_REAR_RIGHT 3322
#define FRONT_REAR_RIGHT_LEFT 3667

/****************
front, rear, right, left
----------
0, 0, 0, 0| sum: 0 v
----------
0, 0, 0, 1| sum: 2050 v
----------
0, 0, 1, 0| sum: 484 v
----------
0, 0, 1, 1| sum: 2534 v
----------
0, 1, 0, 0| sum: 1012 v
----------
0, 1, 0, 1| sum: 3062 V
----------
0, 1, 1, 0| sum: 1496 V
----------
0, 1, 1, 1| sum: 3546 V
----------
1, 0, 0, 0| sum: 387 V
----------
1, 0, 0, 1| sum: 2437 V
----------
1, 0, 1, 0| sum: 871 V
----------
1, 0, 1, 1| sum: 2921 V
----------
1, 1, 0, 0| sum: 1399 V
----------
1, 1, 0, 1| sum: 3449 V
----------
1, 1, 1, 0| sum: 1883 V
----------
1, 1, 1, 1| sum: 3933 V
****************/


struct BumpersRes
{
  bool front = false,
       rear = false,
       right = false,
       left = false;
};

class DacBumpers
{
public:
  DacBumpers()
  {
    pinMode(BUMPERS_LEG, INPUT);
  }

  BumpersRes read()
  {
    BumpersRes res;
    uint16_t read_val = analogRead(BUMPERS_LEG);

    if (read_val > (LEFT - ERR_MARGIN) &&
             read_val < (LEFT + ERR_MARGIN))
             res.left = true;
    else if (read_val > (RIGHT - ERR_MARGIN) &&
             read_val < (RIGHT + ERR_MARGIN))
             res.right = true;
    else if (read_val > (RIGHT_LEFT - ERR_MARGIN) &&
             read_val < (RIGHT_LEFT + ERR_MARGIN))
             {
               res.right = true;
               res.left = true;
             }
    else if (read_val > (REAR - ERR_MARGIN) &&
            read_val < (REAR + ERR_MARGIN))
            res.rear = true;
    else if (read_val > (REAR_LEFT - ERR_MARGIN) &&
             read_val < (REAR_LEFT + ERR_MARGIN))
             {
               res.rear = true;
               res.left = true;
             }
    else if (read_val > (REAR_RIGHT - ERR_MARGIN) &&
            read_val < (REAR_RIGHT + ERR_MARGIN))
            {
              res.rear = true;
              res.right = true;
            }
    else if (read_val > (REAR_LEFT_RIGHT - ERR_MARGIN) &&
             read_val < (REAR_LEFT_RIGHT + ERR_MARGIN))
             {
               res.rear = true;
               res.left = true;
               res.right = true;
             }
    else if (read_val > (FRONT - ERR_MARGIN) &&
            read_val < (FRONT + ERR_MARGIN))
            res.front = true;
    else if (read_val > (FRONT_LEFT - ERR_MARGIN) &&
             read_val < (FRONT_LEFT + ERR_MARGIN))
             {
               res.front = true;
               res.left = true;
             }
    else if (read_val > (FRONT_RIGHT - ERR_MARGIN) &&
            read_val < (FRONT_RIGHT + ERR_MARGIN))
            {
              res.front = true;
              res.right = true;
            }
    else if (read_val > (FRONT_RIGHT_LEFT - ERR_MARGIN) &&
             read_val < (FRONT_RIGHT_LEFT + ERR_MARGIN))
             {
               res.front = true;
               res.right = true;
               res.left = true;
             }
    else if (read_val > (FRONT_REAR - ERR_MARGIN) &&
            read_val < (FRONT_REAR + ERR_MARGIN))
            {
              res.front = true;
              res.rear = true;
            }
    else if (read_val > (FRONT_REAR_LEFT - ERR_MARGIN) &&
             read_val < (FRONT_REAR_LEFT + ERR_MARGIN))
             {
               res.front = true;
               res.rear = true;
               res.left = true;
             }
    else if (read_val > (FRONT_REAR_RIGHT - ERR_MARGIN) &&
            read_val < (FRONT_REAR_RIGHT + ERR_MARGIN))
            {
              res.front = true;
              res.rear = true;
              res.right = true;
            }
    else if (read_val > (FRONT_REAR_RIGHT_LEFT - ERR_MARGIN) &&
             read_val < (FRONT_REAR_RIGHT_LEFT + ERR_MARGIN))
             {
               res.front = true;
               res.rear = true;
               res.right = true;
               res.left = true;
             }
    return res;

/*ALGO TO PRINT ALL BUMPERS POSSIBLITIES
    int bump_arr[4] = {0};
    Serial.println("****************");
    for(int front =0; front <= 1; front ++)
    {
      if (front)
        bump_arr[0] = 1;
      else
        bump_arr[0] = 0;
      //printArr(bump_arr);
      for(int rear =0; rear <= 1; rear ++)
      {
        if (rear)
          bump_arr[1] = 1;
        else
          bump_arr[1] = 0;
        //printArr(bump_arr);
        for(int right =0; right <= 1; right ++)
        {
          if (right)
            bump_arr[2] = 1;
          else
            bump_arr[2] = 0;
          //printArr(bump_arr);
          for(int left =0; left <= 1; left ++)
          {
            if (left)
              bump_arr[3] = 1;
            else
              bump_arr[3] = 0;
            printArr(bump_arr);
          }
        }
      }
    }
    Serial.println("****************");
    delay(2000);*/
  }

  void print()
  {
    Serial.print("Raw Bumpers: "); Serial.println(analogRead(BUMPERS_LEG));
    Serial.print("Bumpers Pressed: ");
    BumpersRes res;
    res = read();
    if (res.front)
      Serial.print("|FRONT|");
    if (res.rear)
      Serial.print("|REAR|");
    if (res.right)
      Serial.print("|RIGHT|");
    if (res.left)
      Serial.print("|LEFT|");
    Serial.println();
  }

};



#endif
