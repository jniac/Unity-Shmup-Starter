﻿using System;

namespace Kit
{
    public partial class Anim
    {
        public static void Next(Action callback, object key = null)
            => new Anim(key, anim => callback(), 0, 0, true);
    }
}
