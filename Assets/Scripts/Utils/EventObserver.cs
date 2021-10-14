using System;
using System.Collections;
using System.Collections.Generic;

namespace HealthyLife {

    public static class EventObserver {

        public static Action<int, int, int, int> WorkStartEvent;

        public static Action SleepStartEvent;

        public static Action ShowWorkHUDEvent;

        public static Action ShowSleepHUDEvent;

        public static Action ShowEatHUDEvent;

        public static Action ShowExerciseHUDEvent;

        public static Action ShowPartingHUDEvent;

        public static Action ShowWatchTVHUDEvent;

        public static Action ShowDeliveryFoodHUDEvent;

        public static Action ShowPickUpDeliveryHUDEvent;

        public static Action ShowFridgeHUDEvent;

        public static Action ShowCookHUDEvent;

        public static Action ShowShoppingHUDEvent;

        public static Action ShowMainMenuScreenEvent;

        public static Action ShowHowToPlayScreenEvent;

        public static Action ShowOptionsScreenEvent;

        public static Action ShowCreditsScreenEvent;
    }
}
