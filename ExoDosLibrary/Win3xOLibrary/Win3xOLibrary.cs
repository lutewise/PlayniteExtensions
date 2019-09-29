using ExoDosLibrary;
using Playnite.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoDosLibrary
{
    public class Win3xOLibrary : ExoDosLibrary
    {
        public override string Name => "Win3xO";

        public override string Source => "Win3xO";

        public override Guid Id => Guid.Parse("C3B5AF42-ECD1-4784-BCF8-8AAA07C88A79");

        public Win3xOLibrary(IPlayniteAPI api) : base(api) { }

        public override string BaseDir => @"J:\Emuladores\Win3xO\";
        public override string GamesDir { get { return BaseDir + @"Games\!win3x\"; } set { GamesDir = value; } }

    }
}
