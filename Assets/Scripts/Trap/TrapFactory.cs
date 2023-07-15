using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Trap
{
    public class TrapFactory
    {
        public Trap CreateTrap()
        {
            return new RandomSpikeTrap();
        }
    }
}
