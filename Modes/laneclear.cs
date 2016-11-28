using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings = Fizz.Fmeniu;
using Spells = Fizz.FSpells;
using EloBuddy.SDK;

namespace Fizz.Modes
{
    using EloBuddy;

    class laneclear
    {
        public static void LaneClear()
        {

            if (Settings.lane_w && Spells.W.IsReady() && Player.Instance.ManaPercent > Settings.lane_w_mana)
            {
                var minion =
                    EntityManager.MinionsAndMonsters.EnemyMinions.FirstOrDefault(m => m.IsValidTarget(Spells.W.Range));
                if (minion == null) return;
                if (minion.Health <= Spells.W.GetSpellDamage(minion) && Settings.lane_w_only) Spells.W.Cast(minion);
                else if (!Settings.lane_w_only) Spells.W.Cast();

            }
            if (Settings.lane_q && Spells.Q.IsReady() && Player.Instance.ManaPercent >= Settings.lane_q_mana)
            {
                var minion =
                    EntityManager.MinionsAndMonsters.EnemyMinions.FirstOrDefault(m => m.IsValidTarget(Spells.Q.Range));
                if (minion == null) return;

                if (Spells.Q.IsInRange(minion) && minion.Health <= Player.Instance.GetSpellDamage(minion, Spells.Q.Slot)) Spells.Q.Cast(minion);

            }
            if (Settings.lane_e && Spells.E.IsReady() && Player.Instance.ManaPercent >= Settings.Lane_e_mana)
            {
                var minions =
                    EntityManager.MinionsAndMonsters.GetLaneMinions()
                        .Where(m => m.IsValidTarget(Spells.E.Range))
                        .ToArray();
                if (minions.Length == 0) return;

                if (Spells.E.Name == "FizzE")
                {
                    var castPos =
                        Prediction.Position.PredictCircularMissileAoe(
                                minions,
                                Spells.E.Range,
                                Spells.E.Width,
                                Spells.E.CastDelay,
                                Spells.E.Speed)
                            .OrderByDescending(r => r.GetCollisionObjects<Obj_AI_Minion>().Length)
                            .FirstOrDefault();

                    if (castPos != null)
                    {
                        var predictMinion = castPos.GetCollisionObjects<Obj_AI_Minion>();

                        if (predictMinion.Length >= Settings.UseEMinion)
                        {
                            //var castPos = E.GetPrediction(target).CastPosition;
                            Spells.E.Cast(castPos.CastPosition);

                            Player.IssueOrder(GameObjectOrder.MoveTo, castPos.CastPosition);
                        }
                    }
                }
            }
        }
    }
}
