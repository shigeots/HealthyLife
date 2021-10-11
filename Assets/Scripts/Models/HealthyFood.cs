using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    [Serializable]
    public class HealthyFood : Food {
        
        [SerializeField] private List<Ingredient> _ingredients;

        public HealthyFood() {
        }

        public HealthyFood(string name, int weight, int energy, int happiness, List<Ingredient> ingredients) : base(name, weight, energy, happiness) {
            Ingredients = ingredients;
        }

        public List<Ingredient> Ingredients { get => _ingredients; set => _ingredients = value; }
    }
}
