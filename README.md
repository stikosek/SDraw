# SDraw
A simple gui framework (that uses imgui) primarily made to be used in unity cheats
by stikosek#0761

# Usage
Add all the needed libraries and then esimply import the folder 
into your bepinex project, then you can just use the SDraw functions
instead of IMGUI.

# Needed libaries
UnityEngine
UnityEngine.CoreModule
UnityEngine.IMGUIModule
UnityEngine.InputLegacyModule
UnityEngine.TextRenderingModule

# SDraw functions

 A list of all SDraw functions with explenations.

 SDrawRect(Rect,Color,BorderColor,(int)BordersizePixel); - Draws a simple box(rect) on the screen with a border.
 
 
 SDrawButton(Rect,Text, Color,BorderColor, (int)BordersizePixel)  - Draws a simple button on the screen with a border.
 (this method returns true if the button is pressed so it can be used just like the IMGUI GUI.Button)
 
 
 # Other info
 This is really shitty i dont reccomend accualy using this lmao
 sdraw is developed as a bepinex plugin so the accualy code of sdraw is found in
 https://github.com/stikosek/SDraw/blob/master/SDraw/sdraw.cs
 
 
