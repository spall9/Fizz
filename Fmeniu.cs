using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
namespace Fizz
{
    using SharpDX;

    class Fmeniu
    {
        public static Menu Menu, MenuCombo, MenuHarass, MenuLane, MenuJungle, MenuMisc, MenuDraw;
        static Color[] colorlist = { Color.Green, Color.Aqua, Color.Black, Color.Blue, Color.Firebrick, Color.Gold, Color.Pink, Color.Violet, Color.White, Color.Lime, Color.LimeGreen, Color.Yellow, Color.Magenta };
        static Slider masterColorSlider = new Slider("Color Slider", 0, 0, colorlist.Length - 1);
        public static void Loadmenu()
        {
            Menu = MainMenu.AddMenu("Fizz", "by modestas");
            MenuCombo = Menu.AddSubMenu("Combo", "combomenu");
            MenuCombo.Add("Combo.Q.Use", new CheckBox("Use Q"));
            MenuCombo.Add("Combo.W.Use", new CheckBox("Use W"));
            MenuCombo.Add("Combo.Ww.Use", new CheckBox("Use W Only for triple damage"));
            MenuCombo.Add("Combo.E.Use", new CheckBox("Use E"));
            MenuCombo.Add("Combo.R.Use", new CheckBox("Use R"));
            MenuCombo.Add("comboRMode", new ComboBox("R Mode:", 0, new string[] { "Always", "Only if killable" }));
            MenuHarass = Menu.AddSubMenu("Harass", "harras_menu");
            MenuHarass.Add("Harass.Q.Use", new CheckBox("Use Q"));
            MenuHarass.Add("Harass.W.Use", new CheckBox("Use W"));
            MenuHarass.Add("Harass.E.Use", new CheckBox("Use E"));
            MenuLane = Menu.AddSubMenu("LaneClear", "Lane_clearmenu");
            MenuLane.Add("Lane.Q.Use", new CheckBox("Use Q"));
            MenuLane.Add("Lane.Q.Mana", new Slider("Min Mana Use Q", 60, 0, 100));
            MenuLane.Add("Lane.W.Use", new CheckBox("Use W"));
            MenuLane.Add("Lane.W.Use_only", new CheckBox("Use W only to lasthit"));
            MenuLane.Add("Lane.W.Mana", new Slider("Min Mana Use W", 60, 0, 100));
            MenuLane.Add("Lane.E.Use", new CheckBox("Use E"));
            MenuLane.Add("lcUseEMinion", new Slider("Use E at atleast {0} minions", 3, 1, 6));
            MenuLane.Add("Lane.E.Mana", new Slider("Min Mana Use E", 60, 0, 100));
            MenuJungle = Menu.AddSubMenu("JungleClear", "Jungle_clear");
            MenuJungle.Add("Jungle.Q.Use", new CheckBox("Use Q"));
            MenuJungle.Add("Jungle.Q.Mana", new Slider("Min Mana Use Q", 60, 0, 100));
            MenuJungle.Add("Jungle.W.Use", new CheckBox("Use W"));
            MenuJungle.Add("Jungle.W.Use_only", new CheckBox("Use W only to lasthit"));
            MenuJungle.Add("Jungle.W.Mana", new Slider("Min Mana Use W", 60, 0, 100));
            MenuJungle.Add("Jungle.E.Use", new CheckBox("Use E"));
            MenuJungle.Add("Jungle.E.Mana", new Slider("Min Mana Use E", 60, 0, 100));
            MenuMisc = Menu.AddSubMenu("Misc", "Misc_menu");
          //  MenuMisc.Add("Use.Ignite", new CheckBox("Use Ignite"));
            MenuMisc.Add("UseAutoEOnTurrets", new CheckBox("Use Auto E On Turrets"));
            MenuDraw = Menu.AddSubMenu("Draw", "Draw_menu");
            MenuDraw.Add("Indicator", new CheckBox("Show killable"));
            MenuDraw.Add("mastercolor", masterColorSlider);
            MenuDraw.Add("drawq", new CheckBox("Draw Q", false));
            MenuDraw.Add("draww", new CheckBox("Draw W", false));
            MenuDraw.Add("drawe", new CheckBox("Draw E", false));
            MenuDraw.Add("drawr", new CheckBox("Draw R", false));
            

        }

        public static bool combo_q
        {
            get { return MenuCombo["Combo.Q.Use"].Cast<CheckBox>().CurrentValue; }
        }
        public static bool combo_w
        {
            get { return MenuCombo["Combo.W.Use"].Cast<CheckBox>().CurrentValue; }
        }
        public static bool combo_ww
        {
            get { return MenuCombo["Combo.Ww.Use"].Cast<CheckBox>().CurrentValue; }
        }
        public static bool combo_e
        {
            get { return MenuCombo["Combo.E.Use"].Cast<CheckBox>().CurrentValue; }
        }
        public static bool combo_r
        {
            get { return MenuCombo["Combo.R.Use"].Cast<CheckBox>().CurrentValue; }
        }
        public static string RMode
        {
            get { return MenuCombo["comboRMode"].Cast<ComboBox>().SelectedText; }
        }
        public static bool harras_q
        {
            get { return MenuHarass["Harass.Q.Use"].Cast<CheckBox>().CurrentValue; }
        }

        public static int harras_q_mana
        {
            get { return MenuHarass["Harras.Q.Mana"].Cast<Slider>().CurrentValue; }
        }
        public static bool harras_w
        {
            get { return MenuHarass["Harass.W.Use"].Cast<CheckBox>().CurrentValue; }
        }

        public static int harras_w_mana
        {
            get { return MenuHarass["Harras.W.Mana"].Cast<Slider>().CurrentValue; }
        }
        public static bool harras_e
        {
            get { return MenuHarass["Harass.E.Use"].Cast<CheckBox>().CurrentValue; }
        }

        public static int harras_e_mana
        {
            get { return MenuHarass["Harras.E.Mana"].Cast<Slider>().CurrentValue; }
        }
        public static bool lane_q
        {
            get { return MenuLane["Lane.Q.Use"].Cast<CheckBox>().CurrentValue; }
        }

        public static int lane_q_mana
        {
            get { return MenuLane["Lane.Q.Mana"].Cast<Slider>().CurrentValue; }
        }
        public static bool lane_w
        {
            get { return MenuLane["Lane.W.Use"].Cast<CheckBox>().CurrentValue; }
        }
        public static bool lane_w_only
        {
            get { return MenuLane["Lane.W.Use_only"].Cast<CheckBox>().CurrentValue; }
        }

        public static int lane_w_mana
        {
            get { return MenuLane["Lane.W.Mana"].Cast<Slider>().CurrentValue; }
        }
        public static bool lane_e
        {
            get { return MenuLane["Lane.E.Use"].Cast<CheckBox>().CurrentValue; }
        }

        public static int Lane_e_mana
        {
            get { return MenuLane["Lane.E.Mana"].Cast<Slider>().CurrentValue; }
        }
        public static int UseEMinion
        {
            get { return MenuLane["lcUseEMinion"].Cast<Slider>().CurrentValue; }
        }
        public static bool jungle_q
        {
            get { return MenuJungle["Jungle.Q.Use"].Cast<CheckBox>().CurrentValue; }
        }

        public static int jungle_q_mana
        {
            get { return MenuJungle["Jungle.Q.Mana"].Cast<Slider>().CurrentValue; }
        }
        public static bool jungle_w
        {
            get { return MenuJungle["Jungle.W.Use"].Cast<CheckBox>().CurrentValue; }
        }
        public static bool jungle_w_only
        {
            get { return MenuJungle["Jungle.W.Use_only"].Cast<CheckBox>().CurrentValue; }
        }
        public static int jungle_w_mana
        {
            get { return MenuJungle["Jungle.W.Mana"].Cast<Slider>().CurrentValue; }
        }
        public static bool jungle_e
        {
            get { return MenuJungle["Jungle.E.Use"].Cast<CheckBox>().CurrentValue; }
        }

        public static int jungle_e_mana
        {
            get { return MenuJungle["Jungle.E.Mana"].Cast<Slider>().CurrentValue; }
        }

        public static bool ShowKillable
        {
            get { return MenuDraw["Indicator"].Cast<CheckBox>().CurrentValue; }
        }

        public static bool DrawQ
        {
            get { return MenuDraw["drawq"].Cast<CheckBox>().CurrentValue; }
        }
        public static bool DrawW
        {
            get { return MenuDraw["draww"].Cast<CheckBox>().CurrentValue; }
        }
        public static bool DrawE
        {
            get { return MenuDraw["drawe"].Cast<CheckBox>().CurrentValue; }
        }
        public static bool DrawR
        {
            get { return MenuDraw["drawr"].Cast<CheckBox>().CurrentValue; }
        }
        public static Color CurrentColor
        {
            get { return colorlist[MenuDraw["mastercolor"].Cast<Slider>().CurrentValue]; }
        }
        // public static bool useign
        //{
        //   get { return MenuMisc["Use.Ignite"].Cast<CheckBox>().CurrentValue; }
        //}

        public static bool autoe
        {
            get { return MenuMisc["UseAutoEOnTurrets"].Cast<CheckBox>().CurrentValue; }
        }

    }

}

