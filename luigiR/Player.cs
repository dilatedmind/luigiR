using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace daggersRage
{
    public class Player
    {
        public DaggerState state_;
        public DaggerState handstate_;

        public Player()
        {

        }

        public void changeState(DaggerState state)
        {

            this.state_ = state;

        }

        public void handleInput(PlayerInput input)
        {
            //state_.handleInput(this, input);
            //handstate_.handleInput(this, input);

            if (input.movement())
            {
                //check if has footing
                //do movement


            }

        }



        public void update()
        {
            state_.update(this);

        }

    }

    public class PlayerInput
    {

        public float mousex;
        public float mousey;
        public bool leftmouse;
        public bool rightmouse;
        public bool wkey;
        public bool akey;
        public bool dkey;
        public bool skey;

        public PlayerInput()
        {
            leftmouse = rightmouse = wkey = akey = dkey = skey = false;
            mousex = mousey = 0;
        }

        public bool movement(){

            if (wkey || akey || dkey)
            {
                return true;

            }
            else{
                return false;
            }

        }
    }

  
}