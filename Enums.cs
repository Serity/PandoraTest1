﻿using System;
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
}