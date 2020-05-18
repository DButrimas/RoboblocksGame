using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Online_Level_Play
{
    [System.Serializable]
    class ObjectModel
    {
        public long id;

        public string name;

        public float posX;
        public float posY;
        public float posZ;

        public float scaleX;
        public float scaleY;
        public float scaleZ;

        public float rotationX;
        public float rotationY;
        public float rotationZ;

        public float r;
        public float g;
        public float b;

        public int levelId;

    }
}
