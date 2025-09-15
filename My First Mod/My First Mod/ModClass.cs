using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using HutongGames.PlayMaker.Actions;
using Modding;
using UnityEngine;

namespace MyFirstMod
{
    public class MyFirstMod : Mod
    {
        bool canAttack = false;
        float timer = 0.0f;

        public MyFirstMod() : base("My First Mod") { }
        public override string GetVersion() => "v1";
        public override void Initialize()
        {
            ModHooks.HeroUpdateHook += OnHeroUpdate;
        }

        public void OnHeroUpdate()
        {
            timer += Time.deltaTime;

            if (timer >= HeroController.instance.ATTACK_COOLDOWN_TIME)
            {
                canAttack = true;
                timer = 0.0f;
            }

            if (InputHandler.Instance.inputActions.rs_up && canAttack)
            {
                HeroController.instance.Attack(GlobalEnums.AttackDirection.upward);
                canAttack = false;
            }

            if (InputHandler.Instance.inputActions.rs_down && canAttack)
            {
                HeroController.instance.Attack(GlobalEnums.AttackDirection.downward);
                canAttack = false;
            }

            if (InputHandler.Instance.inputActions.rs_right && canAttack)
            {
                HeroController.instance.FaceRight();
                HeroController.instance.Attack(GlobalEnums.AttackDirection.normal);
                canAttack = false;
            }

            if (InputHandler.Instance.inputActions.rs_left && canAttack)
            {
                HeroController.instance.FaceLeft();
                HeroController.instance.Attack(GlobalEnums.AttackDirection.normal);
                canAttack = false;
            }          

        }
    }
}