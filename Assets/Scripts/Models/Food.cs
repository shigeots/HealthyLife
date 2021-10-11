using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    [Serializable]
    public class Food {

        [SerializeField] private string _name;
        [SerializeField] private int _weight;
        [SerializeField] private int _energy;
        [SerializeField] private int _happiness;

        public Food() {
        }

        public Food(string name, int weight, int energy, int happiness) {
            Name = name;
            Weight = weight;
            Energy = energy;
            Happiness = happiness;
        }

        public string Name { get => _name; set => _name = value; }
        public int Weight { get => _weight; set => _weight = value; }
        public int Energy { get => _energy; set => _energy = value; }
        public int Happiness { get => _happiness; set => _happiness = value; }
    }
}
