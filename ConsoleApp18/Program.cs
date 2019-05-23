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
            Primitive[] enemies = new Primitive[10];
            GraphicsWindow.BrushColor = "Gray";
            var c = Shapes.AddEllipse(20, 20);
            Timer.Interval = 10;
            int x = 0, y = 0,stepx=2,stepy=2, my = GraphicsWindow.Height - 40,mx = GraphicsWindow.MouseX;
            Mouse.HideCursor();
            GraphicsWindow.BrushColor = "Red";
            for(int i = 0; i < 10; i++)
            {
                enemies[i] = Shapes.AddRectangle(GraphicsWindow.Width/10, 20);
                Shapes.Move(enemies[i],i* (GraphicsWindow.Width / 10), 0);
            }          
            Timer.Tick += () => 
            {
                my = GraphicsWindow.Height - 40;
                mx = GraphicsWindow.MouseX;
                Shapes.Move(c, x+=stepx, y+=stepy);
                if (x >= GraphicsWindow.Width-20)
                {
                    stepx = -4;
                }
                if (x <= 0)
                {
                    stepx = 4;
                }
                if ((x >= mx - 50 && x <= mx + 50) && (y >= my))
                {
                    stepy = -4;
                }
                if (y <= 0)
                {
                    stepy = 4;
                }
                if(y > GraphicsWindow.Height)
                {
                    Sound.PlayAndWait("1.mp3");
                    Microsoft.SmallBasic.Library.Program.End();
                }
                for (int i = 0; i < 10; i++)
                {
                    if ((x + 10 == Shapes.GetLeft(enemies[i])) && (y == Shapes.GetTop(enemies[i])))
                    {
                        Shapes.HideShape(enemies[i]);
                    }
                }
            };
        }
    }
}
