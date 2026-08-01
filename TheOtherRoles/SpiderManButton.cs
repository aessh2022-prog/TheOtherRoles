using System;
using UnityEngine;

namespace TheOtherRoles {
    public static class SpiderManButton {
        public static bool isSpiderMan = false;
        
        // إعدادات زر وقدرة سبايدرمان
        public static void SetRole(byte playerId) {
            isSpiderMan = true;
        }

        public static void ClearRole() {
            isSpiderMan = false;
        }
    }
}
