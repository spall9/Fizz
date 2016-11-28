using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using Fizz.Modes;
using SharpDX;
using EloBuddy.SDK.Rendering;
using DrawSettings = Fizz.Fmeniu;
using EloBuddy.SDK.Menu.Values;
namespace Fizz
{
    class Program
    {
        public static Vector3 LastHarassPos { get; set; }
        public static bool JumpBack { get; set; }

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Fizz")
            {
                return;
            }
            {
             Chat.Print("Fizz By modziux successfully loaded");
             Fmeniu.Loadmenu();
             FSpells.FSpellsloud();
             modesmanager.ModeManager();
             Obj_AI_Base.OnBuffGain += Obj_AI_BaseOnBuffgain;
             Obj_AI_Base.OnBuffLose += Obj_AI_BaseOnBufflose;
             Obj_AI_Base.OnBasicAttack += OnBasicAttack;
             Drawing.OnDraw += OnDraw;
             
            }
          
        }

        public static Dictionary<AIHeroClient, int> MyDic = new Dictionary<AIHeroClient, int>();

        static void Obj_AI_BaseOnBuffgain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if (hero == null || !args.Buff.Name.Equals("fizzwdot")) return;
            if (!MyDic.ContainsKey(hero))
            {
                MyDic.Add(hero, 0);
            }
        }

        static void Obj_AI_BaseOnBufflose(Obj_AI_Base sender, Obj_AI_BaseBuffLoseEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if (hero == null || !args.Buff.Name.Equals("fizzwdot")) return;
            if (MyDic.ContainsKey(hero))
            {
                MyDic.Remove(hero);
            }

        }
        static void OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender is Obj_AI_Turret && args.Target.IsMe && FSpells.E.IsReady() && Fmeniu.autoe)
            {
                 if (Fmeniu.autoe)
                {
                    FSpells.E.Cast(Player.Instance.Position.Extend(Game.CursorPos, FSpells.E.Range - 1).To3DWorld());
                    Core.DelayAction(() =>
                    {
                        FSpells.E.Cast(Player.Instance.Position.Extend(Game.CursorPos, FSpells.E.Range - 1).To3DWorld());
                    }, (365 - Game.Ping));
                }
            }
        }
          static void OnDraw(EventArgs args)
        {
            if (DrawSettings.DrawQ)
                Circle.Draw(FSpells.Q.IsReady() ? DrawSettings.CurrentColor : SharpDX.Color.Red,
                    FSpells.Q.Range, 3F, Player.Instance.Position);

            if (DrawSettings.DrawW)
                Circle.Draw(FSpells.W.IsReady() ? DrawSettings.CurrentColor : SharpDX.Color.Red,
                    FSpells.W.Range, 3F, Player.Instance.Position);

            if (DrawSettings.DrawE)
                Circle.Draw(FSpells.E.IsReady() ? DrawSettings.CurrentColor : SharpDX.Color.Red,
                    FSpells.E.Range, 3F, Player.Instance.Position);

            if (DrawSettings.DrawR)
                Circle.Draw(FSpells.R.IsReady() ? DrawSettings.CurrentColor : SharpDX.Color.Red,
                    FSpells.R.Range, 3F, Player.Instance.Position);
            
        }
        
    }
    }
