using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public abstract class Command_package<T> where T : Enum
    {
        public T Command { get; private set; }

        // the enum used as the generic type should be defined in a child class

        public Command_package(T command)
        {
            Command = command;
        }
    }
}
