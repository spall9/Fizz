using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using Settings = Fizz.Fmeniu;
using Spells = Fizz.FSpells;

namespace Fizz.Modes
{
    class jungleclear
    {
        public static void JungleClear()
        {
            var mob = EntityManager.MinionsAndMonsters.Monsters.FirstOrDefault(m => m.IsValidTarget(Spells.Q.Range));

            if (mob == null) return;
            if (Settings.jungle_q && Spells.Q.IsReady() && mob.IsValidTarget(Spells.Q.Range)
                && Player.Instance.ManaPercent >= Settings.jungle_q_mana)
            {
                Spells.Q.Cast(mob);
            }

            if (Settings.jungle_w && Spells.W.IsReady() && mob.IsValidTarget(Spells.W.Range)
                && Player.Instance.ManaPercent >= Settings.jungle_w_mana)
            {
                if (mob.Health <= Spells.W.GetSpellDamage(mob) && Settings.jungle_w_only) Spells.W.Cast(mob);
                else if (!Settings.lane_w_only) Spells.W.Cast();
            }

            if (Settings.jungle_e && Spells.E.IsReady() && mob.IsValidTarget(Spells.E.Range)
                && Player.Instance.ManaPercent >= Settings.jungle_e_mana)
            {
                if (Spells.E.IsInRange(mob) && Spells.E.Name == "FizzE")
                {
                    var castPos = Player.Instance.Distance(Prediction.Position.PredictUnitPosition(mob, 1))
                                  > Spells.E.Range
                                      ? Player.Instance.Position.Extend(
                                          Prediction.Position.PredictUnitPosition(mob, 1),
                                          Spells.E.Range).To3DWorld()
                                      : mob.Position;

                    //var castPos = E.GetPrediction(target).CastPosition;
                    Spells.E.Cast(castPos);

                    var pred2 = Prediction.Position.PredictUnitPosition(mob, 1).Distance(Player.Instance.Position)
                                <= (200 + 330 + mob.BoundingRadius);

                    if (pred2)
                    {
                        Player.IssueOrder(
                            GameObjectOrder.MoveTo,
                            Prediction.Position.PredictUnitPosition(mob, 1).To3DWorld());
                        Orbwalker.DisableMovement = false;
                    }
                    else Spells.E.Cast(Prediction.Position.PredictUnitPosition(mob, 1).To3DWorld());
                    //E.Cast(minion);
                }
            }
        }
    }
}
