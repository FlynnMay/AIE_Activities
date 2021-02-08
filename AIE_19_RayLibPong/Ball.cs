using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AIE_19_RayLibPong
{
    class Ball
    {
        public Vector2 dir = new Vector2();
        public Vector2 pos = new Vector2();
        public float speed = 5.0f;
        public float resetSpeed = 5.0f;
        public float radius = 10.0f;
    }
}
