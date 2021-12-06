using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using UnityEngine;
using UnhollowerRuntimeLib;


namespace SDraw
{
    public class sdraw : MonoBehaviour
    {

        public sdraw(IntPtr ptr) : base(ptr) { }
        private Plugin loader;

        public static void CreateInstance()
        {
            // Register MonoBehaviour in IL2CPP
            ClassInjector.RegisterTypeInIl2Cpp<sdraw>();

            // Create GameObject
            GameObject obj = new GameObject("sdraw gui object");
            DontDestroyOnLoad(obj);
            obj.hideFlags |= HideFlags.HideAndDontSave;

            // Add CheatObject Component
            obj.AddComponent<sdraw>();
        }

      
        public void OnGUI()
        {
            SDrawRect(new Rect(50, 50, 200, 100), Color.black, Color.green, 5);
            if (SDrawButton(new Rect(70, 70, 150, 40),"lol", Color.black, Color.white,5))
            {
                
            }
        }



        public static void SDrawRect(Rect rect,Color color, Color bordercolor, int BorderSizePixel)
        {
            DrawRect(rect, bordercolor);
            DrawRect(new Rect(rect.x + BorderSizePixel, rect.y + BorderSizePixel, rect.width - BorderSizePixel * 2, rect.height - BorderSizePixel * 2),color);
           

        }


        public static bool SDrawButton(Rect rect,string text, Color color, Color bordercolor, int BorderSizePixel)
        {


            bool hover = RectContainsCursor(rect);
            bool pressed = hover && Input.GetKeyDown(KeyCode.Mouse0);

            if (hover)
            {
                DrawRect(rect, Color.gray);
            }
            else if(!hover &&!pressed)
            {
                DrawRect(rect, bordercolor);
            }

            if (pressed)
            {
                DrawRect(new Rect(rect.x + BorderSizePixel, rect.y + BorderSizePixel, rect.width - BorderSizePixel * 2, rect.height - BorderSizePixel * 2), Color.gray);
            }
            else
            {
                DrawRect(new Rect(rect.x + BorderSizePixel, rect.y + BorderSizePixel, rect.width - BorderSizePixel * 2, rect.height - BorderSizePixel * 2), color);
            }

            DrawText(text, new Rect(rect.x + BorderSizePixel, rect.y + BorderSizePixel, rect.width - BorderSizePixel * 2, rect.height - BorderSizePixel * 2), 35, bordercolor);



            return pressed;

        }

       
        public static bool RectContainsCursor(Rect rect)
        {
            bool does = false;
            GUI.Label(new Rect(0, 0, 200, 20), Input.mousePosition.y.ToString());

            if(Input.mousePosition.x < rect.x + rect.width && Input.mousePosition.x > rect.x && 
                Input.mousePosition.y < Screen.height - rect.y && Input.mousePosition.y > Screen.height - rect.y - rect.height)
            {
                does = true;
            }
            else
            {
                does = false;
            }
            return does;
        }

        public static void DrawRect(Rect rect, Color color)
        {
            Texture2D tex = new Texture2D(1, 1);

            tex.SetPixel(1, 1, color);

            tex.wrapMode = TextureWrapMode.Repeat;
            tex.Apply();

            GUI.DrawTexture(rect, tex);
        }

        public static void DrawText(string text, Rect pos, int fontSize, Color textColor)
        {
            GUIStyle style = GetTextStyle(fontSize, textColor);

            GUI.Label(pos, text, style);
        }

        public static GUIStyle GetTextStyle(int fontSize, Color textColor)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                font = Resources.GetBuiltinResource<Font>("Arial.ttf"),
                fontSize = fontSize,
                alignment = TextAnchor.MiddleLeft,
            };

            style.normal.textColor = textColor;

            return style;
        }


    }
}
