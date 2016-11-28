using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings = Fizz.Fmeniu;
using Spells = Fizz.FSpells;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace Fizz.Modes
{
    class harras
    {
        public static void Harras()
        {
            var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
            if (target == null || !target.IsValidTarget()) return;
            var EnoughManaEWQ = false;
            var EnoughManaEQ = false;
            var startPos = Vector3.Zero;
            var UseEWQ = Settings.harras_q && Settings.harras_w && Settings.harras_e;
            var TotalManaEWQ = Player.GetSpell(Spells.Q.Slot).SData.Mana + Player.GetSpell(Spells.W.Slot).SData.Mana + Player.GetSpell(Spells.E.Slot).SData.Mana;
            var TotalManaEQ = Player.GetSpell(Spells.Q.Slot).SData.Mana + Player.GetSpell(Spells.E.Slot).SData.Mana;
                    var etarget = Spells.E.GetTarget();
                    if (etarget == null) return;
                        if (UseEWQ && Spells.Q.IsReady())
                    {
                        if (Player.Instance.Mana >= TotalManaEWQ || EnoughManaEWQ)
                        {
                            if (Spells.E.IsReady() && Spells.E.Name == "FizzE" && Player.Instance.Distance(target.Position) <= 530)
                            {
                                EnoughManaEWQ = true;
                                startPos = Player.Instance.Position;
                                Vector3 harassEcastPos = Spells.E.GetPrediction(etarget).CastPosition;
                                Spells.E.Cast(harassEcastPos);

                                Core.DelayAction(() =>
                                {
                                    Spells.E.Cast(Spells.E.GetPrediction(etarget).CastPosition.Extend(startPos, -135).To3DWorld());
                                }, (365 - Game.Ping));
                            }

                            if (Spells.W.IsReady() && Player.Instance.Distance(target.Position) <= 175)
                            {
                                Spells.W.Cast();
                                EnoughManaEWQ = false;
                            }

                            if (Spells.Q.IsReady())
                                Spells.Q.Cast(target);
                        }

                        if (Player.Instance.Mana >= TotalManaEQ || EnoughManaEQ)
                        {
                            if (Spells.E.IsReady() && Spells.E.Name == "FizzE" && Player.Instance.Distance(etarget.Position) <= 530)
                            {
                                EnoughManaEQ = true;
                                startPos = Player.Instance.Position;
                                Vector3 harassECastPos = Spells.E.GetPrediction(etarget).CastPosition;

                                Spells.E.Cast(harassECastPos);
                                Core.DelayAction(() =>
                                {
                                    Spells.E.Cast(Spells.E.GetPrediction(etarget).CastPosition.Extend(startPos, -135).To3DWorld());
                                    EnoughManaEQ = false;
                                }, (365 - Game.Ping));
                            }

                            if (Spells.Q.IsReady())
                                Spells.Q.Cast(target);
                        }
                    }

                    else
                    {
                        if (Settings.harras_w && Spells.W.IsReady() && Player.Instance.Distance(target.Position) <= Spells.Q.Range) Spells.W.Cast();
                        if (Settings.harras_q && Spells.Q.IsReady() && Player.Instance.Distance(target.Position) <= Spells.Q.Range)
                            Spells.Q.Cast(target);
                    }
            }
        }
    }
