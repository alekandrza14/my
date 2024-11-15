﻿using OpenTK.Input;

namespace MyEngine { 
    public static class Const
    {
        public const string APP_NAME = "MyEngine";
        public const string RELEASE_DATE = "11 Jan 2019";

        public const string FRAGMENT_FILENAME = "MyEngine.rayres.shaders.fragment.c";
        public const string VERTEX_FILENAME = "MyEngine.rayres.shaders.vertex.c";
        public const string GEOMETRY_FILENAME = "MyEngine.rayres.shaders.geometry.c";

        public const string UBO_SDELEMENTSMAP_BLOCKNAME = "SdElements";
        public const int UBO_SDELEMENTSMAP_BLOCKCOUNT = 256;
        public const string UF_TIMER = "iGlobalTime";
        public const string UF_RESOLUTION = "iResolution";
        public const string UF_RAY_ORIGIN = "ro";
        public const string UF_PROJECTION_MATRIX = "camProj";

        public const float PLAYER_HIT_RADIUS = 0.0f;

        public const float INPUT_UPDATE_INTERVAL = 10; // every ms
        public const Key INPUT_KEY_FULLSCREEN = Key.F11;
        public const Key INPUT_KEY_EXIT = Key.Escape;

        public const int DISPLAY_BITPERPIXEL = 32;
        public const int DISPLAY_REFRESH_RATE = 60;
        public const int DISPLAY_FULLHD_W = 1920;
        public const int DISPLAY_FULLHD_H = 1080;
        public const int DISPLAY_XGA_W = 1024;
        public const int DISPLAY_XGA_H = 768;
    }
}
