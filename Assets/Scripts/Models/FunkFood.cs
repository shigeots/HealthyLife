using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    [Serializable]
    public class FunkFood : Food {

        [SerializeField] private int _cost;

        public FunkFood() {
        }

        public FunkFood(string name, int weight, int energy, int happiness, int cost) : base(name, weight, energy, happiness) {
            Cost = cost;
        }

        public int Cost { get => _cost; set => _cost = value; }
    }
}
