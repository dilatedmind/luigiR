using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace daggersRage
{
    public abstract class PhysicsObject
    {

        public PhysicalState currentstate;
        public PhysicalState desiredstate;
        public float x_force;
        public float y_force;
        public bool isAlive;
        public int id;
        public static int nextid = 0;
        public string type;
        public int life;
        public int frame = 0;
        public float halfheight;
        public float halfwidth;
        public float collisioncoefficient;
        public int invultimer;
        protected float GRAVITY = 60 * 9.8f;
        public bool canBreak = false;
        public int jumpcounter = 0;

        public PhysicsObject()
        {

        }

        public virtual void Update(float dt){


        }

        public virtual void RegisterHit(PhysicsObject po)
        {


        }

        public void setId()
        {

            this.id = nextid;
            nextid++;

        }


    }

    public class PointObject : PhysicsObject
    {

        private float bounceheight = 0;
        private float MAXBOUNCEHEIGHT = 30;

        public PointObject(int id)
        {

            //this.id = id;

            setId();
            currentstate = new PhysicalState();
            desiredstate = new PhysicalState();
            x_force = 0;
            y_force = 0;
            currentstate.x_position = 200;
            currentstate.y_position = 400;
            this.type = "point";
            this.life = 1;
            this.collisioncoefficient = 1;

        }

        public override void Update(float dt)
        {


            this.frame++;
            y_force = y_force + 16 * 9.8f;
            desiredstate.y_velocity = currentstate.y_velocity + y_force * dt;
            desiredstate.x_velocity = currentstate.x_velocity + x_force * dt;

            //desiredstate.y_velocity = (2 * currentstate.y_velocity + y_force * dt) / 2;
            //desiredstate.x_velocity = (2 * currentstate.x_velocity + x_force * dt) / 2;


            desiredstate.y_position = currentstate.y_position + desiredstate.y_velocity * dt;
            desiredstate.x_position = currentstate.x_position + desiredstate.x_velocity * dt;


            if (desiredstate.y_position < currentstate.y_position)
            {
                bounceheight += (currentstate.y_position - desiredstate.y_position);

                if (bounceheight >= MAXBOUNCEHEIGHT)
                {

                    desiredstate.y_position += (bounceheight - MAXBOUNCEHEIGHT);
                    bounceheight = 0;
                    desiredstate.y_velocity = -desiredstate.y_velocity;
                }


            }

            y_force = 0;
            x_force = 0;

            /*
            if (desiredstate.x_velocity > 200f)
            {
                desiredstate.x_velocity = 200f;

            }
            if (desiredstate.x_velocity < -200f)
            {
                desiredstate.x_velocity = -200f;

            }
            if (desiredstate.y_velocity > 200f)
            {
                desiredstate.y_velocity = 200f;

            }
            if (desiredstate.y_velocity < -200f)
            {
                desiredstate.y_velocity = -200f;

            }
             * */

        }

    }

    public class PlayerObject : PhysicsObject
    {

        //public float halfheight = 16;
        //public float halfwidth = 8;
        public PlayerController playerInput;
        public bool invul;
        
        

        public PlayerObject(PlayerController p)
        {

            setId();

            currentstate = new PhysicalState();
            desiredstate = new PhysicalState();
            x_force = 0;
            y_force = 0;


            currentstate.x_position = 200;
            currentstate.y_position = 400;
            this.playerInput = p;
            this.type = "player";
            this.life = 30;
            this.invul = false;
            this.invultimer = 0;

            this.halfheight = 16;
            this.halfwidth = 8;

            //this.jumpcounter = 0;
            this.collisioncoefficient = 0;

        }

        public override void Update(float dt)
        {
            this.invul = false;

            if (this.invultimer > 0)
            {

                this.invultimer--;
            }
            if (this.jumpcounter > 0)
            {

                if (this.playerInput.UPKEY)
                {

                    this.jumpcounter--;
                }
                else
                {
                    this.jumpcounter = 0;
                    y_force += 4000;
                    
                }

            }


            if (currentstate.y_velocity == 0)
            {

                if (playerInput.LEFTKEY == true)
                {
                    //desiredstate.x_velocity = -30f;
                    if (currentstate.x_velocity > 0)
                    {
                        currentstate.x_velocity = 0;
                    }
                    else if (currentstate.x_velocity > -200)
                    {

                        x_force = x_force - 300;
                    }

                }
                else if (playerInput.RIGHTKEY == true)
                {

                    if (currentstate.x_velocity < 0)
                    {
                        currentstate.x_velocity = 0;
                    }
                    else if (currentstate.x_velocity < 200)
                    {
                        x_force = x_force + 300;
                    }


                    //desiredstate.x_velocity = 30f;

                }
                else
                {
                    currentstate.x_velocity = 0f;

                }

                if (playerInput.UPKEY == true)
                {

                    this.canBreak = true;
                    y_force = y_force - 8000;
                    this.jumpcounter = 12;
                }

            }
            else
            {

                if (playerInput.DOWNKEY)
                {
                    if (currentstate.y_velocity < 300)
                    {
                        y_force += 300;

                    }

                }

                if (playerInput.LEFTKEY == true)
                {
                    //desiredstate.x_velocity = -30f;
                    if (currentstate.x_velocity > -100)
                    {
                        x_force = x_force - 300;
                    }

                }
                else if (playerInput.RIGHTKEY == true)
                {
                    if (currentstate.x_velocity < 100)
                    {
                        x_force = x_force + 300;
                    }
                    //desiredstate.x_velocity = 30f;

                }
                


            }

            if (this.jumpcounter > 0)
            {
                //this.jumpcounter--;

            }
            else
            {
                y_force = y_force + GRAVITY+200;
            }

            desiredstate.y_velocity = (2 * currentstate.y_velocity + y_force * dt) / 2;
            desiredstate.x_velocity = (2 * currentstate.x_velocity + x_force * dt) / 2;
            //desiredstate.x_velocity = -40;

            desiredstate.y_position = currentstate.y_position + desiredstate.y_velocity*dt;
            desiredstate.x_position = currentstate.x_position + desiredstate.x_velocity*dt;

            y_force = 0;
            x_force = 0;
            
            if (desiredstate.x_velocity > 200f)
            {
                desiredstate.x_velocity = 200f;

            }
            if (desiredstate.x_velocity < -200f)
            {
                desiredstate.x_velocity = -200f;

            }
            if (desiredstate.y_velocity > 200f)
            {
                desiredstate.y_velocity = 200f;

            }
            if (desiredstate.y_velocity < -200f)
            {
                desiredstate.y_velocity = -200f;

            }
            

            //Debug.WriteLine("TEST : " + desiredstate.x_position);
        }



    }

    public class MobObject : PhysicsObject
    {

       
 

        public MobObject(float x, float y)
        {

            setId();

            currentstate = new PhysicalState();
            desiredstate = new PhysicalState();
            x_force = 0;
            y_force = 0;


            currentstate.x_position = x;
            currentstate.y_position = y;
            currentstate.x_velocity = 16;

            this.type = "mob";
            this.life = 2;

            this.halfheight = 11.5f;
            this.halfwidth = 8;

            
            this.collisioncoefficient = 1;

        }

        public override void RegisterHit(PhysicsObject po)
        {
            //base.RegisterHit(po);
            if (this.life < 1)
            {
                if (this.type == "mob")
                {
                    this.type = "shell";
                    this.life++;

                    this.desiredstate.y_position += (10);

                    this.halfheight = 8;

                    this.desiredstate.x_velocity = 0;


                }
                else if (this.type == "shell")
                {

                    this.life++;
                    this.type = "movingshell";


                    if (po.desiredstate.x_position > this.desiredstate.x_position)
                    {
                        this.desiredstate.x_velocity += -200;

                    }
                    else
                    {
                        this.desiredstate.x_velocity += 200;

                    }


                }
                else if (this.type == "movingshell")
                {
                    this.life++;
                    this.type = "shell";
                    this.desiredstate.x_velocity = 0;

                }

            }

        }

        public override void Update(float dt)
        {


            if (this.invultimer > 0)
            {
                this.invultimer--;

            }


            y_force = y_force + GRAVITY;
            desiredstate.y_velocity = (2 * currentstate.y_velocity + y_force * dt) / 2;
            desiredstate.x_velocity = (2 * currentstate.x_velocity + x_force * dt) / 2;
            //desiredstate.x_velocity = -40;

            desiredstate.y_position = currentstate.y_position + desiredstate.y_velocity * dt;
            desiredstate.x_position = currentstate.x_position + desiredstate.x_velocity * dt;

            y_force = 0;
            x_force = 0;

           


            //Debug.WriteLine("TEST : " + desiredstate.x_position);
        }



    }

    public class PhysicalState
    {

        public float x_velocity;
        public float y_velocity;
        public float x_position;
        public float y_position;

        public PhysicalState()
        {
            x_velocity = 0;
            y_velocity = 0;
            x_position = 0;
            y_position = 0;

        }

    }
}