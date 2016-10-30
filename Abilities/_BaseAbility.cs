using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.Abilities
{
    public abstract class _BaseAbility : Interfaces.ITargetable
    {
        public string sName;
        public bool canUseOutOfCombat;
        public bool hasPassiveEffect;
        public int cost; // todo: resource
        //public AnimationEffect animation; // in-battle animation including calling Effect()?

        // todo
        public abstract void Effect();
        public abstract bool ValidTarget();
        public abstract void DefaultTargetting();
    }
}
