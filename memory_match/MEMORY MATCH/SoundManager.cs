using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MEMORY_MATCH
{
    internal class SoundManager
    {
        public static SoundPlayer Player { get; set; }
        public static double Volume { get; set; }
        public static bool IsPlaying { get; set; }
    }
}
