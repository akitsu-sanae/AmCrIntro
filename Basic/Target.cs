﻿/*=============================================================================
  Copyright (c) 2016 Akitsu Sanae
  https://github.com/akitsu-sanae/AmCrIntro
  Distributed under the Boost Software License, Version 1.0. (See accompanying
  file LICENSE or copy at http://www.boost.org/LICENSE_1_0.txt)
=============================================================================*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    class Target : asd.TextureObject2D
    {
        public Target(ref System.Random random)
        {
            this.Texture = asd.Engine.Graphics.CreateTexture2D("Resources/target.png");
            var angle = random.NextDouble() * 2.0 * Math.PI;
            this.speed = new asd.Vector2DF((float)Math.Cos(angle), (float)Math.Sin(angle)) * 5.0F;
            this.Position = new asd.Vector2DF(random.Next(0, asd.Engine.WindowSize.X), random.Next(0, asd.Engine.WindowSize.Y));
        }

        protected override void OnUpdate()
        {
            if (this.Position.X < 0 || this.Position.X > asd.Engine.WindowSize.X)
                this.speed.X *= -1;
            if (this.Position.Y < 0 || this.Position.Y > asd.Engine.WindowSize.Y)
                this.speed.Y *= -1;
            this.Position += this.speed;

            if ((asd.Engine.Mouse.Position - this.Position).Length < 16.0F)
                this.Dispose();
        }
        private asd.Vector2DF speed;
    }
}
