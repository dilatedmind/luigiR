using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Timers;
using System.Diagnostics; // 1

namespace daggersRage
{
    public static class DaggersRage
    {

        public static DaggerGame daggersrage = new DaggerGame();
        public static DateTime stTime = DateTime.Now;


        public static void Update(object source, ElapsedEventArgs e)
        {

            
 
            //daggersrage.Update(.075f);
            daggersrage.Update(.045f);
            



            

        }

        public static void InitLevel()
        {
           

        }

        public static void SendState(object source, ElapsedEventArgs e)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<DaggerHub>();
            //context.Clients.All.updateGame(daggersrage.singleplayer.currentstate.x_position, daggersrage.singleplayer.currentstate.y_position);

            /*
            
            vector2 temp = new vector2();

            vector2 tempv = new vector2();

            temp.x = daggersrage.singleplayer.currentstate.x_position;
            temp.y = daggersrage.singleplayer.currentstate.y_position;

            tempv.x = daggersrage.singleplayer.currentstate.x_velocity;
            tempv.y = daggersrage.singleplayer.currentstate.y_velocity;

            context.Clients.All.updateGame(temp, tempv);
             * 
             * 
            */
            context.Clients.All.updateState(daggersrage.playerArray.ToArray());
            context.Clients.All.updateProjectiles(daggersrage.pointArray.ToArray());
            //context.Clients.All.updateEffects();


            if (daggersrage.updatedblocks.Count > 0)
            {

                context.Clients.All.updateBlocks(daggersrage.updatedblocks.ToArray());
                daggersrage.updatedblocks.Clear();
            }


            //context.Clients.All.updateProjectiles(daggersrage.pointArray.ToArray());

        }

        public static void SendClassicFireball(int id)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<DaggerHub>();

            PointObject temp = new PointObject(daggersrage.nextid);

            daggersrage.nextid++;

            PlayerObject result = (PlayerObject)daggersrage.playerArray.Find(x => x.id == id);

            if (result != null)
            {

                temp.currentstate.x_position = result.currentstate.x_position+result.playerInput.RECENTKEY*16;
                temp.currentstate.y_position = result.currentstate.y_position;


                temp.currentstate.y_velocity = (150);
                temp.currentstate.x_velocity = result.playerInput.RECENTKEY * 200;

                //temp.currentstate.y_position += result.currentstate.y_velocity;

                daggersrage.pointArray.Add(temp);


                context.Clients.All.addProjectile(temp.id, temp.currentstate);

            }


        }

        public static void SendMouseAngle(float rad, int id, int num)
        {

            var context = GlobalHost.ConnectionManager.GetHubContext<DaggerHub>();

            if (num == 1)
            {
                PointObject temp = new PointObject(daggersrage.nextid);

                daggersrage.nextid++;

                PlayerObject result = (PlayerObject)daggersrage.playerArray.Find(x => x.id == id);

                if (result != null)
                {

                    temp.currentstate.x_position = result.currentstate.x_position;
                    temp.currentstate.y_position = result.currentstate.y_position;


                    temp.currentstate.y_velocity = (float)(300 * Math.Sin(rad));
                    temp.currentstate.x_velocity = (float)(300 * Math.Cos(rad));

                    temp.currentstate.y_position += result.currentstate.y_velocity;

                    /*
                    if (temp.currentstate.y_velocity >= 0)
                    {
                        temp.currentstate.y_position += 16;

                    }
                    else
                    {

                        temp.currentstate.y_position -= 16;
                    }
                    */

                    daggersrage.pointArray.Add(temp);


                    context.Clients.All.addProjectile(temp.id, temp.currentstate);


                }

            }
            else
            {
                PlayerObject result = (PlayerObject)daggersrage.playerArray.Find(x => x.id == id);

                if (result != null)
                {

                    vector2 temp = daggersrage.beamProjection(result.currentstate.x_position, result.currentstate.y_position, rad, 160);

                    vector2 tempend = new vector2(result.currentstate.x_position, result.currentstate.y_position);

                 

                    context.Clients.All.addEffect(temp, tempend);
                }

            }
            //Debug.WriteLine("projectiles : " + daggersrage.pointArray.Count + "  latest : " + temp.id);

        }

        public static void SendMouse(int x, int y)
        {
            
            /*
            daggersrage.playerInput.MOUSEX = x;
            daggersrage.playerInput.MOUSEY = y;
            daggersrage.playerInput.MOUSEDOWN = true;

            Debug.WriteLine("mouse : " + x + "  " + y);
             * 
             * */
            
                //daggersrage.addBlock(x, y);
                daggersrage.AddMob(x, y);
            

        }

        public static void SendKey(int key, int down, int pid)
        {

            //PlayerController temp = daggersrage.playerInput;
            PlayerController temp = new PlayerController(); ;
           

            foreach (PlayerObject p in daggersrage.playerArray.OfType<PlayerObject>())
            {

             
                    if (p.id == pid)
                    {
                        temp = p.playerInput;

                    }

                

            }

            bool pressed = false;

            if (down == 1)
            {
                pressed = true;

            }

            if (key == 87)
            {
                //daggersrage.playerInput.UPKEY = pressed;
                temp.UPKEY = pressed;

            }
            else if (key == 83)
            {
                temp.DOWNKEY = pressed;
                //daggersrage.DOWNKEY = down;

            }
            else if (key == 65)
            {
                temp.LEFTKEY = pressed;
                temp.RECENTKEY = -1;
                //daggersrage.LEFTKEY = down;

            }
            else if (key == 68)
            {
                temp.RIGHTKEY = pressed;
                temp.RECENTKEY = 1;
                //daggersrage.RIGHTKEY = down;

            }

                
        }


    }

    public enum BlockType
    {
        Brick, Grass, Air

    }

    public class DaggerBlock
    {

        
        public bool isSolid;
        public BlockType blockType;
        

        public DaggerBlock()
        {

            this.isSolid = false;
            this.blockType = BlockType.Air;

        }

        public DaggerBlock(BlockType type)
        {

            this.isSolid = true;
            this.blockType = type;

        }

   

    }

    
}