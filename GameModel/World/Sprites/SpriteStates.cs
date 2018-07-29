using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    static class SpriteStates
    {
        public static byte Offensive = 0;

        public static byte Defensive = 1;

        public static byte FurtiveLeft = 2;

        public static byte FurtiveRight = 3;

        public static byte Jump = 4;

        public static byte Crouch = 5;

        public static byte Stand = 6;

        public static byte Attack = 7;

        public static byte Block = 8;

        public static byte OpenToAttack = 9;

        public static byte FastAttack = 10;

        public static byte StrongAttack = 11;

        public static byte SpinCharge = 12;
    }
}
