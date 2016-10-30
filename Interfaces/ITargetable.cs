using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.Interfaces
{
    public interface ITargetable
    {
        bool ValidTarget(/*Actor target, Actor invoker = null*/);
        void DefaultTargetting(); // 
    }
}
