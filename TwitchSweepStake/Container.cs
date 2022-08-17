using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TwitchSweepStake
{
    public static class Container
    {
        public struct Member
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }

        public static MediaPlayer mediaPlayer = null!;
        internal static Bot bot = null!; 
        internal static List<string> members = null!;
        internal static string winner = null!;
        internal static List<Member> fileMembers = null!;
    }
}
