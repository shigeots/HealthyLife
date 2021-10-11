using System;
using System.Collections;
using System.Collections.Generic;

namespace HealthyLife {

    public static class EventObserver {

        public static Action<int, int> WorkStartEvent;

        public static Action ShowWorkHUDEvent;

        public static Action ShowSleepHUDEvent;

        public static Action ShowEatHUDEvent;

        public static Action ShowExerciseHUDEvent;

        public static Action ShowPartingHUDEvent;

    }
}
