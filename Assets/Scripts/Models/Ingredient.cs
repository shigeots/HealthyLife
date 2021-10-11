using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    [Serializable]
    public class Ingredient {

        [SerializeField] private string _name;
        [SerializeField] private int _cost;

        public Ingredient() {
        }

        public Ingredient(string name, int cost) {
            Name = name;
            Cost = cost;
        }

        public string Name { get => _name; set => _name = value; }
        public int Cost { get => _cost; set => _cost = value; }
    }
}
