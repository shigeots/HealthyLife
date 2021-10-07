using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthyLife {

    public class DestinationPoint : MonoBehaviour {

        #region Private properties

        [SerializeField] private Transform _destinationPointTransform;
        [SerializeField] private Transform _lookPointTransform;

        #endregion

        #region Internal methods

        internal Transform GetDestinationPoint() {
            return _destinationPointTransform;
        }

        internal Transform GetLookPoint() {
            return _lookPointTransform;
        }
        
        #endregion

    }
}
