using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.Actors
{
    public class Actor
    {
        public string name;
        public ActorStat health = new ActorStat();
        public ActorStat mana = new ActorStat();

        public ActorStat strength = new ActorStat();
        public ActorStat agility = new ActorStat();
        public ActorStat dexterity = new ActorStat();

        public Actor() { }
        public void ModifyStats()
        {
            ClearStatChanges();

            ApplyEquipmentStats();
            ApplyStatusEffectsStats();
        }
        public void ClearStatChanges() {
            GetStatsList().ForEach(v => v.Reset());
        }
        public virtual void ApplyEquipmentStats() { } // move to PartyActor?
        public void ApplyStatusEffectsStats() { } // move to PartyActor?
        /// <summary>
        /// Returns instances of all of the actor's stats.
        /// Example: iterating through all stats to apply equipment effects
        /// </summary>
        public List<ActorStat> GetStatsList()
        {
            List<ActorStat> l = new List<ActorStat>();
            l.Add(health); l.Add(mana);
            l.Add(strength); l.Add(agility); l.Add(dexterity);
            return l;
        }
    }
}
