using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace daggersRage
{
    public class LightEffect
    {

        public string type;

        public LightEffect()
        {

        }

    }

    public class LineEffect : LightEffect
    {

        public vector2 startpoint;
        public vector2 endpoint;

        public LineEffect()
        {
            this.type = "line";
            this.startpoint = new vector2();
            this.endpoint = new vector2();

        }


    }
}