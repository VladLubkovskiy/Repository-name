﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicsWindow.Show();
            var p = Shapes.AddRectangle(100, 20);
            Shapes.Move(p,0, GraphicsWindow.Height - 20);
            GraphicsWindow.MouseMove += () => { Shapes.Move(p, GraphicsWindow.MouseX-50, GraphicsWindow.Height-20); };
            var c = Shapes.AddEllipse(20, 20);
            Timer.Interval = 10;
            int x = 0, y = 0,stepx=2,stepy=2;
            Timer.Tick += () => 
            {
                Shapes.Move(c, x+=stepx, y+=stepy);
                if (x >= GraphicsWindow.Width-20)
                {
                    stepx = -2;
                }
                if (x <= 0)
                {
                    stepx = 2;
                }
                if ((x>=GraphicsWindow.Width-50||x<=GraphicsWindow.Width+50)&&(y>=GraphicsWindow.Height-10))
                {
                    stepy = -2;
                }
                if (y <= 0)
                {
                    stepy = 2;
                }
            };
        }
    }
}