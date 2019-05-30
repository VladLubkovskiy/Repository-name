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
            Primitive[] enemies = new Primitive[20];
            GraphicsWindow.BrushColor = "Gray";
            var c = Shapes.AddEllipse(20, 20);
            Timer.Interval = 10;
            int circleX = GraphicsWindow.Width/2, circleY = GraphicsWindow.Height/2,stepx=2,stepy=2, my = GraphicsWindow.Height - 40,mx = GraphicsWindow.MouseX;
            int enemyWidth = GraphicsWindow.Width / 10 - 5;
            Mouse.HideCursor();
            GraphicsWindow.BrushColor = "Red";
            for(int i = 0; i < 10; i++)
            {
                enemies[i] = Shapes.AddRectangle(enemyWidth, 20);
                Shapes.Move(enemies[i],i* (GraphicsWindow.Width / 10), 30);
            }
            for (int i = 0; i < 10; i++)
            {
                enemies[i] = Shapes.AddRectangle(enemyWidth, 20);
                Shapes.Move(enemies[i], i * (GraphicsWindow.Width / 10), 55);
            }

            Timer.Tick += () => 
            {
                my = GraphicsWindow.Height - 40;
                mx = GraphicsWindow.MouseX;
                Shapes.Move(c, circleX+=stepx, circleY+=stepy);
                if (circleX >= GraphicsWindow.Width-20)
                {
                    stepx = -stepx;
                }
                if (circleX <= 0)
                {
                    stepx = 4;
                }
                if ((circleX >= mx - 50 && circleX <= mx + 50) && (circleY >= my))
                {
                    stepy = -stepy;
                }
                if (circleY <= 0)
                {
                    stepy = 4;
                }
                if(circleY > GraphicsWindow.Height)
                {
                    Sound.PlayAndWait("1.mp3");
                    Microsoft.SmallBasic.Library.Program.End();
                }
                for (int i = 0; i < 10; i++)
                {
                    if ((circleX + 10 >= Shapes.GetLeft(enemies[i])) && (circleY <= Shapes.GetTop(enemies[i])+20)&&(circleX<=Shapes.GetLeft(enemies[i]) + enemyWidth))
                    {
                        Shapes.Move(enemies[i],9999,9999);
                        stepy = -stepy;
                    }
                }
            };
        }
    }
}
