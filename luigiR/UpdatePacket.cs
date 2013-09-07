using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace daggersRage
{
    public class UpdatePacket
    {

        public int id;
        public PhysicalState state;

        public UpdatePacket(int id, PhysicalState state)
        {

            this.id = id;
            this.state = state;

        }

    }
}