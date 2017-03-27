using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.DirectInput;
using System.Windows.Forms;
using System;

namespace KremboControl.Utils
{
    class JoystickControls
    {
        
        public JoystickControls() {}
        public JoystickControls(JoystickControls joy_source)
        {
            roll_axis = joy_source.roll_axis;
            pitch_axis = joy_source.pitch_axis;
            throttle_axis = joy_source.throttle_axis;
            yaw_axis = joy_source.yaw_axis;

            toggle1 = joy_source.toggle1;
            toggle2 = joy_source.toggle2;

            roll_trim = joy_source.roll_trim;
            pitch_trim = joy_source.pitch_trim;
            throttle_trim = joy_source.throttle_trim;
            axis_trim = joy_source.axis_trim;
        }
        //axes
        public UInt16 roll_axis; 
        public UInt16 pitch_axis; 
        public UInt16 throttle_axis;
        public UInt16 yaw_axis;

        public bool toggle1, toggle2;

        //trim
        public int roll_trim = 0; 
        public int pitch_trim = 0;
        public int throttle_trim = 0;
        public int axis_trim = 0;
        public int yaw_trim = 0;
    }

    class Joystick
    {
        //TODO: insert to settings form ----------------------------------------------------------------
        public const int PITCH_AXIS_MIN_VAL = 1350;
        public const int PITCH_AXIS_MAX_VAL = 1650;
        public const int ROLL_AXIS_MIN_VAL = 1350;
        public const int ROLL_AXIS_MAX_VAL = 1650;
        public const int THROTTLE_AXIS_MIN_VAL = 1000;
        public const int THROTTLE_AXIS_MAX_VAL = 2000;
        public const int YAW_AXIS_MIN_VAL = 1000;
        public const int YAW_AXIS_MAX_VAL = 2000;

        public const int ROLL_TRIM_INC = 1;
        public const int PITCH_TRIM_INC = 1;
        public const int YAW_TRIM_INC = 1;
        public const int THROTTLE_TRIM_INC = 1;
        //----------------------------------------------------------------------------------------------

        //-----------------------------------CONSTANT SETTINGS------------------------------------------
        public const int TRIM_MAX_RANGE = 500;

        public const int PWM_AXES_MAX_VAL = 2000;
        public const int PWM_AXES_MIN_VAL = 1000;

        public const int JOY_AXES_MAX_VAL = 65535;
        public const int JOY_AXES_MIN_VAL = 0;

        public const int HAT_RIGHT = 9000;
        public const int HAT_LEFT = 27000;
        public const int HAT_UP = 0;
        public const int HAT_DOWN = 18000;

        public const bool BUTTON_PRESSED = true;
        //----------------------------------------------------------------------------------------------

        private IntPtr window_handle_;
        private Device joy_dev_;

        /************JOYSTICK STATES************
         * Z axis = roll
         * RZ axis = pitch
         * X axis = yaw
         * Y axis = throttle
         **************************************/
        private JoystickState joy_state_;

        private JoystickControls joy_ctrls_;
        private string sys_joysticks_;

        //buttons
        public bool[] buttons;
        public int[] view_hat;

        public Joystick(IntPtr window_handle)
        {
            window_handle_ = window_handle;
            joy_ctrls_ = new JoystickControls();
        }
/*
        public UInt16 getRollAxis() { return joy_ctrls_.roll_axis; }
        public UInt16 getPitchAxis() { return joy_ctrls_.pitch_axis; }
        public UInt16 getThrottleAxis() { return joy_ctrls_.throttle_axis; }
        public UInt16 getYawAxis() { return joy_ctrls_.yaw_axis; }*/

        public JoystickControls getJoyControls()
        {
            return new JoystickControls(joy_ctrls_);
        }

        public bool connect()
        {
            string sticks = FindJoysticks();
            if (sticks != null)
            {
                if (AcquireJoystick(sticks))
                {
                    //MsgBxLogger.infoMsg("", "");
                    //enableTimer();
                    return true;
                }
            }
            return false;
        }

        public string FindJoysticks()
        {
            sys_joysticks_ = null;
            try
            {
                // Find all the GameControl devices that are attached.
                DeviceList gameControllerList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);

                // check that we have at least one device.
                if (gameControllerList.Count > 0)
                {
                    foreach (DeviceInstance deviceInstance in gameControllerList)
                    {
                        // create a device from this controller so we can retrieve info.
                        joy_dev_ = new Device(deviceInstance.InstanceGuid);
                        joy_dev_.SetCooperativeLevel(window_handle_, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);

                        sys_joysticks_ = joy_dev_.DeviceInformation.InstanceName;

                        break;
                    }
                }
            }
            catch
            {
                return null;
            }
            return sys_joysticks_;
        }

        public bool AcquireJoystick(string name)
        {
            try
            {
                DeviceList gameControllerList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);
                int i = 0;
               // bool found = false;
                
                foreach (DeviceInstance deviceInstance in gameControllerList)
                {
                    if (deviceInstance.InstanceName == name)
                    {
                        //found = true;
                        joy_dev_ = new Device(deviceInstance.InstanceGuid);
                        joy_dev_.SetCooperativeLevel(window_handle_, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);

                        joy_dev_.SetDataFormat(DeviceDataFormat.Joystick);
                        joy_dev_.Acquire();
                        //readJoystickControls();

                        return true;
                    }
                    i++;
                }

             //   if (!found)
             //       return false;

               // joystick_dev_.SetDataFormat(DeviceDataFormat.Joystick);
                //joystick_dev_.Acquire();
                //UpdateStatus();
            }
            catch (Exception err)
            {
                return false;
            }
            return false;
        }

        public bool update()
        {
            try
            {
                readJoystickControls();

                //-----------------------------CALCULATE TRIM--------------------------
                //trim roll
                if (buttons[2] == BUTTON_PRESSED)
                {
                    joy_ctrls_.roll_trim += ROLL_TRIM_INC;
                    if (joy_ctrls_.roll_trim > TRIM_MAX_RANGE) joy_ctrls_.roll_trim = TRIM_MAX_RANGE;
                }
                if (buttons[0] == BUTTON_PRESSED)
                {
                    joy_ctrls_.roll_trim -= ROLL_TRIM_INC;
                    if (joy_ctrls_.roll_trim < -TRIM_MAX_RANGE) joy_ctrls_.roll_trim = -TRIM_MAX_RANGE;
                }
                //trim pitch
                if (buttons[3] == BUTTON_PRESSED)
                {
                    joy_ctrls_.pitch_trim += PITCH_TRIM_INC;
                    if (joy_ctrls_.pitch_trim > TRIM_MAX_RANGE) joy_ctrls_.pitch_trim = TRIM_MAX_RANGE;
                }
                if (buttons[1] == BUTTON_PRESSED)
                {
                    joy_ctrls_.pitch_trim -= PITCH_TRIM_INC;
                    if (joy_ctrls_.pitch_trim < -TRIM_MAX_RANGE) joy_ctrls_.pitch_trim = -TRIM_MAX_RANGE;
                }
                //trim yaw
                if (view_hat[0] == HAT_RIGHT)
                {
                    joy_ctrls_.yaw_trim += YAW_TRIM_INC;
                    if (joy_ctrls_.yaw_trim > TRIM_MAX_RANGE) joy_ctrls_.yaw_trim = TRIM_MAX_RANGE;
                }
                if (view_hat[0] == HAT_LEFT)
                {
                    joy_ctrls_.yaw_trim -= YAW_TRIM_INC;
                    if (joy_ctrls_.yaw_trim < -TRIM_MAX_RANGE) joy_ctrls_.yaw_trim = -TRIM_MAX_RANGE;
                }
                //trim throttle
                if (view_hat[0] == HAT_UP)
                {
                    joy_ctrls_.throttle_trim += THROTTLE_TRIM_INC;
                    if (joy_ctrls_.throttle_trim > TRIM_MAX_RANGE) joy_ctrls_.throttle_axis = TRIM_MAX_RANGE;
                }
                if (view_hat[0] == HAT_DOWN)
                {
                    joy_ctrls_.throttle_trim -= THROTTLE_TRIM_INC;
                    if (joy_ctrls_.throttle_trim < -TRIM_MAX_RANGE) joy_ctrls_.throttle_trim = -TRIM_MAX_RANGE;
                }

                //-----------------------------APPLY TRIM AND LIMITAIONS--------------------------
                joy_ctrls_.pitch_axis = (UInt16)((int)joy_ctrls_.pitch_axis + joy_ctrls_.pitch_trim);
                joy_ctrls_.roll_axis = (UInt16)((int)joy_ctrls_.roll_axis + joy_ctrls_.roll_trim);
                joy_ctrls_.throttle_axis = (UInt16)((int)joy_ctrls_.throttle_axis + joy_ctrls_.throttle_trim);
                joy_ctrls_.yaw_axis = (UInt16)((int)joy_ctrls_.yaw_axis + joy_ctrls_.yaw_trim);

                //---------------------------LIMIT VALUES TO VALID INPUTS-------------------------
                if (joy_ctrls_.pitch_axis < PWM_AXES_MIN_VAL) joy_ctrls_.pitch_axis = PWM_AXES_MIN_VAL;
                if (joy_ctrls_.pitch_axis > PWM_AXES_MAX_VAL) joy_ctrls_.pitch_axis = PWM_AXES_MAX_VAL;
                if (joy_ctrls_.roll_axis < PWM_AXES_MIN_VAL) joy_ctrls_.roll_axis = PWM_AXES_MIN_VAL;
                if (joy_ctrls_.roll_axis > PWM_AXES_MAX_VAL) joy_ctrls_.roll_axis = PWM_AXES_MAX_VAL;
                if (joy_ctrls_.throttle_axis < PWM_AXES_MIN_VAL) joy_ctrls_.throttle_axis = PWM_AXES_MIN_VAL;
                if (joy_ctrls_.throttle_axis > PWM_AXES_MAX_VAL) joy_ctrls_.throttle_axis = PWM_AXES_MAX_VAL;
                if (joy_ctrls_.yaw_axis < PWM_AXES_MIN_VAL) joy_ctrls_.yaw_axis = PWM_AXES_MIN_VAL;
                if (joy_ctrls_.yaw_axis > PWM_AXES_MAX_VAL) joy_ctrls_.yaw_axis = PWM_AXES_MAX_VAL;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ReleaseJoystick()
        {
            joy_dev_.Unacquire();
        }


        public void printAxes()
        {
            Console.Write(joy_state_.ARx); Console.Write(", ");
            Console.Write(joy_state_.ARy); Console.Write(", ");
            Console.Write(joy_state_.ARz); Console.Write(", ");
            Console.Write(joy_state_.AX); Console.Write(", ");
            Console.Write(joy_state_.AY); Console.Write(", ");
            Console.Write(joy_state_.AZ); Console.Write(", ");
            Console.Write(joy_state_.FRx); Console.Write(", ");
            Console.Write(joy_state_.FRy); Console.Write(", ");
            Console.Write(joy_state_.FRz); Console.Write(", ");
            Console.Write(joy_state_.FX); Console.Write(", ");
            Console.Write(joy_state_.FY); Console.Write(", ");
            Console.Write(joy_state_.FZ); Console.Write(", ");
            Console.Write(joy_state_.Rx); Console.Write(", ");
            Console.Write(joy_state_.Ry); Console.Write(", ");
            Console.Write(joy_state_.Rz); Console.Write(", ");
            Console.Write(joy_state_.VRx); Console.Write(", ");
            Console.Write(joy_state_.VRy); Console.Write(", ");
            Console.Write(joy_state_.VRz); Console.Write(", ");
            Console.Write(joy_state_.VX); Console.Write(", ");
            Console.Write(joy_state_.VY); Console.Write(", ");
            Console.Write(joy_state_.VZ); Console.Write(", ");
            Console.Write(joy_state_.X); Console.Write(", ");
            Console.Write(joy_state_.Y); Console.Write(", ");
            Console.Write(joy_state_.Z); Console.Write(", ");
            int[] hat = joy_state_.GetPointOfView();
            foreach (int i in hat)
            {
                Console.Write(i); Console.Write(", ");
            }
            Console.WriteLine();

            //TODO: MOVE THIS READING TO SOMEWHERE ELSE...
            /*   for (int i = 0; i < joystickButtons.Length; i++)
               {
                   if (buttons[i] == true)
                       output.Text += "Button " + i + " Pressed\n";
               }*/

        }

        public void readJoystickControls()
        {
            Poll();

            //read axes values
            joy_ctrls_.roll_axis = (UInt16)mapVal(joy_state_.Z, 
                                                  JOY_AXES_MIN_VAL, 
                                                  JOY_AXES_MAX_VAL, 
                                                  ROLL_AXIS_MIN_VAL, 
                                                  ROLL_AXIS_MAX_VAL);

            joy_ctrls_.pitch_axis = (UInt16)reverseVal(
                                                        mapVal(
                                                            joy_state_.Rz, 
                                                            JOY_AXES_MIN_VAL, 
                                                            JOY_AXES_MAX_VAL, 
                                                            PITCH_AXIS_MIN_VAL, 
                                                            PITCH_AXIS_MAX_VAL
                                                        ), 
                                                        PITCH_AXIS_MIN_VAL, 
                                                        PITCH_AXIS_MAX_VAL
                                                        );

            joy_ctrls_.yaw_axis = (UInt16)mapVal(joy_state_.X, 
                                                 JOY_AXES_MIN_VAL, 
                                                 JOY_AXES_MAX_VAL, 
                                                 YAW_AXIS_MIN_VAL, 
                                                 YAW_AXIS_MAX_VAL);

            joy_ctrls_.throttle_axis = (UInt16)reverseVal(
                                                            mapVal(
                                                                    joy_state_.Y, 
                                                                    JOY_AXES_MIN_VAL, 
                                                                    JOY_AXES_MAX_VAL, 
                                                                    YAW_AXIS_MIN_VAL, 
                                                                    YAW_AXIS_MAX_VAL
                                                                    ), 
                                                            YAW_AXIS_MIN_VAL, 
                                                            YAW_AXIS_MAX_VAL
                                                            );
            
            //read joystick hat values
            view_hat = joy_state_.GetPointOfView();

            //read joystick buttons values
            byte[] joy_buttons = joy_state_.GetButtons();
            buttons = new bool[joy_buttons.Length];
            int btn_indx = 0;
            foreach (byte button in joy_buttons)
            {
                buttons[btn_indx] = button >= 128;
                btn_indx++;
            }
        }

        private void Poll()
        {
            try
            {
                // poll the joystick
                joy_dev_.Poll();
                // update the joystick state field
                joy_state_ = joy_dev_.CurrentJoystickState;
            }
            catch
            {
                throw (null);
            }
        }

        public int mapVal(int value,
                           int from_min_val, 
                           int from_max_val,
                           int to_min_val,
                           int to_max_val)
        {
            float from_range = from_max_val - from_min_val;
            float to_range = to_max_val - to_min_val;
            return (int)(((value / from_range) * to_range) + to_min_val);
        }

        public int reverseVal(int value, int min, int max)
        {
            return (max + min) - value;
        }
    }
}
