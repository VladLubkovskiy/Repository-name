using System;
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
            int x = 0, y = 0,stepx=2,stepy=2, my = GraphicsWindow.Height - 40,mx = GraphicsWindow.MouseX;
            Timer.Tick += () => 
            {
                my = GraphicsWindow.Height - 40;
                mx = GraphicsWindow.MouseX;
                Shapes.Move(c, x+=stepx, y+=stepy);
                if (x >= GraphicsWindow.Width-20)
                {
                    stepx = -2;
                }
                if (x <= 0)
                {
                    stepx = 2;
                }
                if ((x >= mx - 50 && x <= mx + 50) && (y >= my))
                {
                    stepy = -2;
                }
                if (y <= 0)
                {
                    stepy = 2;
                }
                if(y > GraphicsWindow.Height)
                {
                    Sound.PlayAndWait("1.mp3");
                    Microsoft.SmallBasic.Library.Program.End();
                }
            };
        }
    }
}
