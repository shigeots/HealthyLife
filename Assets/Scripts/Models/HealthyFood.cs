using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    [Serializable]
    public class HealthyFood : Food {
        
        [SerializeField] private int _preparationTime;
        [SerializeField] private List<Ingredient> _ingredients;

        public HealthyFood() {
        }

        public HealthyFood(string name, int weight, int energy, int happiness, int preparationTime, List<Ingredient> ingredients) : base(name, weight, energy, happiness) {
            PreparationTime = preparationTime;
            Ingredients = ingredients;
        }

        public int PreparationTime { get => _preparationTime; set => _preparationTime = value; }
        public List<Ingredient> Ingredients { get => _ingredients; set => _ingredients = value; }
        
    }
}
