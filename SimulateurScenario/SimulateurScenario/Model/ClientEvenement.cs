﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public abstract class ClientEvenement : Client
    {
        protected ClientEvenement() { }

        protected ClientEvenement(Position position)
            : base(position) {}
    }
}
