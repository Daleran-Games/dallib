using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.PixelArt
{
    public static class PixelPerfect
    {
        public const int PixelsPerUnit = 1;
        public const float UnitsInPixels = 1 / PixelsPerUnit;

        static int scale = 1;
        public static int Scale
        {
            get { return scale; }
            set
            {
                if (value > 0)
                {
                    scale = value;
                    ScaleChanged?.Invoke(scale);
                }
            }
        }
        public static event Action<int> ScaleChanged;

        public static void CaluclateResolution()
        {

        }
    }
}

