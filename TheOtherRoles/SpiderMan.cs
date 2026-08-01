using System;
using System.Collections.Generic;
using UnityEngine;
using TheOtherRoles.Objects;

namespace TheOtherRoles.Roles {
    public class SpiderMan {
        // تعريف القدرات الستة
        public static bool isIronSpider = false;
        public static bool hasScissors = false; // القاتل يملكه، المواطن بعد 3 مهام

        // 1. قدرة السحب بالشبكة (Web Pull)
        public static void PullPlayer(PlayerControl target) {
            if (target == null) return;
            target.transform.position = PlayerControl.LocalPlayer.transform.position;
        }

        // 2. قدرة القتل بالشبكة (Web Kill)
        public static void WebKill(PlayerControl target) {
            if (target == null || target.Data.IsDead) return;
            PlayerControl.LocalPlayer.MurderPlayer(target);
        }

        // 3. احتجاز الشبكة والمقص (Web Freeze & Scissors Logic)
        public static void TrapWithWeb(PlayerControl target) {
            if (target == null) return;
            // تجميد الحركة
            target.moveable = false; 
        }

        public static void FreeFromWeb(PlayerControl target, PlayerControl rescuer) {
            // فك التجميد بمقص المواطن (بعد 3 مهام) أو القاتل
            if (rescuer.Data.IsImpostor || hasScissors) {
                target.moveable = true;
            }
        }

        // 4. الانتقال السريع بالشبكة (Web Teleport)
        public static void TeleportToLocation(Vector3 position) {
            PlayerControl.LocalPlayer.transform.position = position;
        }

        // 5. التحول إلى Iron Spider
        public static void TransformToIronSpider() {
            isIronSpider = true;
            // تغيير السرعة والشكل عند التحول
            PlayerControl.LocalPlayer.MyPhysics.Speed *= 1.2f;
        }

        // 6. قدرة الأرجل الحديدية (Iron Legs - تظهر فقط بعد التحول)
        public static void UseIronLegs() {
            if (!isIronSpider) return; // شرط تفعيل Iron Spider أولاً
            
            // زيادة فائقة للسرعة وقفز المسافات
            PlayerControl.LocalPlayer.MyPhysics.Speed *= 1.5f;
        }
    }
}
