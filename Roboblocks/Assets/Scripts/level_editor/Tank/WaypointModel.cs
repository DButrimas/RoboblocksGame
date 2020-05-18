using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.level_editor
{
    [System.Serializable]
    class WaypointModel
    {
        public List<Waypoint> waypoints;

        public string LevelName;
    }
}
