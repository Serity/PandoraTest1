using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1
{
    public static class Directions
    {
        public const int LEFT = 0;
        public const int UP = 1;
        public const int RIGHT = 2;
        public const int DOWN = 3;

        public static int DirectionToTileSide(int direction)
        {
            if (direction == LEFT) { return RIGHT; }
            else if (direction == UP) { return DOWN; }
            else if (direction == RIGHT) { return LEFT; }
            else { return UP; }
        }
    }
    public enum StateID
    {
        MainMenu,
        EscMenuScreen,
        BattleScreen,
        DebugSpritesheetScreen
    }
    public enum MapID
    {
        Town
    }
    public class Sheets
    {
        private Sheets(string v) { Value = v; }
        public string Value { get; set; }
        public static Sheets UI_Blue { get { return new Sheets("blueSheet"); } }
        public static Sheets UI_Green { get { return new Sheets("greenSheet"); } }
        public static Sheets UI_Grey { get { return new Sheets("greySheet"); } }
        public static Sheets UI_Red { get { return new Sheets("redSheet"); } }
        public static Sheets UI_Yellow { get { return new Sheets("yellowSheet"); } }

        public static Sheets Lorc { get { return new Sheets("lorc_100_spritesheet_transparent-0"); } }
        public static Sheets GIN_BT { get { return new Sheets("gameiconsnet-spritesheet-transparent-0"); } }
        public static Sheets GIN_WT { get { return new Sheets("gameiconsnet-spritesheet-transparent-invert-0"); } }
        public override string ToString()
        {
            return Value;
        }
    }
}
