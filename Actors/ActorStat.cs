using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.Actors
{
    public class ActorStat
    {
        public int BaseValue;
        public int CurrentValue
        {
            get { return BaseValue + Modifier; }
            set
            {
                BaseValue = value;
                if (MaximumValue == 0) { MaximumValue = BaseValue; }
                Validate();
            }
        }
        public int MaximumValue;
        public int Modifier;

       
        public void Reset() { Modifier = 0; /*_canOverflow = false; _canUnderflow = false;*/ }
        public int Set(int c, int m) { MaximumValue = m; Set(c); return CurrentValue; }
        public int Set(int i) { CurrentValue = i; return CurrentValue; }

        public int Restore(int i) { return CurrentValue += i; }
        public int Damage(int i) { return CurrentValue -= i; }
        public int Buff(int i) { return Modifier += i; }
        public int Debuff(int i) { return Modifier -= i; }

        public int Validate(bool forceOverflow = false, bool forceUnderflow = false)
        {
            if (/*canOverflow && !forceOverflow && */CurrentValue > MaximumValue) { CurrentValue = MaximumValue; }
            else if (/*canUnderflow && !forceUnderflow && */CurrentValue < 0) { CurrentValue = 0; }
            return CurrentValue;
        }
        public decimal AsPercent { get { return (decimal)CurrentValue / (decimal)MaximumValue; } }


        public static implicit operator int(ActorStat stat) { return stat.CurrentValue; }
        public static ActorStat operator -(ActorStat hp, int i) { hp.CurrentValue -= i; return hp; }
        public static ActorStat operator +(ActorStat hp, int i) { hp.CurrentValue += i; return hp; }
        public static ActorStat operator *(ActorStat hp, int i) { hp.CurrentValue *= i; return hp; }
        public static ActorStat operator /(ActorStat hp, int i) { hp.CurrentValue /= i; return hp; }
        public override string ToString() { return CurrentValue.ToString(); }
        /*
        public bool forceCanOverflow = false; // for mobs
        public bool forceCanUnderflow = false; // for mobs
        public bool _canOverflow = false; // reset to 0 before applying eq/buffs
        public bool _canUnderflow = false; // reset to 0 before applying eq/buffs
        public bool canOverflow
        {
            get { return forceCanOverflow || _canOverflow; }
            set { _canOverflow = value; }
        }
        public bool canUnderflow
        {
            get { return forceCanUnderflow || _canUnderflow; }
            set { _canUnderflow = value; }
        }
        */
    }
}
