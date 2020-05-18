using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.level_editor
{
    [System.Serializable]
    class TankProperties
    {

        public string levelName;
        public float ShootingSpeed;
        public float MovementSpeed;
        public float BarrelRotationSpeed;
        public float TriggerScale;
    }
}
