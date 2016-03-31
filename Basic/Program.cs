/*=============================================================================
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
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            asd.Engine.Initialize("Basic Game", 640, 480, new asd.EngineOption());

            var random = new System.Random();
            for(int i=0; i<10;i++)
            {
                var angle = random.NextDouble() * 2.0 * Math.PI;
                var speed = new asd.Vector2DF(5.0f*(float)Math.Cos(angle), 5.0F*(float)Math.Sin(angle));
                var pos = new asd.Vector2DF(random.Next() % 640, random.Next() % 480);
                var target = new Target(speed);
                target.Position = pos;
                asd.Engine.AddObject2D(target);
            }

            while (asd.Engine.DoEvents())
            {
                if (asd.Engine.CurrentScene.Layers.All(x => x.ObjectCount == 0))
                    break;
                asd.Engine.Update();
            }
            asd.Engine.Terminate();
        }
    }
}
