// Include code libraries you need below (use the namespace).
using System;
using System.ComponentModel.Design;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    ///     Your game code goes inside this class!
    public class Game
    {
        // Place your variables here:
        //colors
        Color skyColor = new Color(0x0f, 0x2a, 0x3f);
        Color moonColor = new Color(0xf6, 0xd6, 0xbd);
        Color starColor = new Color(0xc3, 0xa3, 0x8a);
        Color fenceColor = new Color(0x08, 0x14, 0x1e);
        Color bodyColor = new Color(0x4e, 0x49, 0x5f);
        Color noseColor = new Color(0x81, 0x62, 0x71);
        Color handColor = new Color(0xac, 0x7c, 0x65);

        //X and Y Coordinates for stars
        float[] xCoord = [];
        float[] yCoord = [];
        float starSize = 1;
        //Random eye color generator variables
        Color[] eyeColor = [new Color(0xf9, 0xcb, 0x60), new Color(0xbe, 0xdc, 0x7f)];
        bool randomEye = Random.Bool();
        public void Setup()
        {
            Window.SetTitle("Pet that kitty!");
            Window.SetSize(400, 400);
            Window.TargetFPS = 60;
            //generate random star placement
            int starCount = 50;
            xCoord = new float[starCount];
            yCoord = new float[starCount];

            for (int i = 0; i < starCount; i++)
            {
                xCoord[i] = Random.Integer(0, 400);
                yCoord[i] = Random.Integer(0, 400);
            }
        }
        public void Update()
        {
            Window.ClearBackground(skyColor);
            //variables for head petting
            float cursorX = Input.GetMouseX();
            float cursorY = Input.GetMouseY();
            //places stars
            Draw.FillColor = starColor;
            for (int i = 0; i < 50; i++)
            {
                Draw.Circle(xCoord[i], yCoord[i], starSize);
            }
            //Moon
            Draw.FillColor = moonColor;
            Draw.LineColor = Color.Clear;
            Draw.Circle(350, 50, 30);
            //Moon gap
            Draw.FillColor = skyColor;
            Draw.LineColor = Color.Clear;
            Draw.Circle(330, 50, 20);
            //Fence support
            Draw.FillColor = fenceColor;
            Draw.Rectangle(20, 360, 370, 30);
            //Fence
            for (int i = 0; i < 5; i++)
            {
                int xOffset = i * 100;
                Draw.Capsule(0 + xOffset, 350, xOffset, 450, 40);
            }
            //draws cat body and head
            CatDrawingBody(200, 200);
            CatDrawingHead(200, 200);
            //creates head petting zone
            if (cursorX <= 200 && cursorX >= 100 && cursorY <= 80 && cursorY >= 20)
            {
                EarsDown(200, 200);
                EyesClosed(200, 200);
            }
            else
            {
                EarsUp(200, 200);
            }
            //creates hand to pet cat
            CatCursor(Input.GetMouseX(), Input.GetMouseY());
        }
        void CatDrawingBody(float x, float y)
        {
            //fur color
            Draw.FillColor = bodyColor;
            //body
            Draw.Capsule(170, 160, 230, 260, 50);
            Draw.Circle(220, 270, 60);
            //tail
            Draw.Capsule(260, 310, 210, 400, 20);
            Draw.Capsule(260, 390, 210, 420, 15);
            Draw.Capsule(290, 360, 270, 390, 20);
        }
        void EarsUp(float x, float y)
        {
            //ears in resting position (pointed up)
            Draw.FillColor = bodyColor;
            Draw.Triangle(120, 20, 100, 90, 140, 60);
            Draw.Triangle(180, 20, 160, 60, 200, 90);
        }
        void EarsDown(float x, float y)
        {
            //ears in pet position (pointed down)
            Draw.FillColor = bodyColor;
            Draw.Triangle(80, 50, 140, 50, 110, 90);
            Draw.Triangle(160, 50, 220, 50, 190, 90);
        }
        void CatDrawingHead(float x, float y)
        {
            Draw.FillColor = bodyColor;
            Draw.Circle(150, 100, 50);
            //generates random eye color
            for (int i = 0; i < 1; i++)
            {
                if (randomEye == true)
                {
                    Draw.FillColor = (eyeColor[0]);
                }
                else if (randomEye == false)
                {
                    Draw.FillColor = (eyeColor[1]);
                }
            }
            Draw.Ellipse(125, 95, 30, 45);
            Draw.Ellipse(175, 95, 30, 45);
            //pupils
            Draw.FillColor = Color.Black;
            Draw.Capsule(125, 85, 125, 105, 3);
            Draw.Capsule(175, 85, 175, 105, 3);
            //nose
            Draw.FillColor = noseColor;
            Draw.Triangle(140, 110, 160, 110, 150, 120);
        }
        void EyesClosed(float x, float y)
        {
            //creates outline of closed eyes
            Draw.FillColor = Color.Black;
            Draw.Ellipse(125, 95, 30, 45);
            Draw.Ellipse(175, 95, 30, 45);
            //covers resting state eyes
            Draw.FillColor = bodyColor;
            Draw.Ellipse(125, 92, 30, 45);
            Draw.Ellipse(175, 92, 30, 45);
        }
        void CatCursor(float x, float y)
        {
            //creates circle to make petting transition look less awkward
            Draw.FillColor = handColor;
            Draw.Circle(Input.GetMouseX(), Input.GetMouseY(), 20);
        }
    }
}
