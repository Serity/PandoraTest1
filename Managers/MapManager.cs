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
