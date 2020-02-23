using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    public static class TagManager 
    {
        [Header("GAMEPLAY TAGS")]
        public static string Player = "Player";
        public static string Platform = "platform";
        public static string Spike = "spike";

        [Header("SCENE TAGS")]
        public static string Level_1 = "Gameplay";
        public static string MainMenu = "MainMenu";


        [Header("ANIMATION TAGS")]
        public static string Store_Anim = "Store_Anim";
        public static string Close_Anim = "Close_Anim";
        public static string Intro_Anim = "Intro_Anim";
    }

}