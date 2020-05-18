using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Online_Level_Play
{
    public static class TankPropsStatic
    {
        public static float ShootingSpeed;
        public static float MovementSpeed;
        public static float BarrelRotationSpeed;
        public static float TriggerScale;

        public static List<Waypoint> waypoints = new List<Waypoint>();

        public static UnityEngine.Vector3 Scale;
    }
}
