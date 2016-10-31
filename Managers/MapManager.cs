using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.Managers
{
    public class MapManager
    {
        public static Dictionary<MapID, Map> MapList = new Dictionary<MapID, Map>();
        public static Map currentMap;

        static MapManager()
        {
            // todo: later when more maps, just start off with MapList.Add(MapID.X, null), then load them as we need them?

            MapList.Add(MapID.Town, new Maps.TownTest());
        }

        public static Map GetMap(MapID m)
        {
            Map val;
            MapList.TryGetValue(m, out val);
            return val;
        }
    }
}
