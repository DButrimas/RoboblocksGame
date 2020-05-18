using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Online_Level_Play
{
    [System.Serializable]
    class TopLevelScore
    {
        public float Complition_time;
        public float Blocks_used;
        public long LevelId;
        public string User;
    }
}
