using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace daggersRage
{
    public class PlayerController
    {

        public bool UPKEY;
        public bool DOWNKEY;
        public bool LEFTKEY;
        public bool RIGHTKEY;
        public bool MOUSEDOWN;
        public int MOUSEX;
        public int MOUSEY;
        public int RECENTKEY;


        public PlayerController()
        {

            UPKEY = false;
            DOWNKEY = false;
            LEFTKEY = false;
            RIGHTKEY = false;
            MOUSEX = 0;
            MOUSEY = 0;
            MOUSEDOWN = false;
            RECENTKEY = 1;


        }

    }
}