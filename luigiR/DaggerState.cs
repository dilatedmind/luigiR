using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace daggersRage
{
    public class DaggerState
    {

        public DaggerState(){

        }

        public virtual void handleInput(Player player, PlayerInput input) { }
        public virtual void update(Player player) { }

    }

    public class GroundState : DaggerState
    {
        public GroundState()
        {


        }

        public void handleInput2(Player player, PlayerInput input)
        {
            if (input.wkey == true)
            {
                player.changeState(new AirState());

            }

        }


    }

    public class AirState : DaggerState
    {
        public AirState()
        {

        }

    }

}