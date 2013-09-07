function State(state) {

    var self = this;
    
    this.x_position = state.x_position;
    this.y_position = state.y_position;
    this.x_velocity = state.x_velocity;
    this.y_velocity = state.y_velocity;
   
    
   
    

};

function eLine(point1, point2) {

    this.p1x = point1.x;
    this.p1y = point1.y;
    this.p2x = point2.x;
    this.p2y = point2.y;
    this.lifespan = 10;

}

function dProj(newid, newstate, type) {
    var self = this;
    this.id = newid;
    
    this.type = type;
    this.life = 0;
    this.state = new State(newstate);
    this.oldstate = new State(newstate);
    this.halfheight = 16;
    this.halfwidth = 8;

    self.updateState = function (newstate) {

        this.oldstate.x_position = this.state.x_position;
        this.oldstate.y_position = this.state.y_position;
        this.oldstate.x_velocity = this.state.x_velocity;
        this.oldstate.y_velocity = this.state.y_velocity;

        this.state.x_position = newstate.x_position;
        this.state.y_position = newstate.y_position;
        this.state.x_velocity = newstate.x_velocity;
        this.state.y_velocity = newstate.y_velocity;

    };


    //var alive = true;
 

};

function KeyboardState() {

    var self = this;

    self.upkey = false;
    self.downkey = false;
    self.leftkey = false;
    self.rightkey = false;
    
    self.setKey = function (keynum) {

        if (keynum == 87) {

            self.upkey = false;



        }
        else if (keynum == 83) {

            self.downkey = false;




        }
        else if (keynum == 65) {



            self.leftkey = false;

        }
        else if (keynum == 68) {


            self.rightkey = false;

        }

    };

    self.checkKey = function (keynum) {

        if (keynum == 87) {
            if (self.upkey === false) {
                self.upkey = true;

                return true;
            }

        }
        else if (keynum == 83) {
            if (self.downkey === false) {
                self.downkey = true;
                return true;


            }
        }
        else if (keynum == 65) {

            if (self.leftkey === false) {

                self.leftkey = true;
                return true;
            }
        }
        else if (keynum == 68) {
            if (self.rightkey === false) {

                self.rightkey = true;
                return true;
            }
        }

        return false;
    };

    

}


$(function () {

 
    //display frame 



    var self = this;
    var mapx, mapy;
    var MYID = -1;

    var selectedability = 1;

    var d = new Date();
    

    var NEWUPDATE = 1;
    var OLDUPDATE = 1;

    var CANVASHEIGHT = 500;
    var CANVASWIDTH = 800;

   
    
    $('#daggerctx').bind("contextmenu", function (event) {
        event.preventDefault();

        
        
    });

    
    
 

    var turtle = new Image();
    turtle.src = 'img/turtle.gif';

    var shell = new Image();
    shell.src = 'img/shell.gif';

    var tile1 = new Image();
    tile1.src = 'img/red.gif';

    var tile2 = new Image();
    tile2.src = 'img/brickoverlay.gif';

    var tile3 = new Image();
    tile3.src = 'img/yellowtile.bmp';

    var player1 = new Image();
    player1.src = 'img/luigi.gif';

    var playerleft = new Image();
    playerleft.src = 'img/luigileft.gif';

 

    var hub = $.connection.daggerHub;

    var keyboard = new KeyboardState();

    var parray = [];
    var parraylength = 0;

  
    var playerarray = [];
    var playerarraylength = 0;

    var effectarray = [];
    var effectarraylength = 0;


    var leveldata = [];
    var levelwidth = 50;
    var levelheight = 50;
    var wtfx = 200;
    var wtfy = 200;
    var wtfvx = 0;
    var wtfvy = 0;
    var wtfleft = false;
    var wtflife = 30;

    var oldwtfx = 200;
    var oldwtfy = 200;

    var offsetx = 600-oldwtfx;
    var offsety = 400-oldwtfy;


    var prox = 0;
    var proy = 0;

    

    hub.client.addProjectile = function (id, state) {

        

        parray[parraylength] = new dProj(parseFloat(id), state, "p");
        parraylength++;



    };

    hub.client.addEffect = function (startpoint, endpoint) {

        //alert(startpoint.x + "  " + startpoint.y + "  " + endpoint.x + "  " + endpoint.y);

        effectarray[effectarraylength] = new eLine(startpoint, endpoint);
        effectarraylength++;

    }

    hub.client.updateProjectiles = function (arr) {

        //var newproj;

        $.each(arr, function (index, proj) {

            //newproj = 1;

            for (var i = parraylength-1; i >= 0; i--) {

                if (parray[i].id == proj.id) {


                    newproj = 0;

                    if (proj.life < 1) {
                        parray.splice(i, 1);
                        parraylength--;
                    }
                    else {

                        parray[i].updateState(proj.currentstate);
                    }
                    /*
                    parray[i].state.x_position = proj.currentstate.x_position;
                    parray[i].state.y_position = proj.currentstate.y_position;
                    parray[i].state.x_velocity = proj.currentstate.x_velocity;
                    parray[i].state.y_velocity = proj.currentstate.y_velocity;
                    */
                    break;

                }

                

            }
            /*
            if (newproj == 1) {

                parray.push(new dProj(proj.id, proj.currentstate));
                parraylength++;

            }
            */


        });
        

    };



    hub.client.updateState = function (objectarray) {

        var newplayerobject = true;

        

        $.each(objectarray, function (index, object) {

            
            newplayerobject = true;

            if (parseFloat(object.id) == MYID) {

                wtflife = object.life;
                oldwtfx = wtfx;
                oldwtfy = wtfy;
                OLDUPDATE = NEWUPDATE;
                d = new Date();
                NEWUPDATE = d.getTime();



                wtfx = parseFloat(object.currentstate.x_position);
                wtfy = parseFloat(object.currentstate.y_position);

                if (wtfx > oldwtfx) {
                    wtfleft = false;
                }
                else if (wtfx < oldwtfx) {
                    wtfleft = true;
                }

                newplayerobject = false;

            }
            else {

                $.each(playerarray, function (index2, pl) {

                    if (parseFloat(object.id) == pl.id) {

                        pl.updateState(object.currentstate);
                        pl.life = object.life;
                        newplayerobject = false;

                        if (object.type == "shell") {

                            pl.type = shell;
                            pl.halfheight = object.halfheight;

                        }

                    }

                });

            }

            if (newplayerobject) {

                if (object.type == "mob") {
                    playerarray[playerarraylength] = new dProj(parseFloat(object.id), object.currentstate, turtle);
                }
                else if (object.type == "player") {

                    playerarray[playerarraylength] = new dProj(parseFloat(object.id), object.currentstate, player1);
                }
                else {
                    playerarray[playerarraylength] = new dProj(parseFloat(object.id), object.currentstate, shell);

                }
                playerarray[playerarraylength].halfheight = object.halfheight;
                playerarraylength++;
            }


        });

        


    };

    hub.client.updateBlocks = function (blocks) {

        $.each(blocks, function (index, b) {

            leveldata[parseInt(b.x)][parseInt(b.y)] = parseInt(b.value);

        });

    };

    hub.client.updateGame = function (temp, tempv) {
        
        oldwtfx = wtfx;
        oldwtfy = wtfy;

        OLDUPDATE = NEWUPDATE;
        d = new Date();
        NEWUPDATE = d.getTime();

        wtfx = parseFloat(temp.x);
        wtfy = parseFloat(temp.y);
      
        wtfvx = parseFloat(tempv.x);
        wtfvy = parseFloat(tempv.y);
        

    };

    hub.client.initLevel = function (maparray, newpid, width, height) {

        MYID = newpid;
        levelwidth = width;
        levelheight = height;


        

        $.each(maparray, function (index, row) {

            leveldata[index] = [];

            $.each(row, function (index2, tile) {

                leveldata[index][index2] = parseInt(tile);
                

            });

            

        });

        

            

        

    };

   

    
   
    
    


    

    

    var ctx = document.getElementById('daggerctx').getContext('2d');
    ctx.fillStyle = "red";
    ctx.fillRect(0, 0, 1200, 800);

    


    window.onbeforeunload = function () {
        
        //hub.server.printLevel();

    };
    

    $(document).keydown(function (e) {


        var keyid = e.which;

        if ((keyid == 87) || (keyid == 83) || (keyid == 65) || (keyid == 68)) {

            //keyboard.setkeydown(keyid, MYID);

            if (keyboard.checkKey(keyid)) {

                hub.server.sendKey(keyid, 1, MYID);
            }

        }
        else if (keyid == 49) {

            selectedability = 1;

        }
        else if (keyid == 50) {

            selectedability = 2;

        }


    });

    $(document).keyup(function (e) {


        var keyid = e.which;

        if ((keyid == 87) || (keyid == 83) || (keyid == 65) || (keyid == 68)) {

            //keyboard.setkeyup(keyid, MYID);
            keyboard.setKey(keyid);
            hub.server.sendKey(keyid,0, MYID);

        }

    });

    
    $("#daggerctx").mousedown(function (e) {

        if (e.which > 1) {
            //right click
            hub.server.sendMouse(mapx, mapy);
        }
        else {
            var tempa = 0;
            tempa = Math.atan((mapy - wtfy) / (mapx - wtfx));

            if ((mapx - wtfx) < 0) {

                tempa = tempa + 3.14;
            }
            else if ((mapy - wtfy) < 0) {

                tempa = tempa + 3.14 + 3.14;
            }


            hub.server.sendMouseAngle(tempa, MYID, selectedability);
        }
        return false;

    });
    
    
    $("#daggerctx").mousemove(function (e) {

        mapx = e.pageX - this.offsetLeft + offsetx;
        mapy = e.pageY - this.offsetTop + offsety;

        
    });

    


 


    $.connection.hub.start().done(function () {



        //myName = prompt('Enter your name:', 'noname');


        hub.server.initData();
        $('#sendmessage').click(function () {


            

            self.draw();
            //physicsLoopId = window.setInterval(self.Update, 50);

            $('#sendmessage').css("visibility", "hidden");




        });






    });

    //left to right

    self.Update = function () {
        /*
        for (var ii = 0; ii < parraylength; ii++) {


            parray[ii].state.x_position = parray[ii].state.x_position + parray[ii].state.x_velocity * .1;
            parray[ii].state.y_position = parray[ii].state.y_position + parray[ii].state.y_velocity * .1;

           

        }
        */
        
    };


    

    self.draw = function () {

        var requestAnimationFrame = window.requestAnimationFrame || window.mozRequestAnimationFrame || window.webkitRequestAnimationFrame || window.msRequestAnimationFrame;
        d = new Date();
        var RENDERTIME = d.getTime() - NEWUPDATE;

        var RATIO = RENDERTIME / 100;

       

        if (RATIO > 1) {

            RATIO = 1;

        }

        
        var newoffsetx = Math.floor(((wtfx * RATIO) + (oldwtfx * (1 - RATIO)))-(CANVASWIDTH/2));
        var newoffsety = Math.floor(((wtfy * RATIO) + (oldwtfy * (1 - RATIO))) - (CANVASHEIGHT/2));


        if (((newoffsetx - offsetx)*(newoffsetx - offsetx)) >= 4) {

            offsetx = newoffsetx;

        }

        if (((newoffsety - offsety)*(newoffsety - offsety)) >= 4) {

            offsety = newoffsety;

        }

        if (offsetx > levelwidth * 16 - CANVASWIDTH) {

            offsetx = levelwidth * 16 - CANVASWIDTH;

        }
        else if (offsetx < 0) {

            offsetx = 0;

        }
        

        if (offsety > levelheight * 16 - CANVASHEIGHT) {

            offsety = levelheight * 16 - CANVASHEIGHT;

        }
        else if (offsety < 0) {

            offsety = 0;

        }


        ctx.clearRect(0, 0, CANVASWIDTH, CANVASHEIGHT);
        ctx.fillStyle = "#7C6EFF"

        for (var i = 0; i < levelwidth; i++) {
            for (var j = 0; j < levelheight; j++) {
                
                if (leveldata[i][j] == 0) {

                    
                    ctx.fillStyle = "#7C6EFF"
                    ctx.fillRect(i * 16-offsetx, j * 16-offsety, 16, 16)
                    


                }
                else {

                    if (leveldata[i][j] == 1) {

                        ctx.fillStyle = "#daa520"
                        ctx.fillRect(i * 16 - offsetx, j * 16 - offsety, 16, 16)

                    }
                    else if (leveldata[i][j] == 2) {

                        ctx.fillStyle = "#d2691e"
                        ctx.fillRect(i * 16 - offsetx, j * 16 - offsety, 16, 16)

                    }
                    else if (leveldata[i][j] == 3) {

                        ctx.fillStyle = "#a52a2a"
                        ctx.fillRect(i * 16 - offsetx, j * 16 - offsety, 16, 16)

                    }
                    else {
                        //ctx.fillRect(i * 16, j * 16, 16, 16)
                        ctx.drawImage(tile3, i * 16 - offsetx, j * 16 - offsety);
                    }

                    ctx.drawImage(tile2, i * 16 - offsetx, j * 16 - offsety);

                }
            }
        }

        ctx.font = "12px Arial";
        ctx.fillStyle = "black";

        if (wtfleft == true) {

            ctx.drawImage(playerleft, ((wtfx * RATIO) + (oldwtfx * (1 - RATIO)) - 8) - offsetx, ((wtfy * RATIO) + (oldwtfy * (1 - RATIO)) - 16) - offsety);


        }
        else {
            
            ctx.drawImage(player1, ((wtfx * RATIO) + (oldwtfx * (1 - RATIO)) - 8) - offsetx, ((wtfy * RATIO) + (oldwtfy * (1 - RATIO)) - 16) - offsety);

        }

        ctx.fillText(wtflife, (wtfx * RATIO) + (oldwtfx * (1 - RATIO)) - 8 - offsetx, (wtfy * RATIO) + (oldwtfy * (1 - RATIO)) - 16 - offsety);


        $.each(playerarray, function (index, pl) {

            

            //ctx.drawImage(player1, pl.state.x_position - 8 - offsetx, pl.state.y_position - 16 - offsety);
            ctx.drawImage(pl.type, (pl.state.x_position * RATIO) + (pl.oldstate.x_position * (1 - RATIO)) - 8 - offsetx, (pl.state.y_position * RATIO) + (pl.oldstate.y_position * (1 - RATIO)) - 16 + (16 - pl.halfheight) - offsety);

            ctx.fillText(pl.life, (pl.state.x_position * RATIO) + (pl.oldstate.x_position * (1 - RATIO)) - 8 - offsetx, (pl.state.y_position * RATIO) + (pl.oldstate.y_position * (1 - RATIO)) - 16 + (16 - pl.halfheight) - offsety);
            //ctx.fillText(pl.life, pl.state.x_position - 8 - offsetx, pl.state.y_position - 16 - offsety);

        });

        

        
        
       

        for (var ii = 0; ii < parraylength; ii++) {

            //some kind of interpolation between two most recent states
            ctx.drawImage(tile1, (parray[ii].state.x_position * RATIO) + (parray[ii].oldstate.x_position * (1 - RATIO)) - 8 - offsetx, (parray[ii].state.y_position * RATIO) + (parray[ii].oldstate.y_position * (1 - RATIO)) - 8 - offsety);

        }


        for (var iii = 0; iii < effectarraylength; iii++) {

            if (effectarray[iii].lifespan > 0) {

                ctx.beginPath();
                ctx.moveTo(effectarray[iii].p1x - offsetx, effectarray[iii].p1y - offsety);
                ctx.lineTo(effectarray[iii].p2x - offsetx, effectarray[iii].p2y - offsety);
                ctx.strokeStyle = '#00ffff';
                ctx.stroke();
                effectarray[iii].lifespan--;

            }

        }


        requestAnimationFrame(self.draw);



    };






});