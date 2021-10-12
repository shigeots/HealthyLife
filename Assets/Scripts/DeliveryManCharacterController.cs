using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HealthyLife {

    public class DeliveryManCharacterController : MonoBehaviour {

        #region Private properties

        [SerializeField] private Transform _destinationPointTransform;
        [SerializeField] private Transform _thePointOfLookTransform;

        [SerializeField] private NavMeshAgent _characterNavMeshAgent;
        [SerializeField] private Rigidbody2D _characterRigidbody2D;

        [SerializeField] private DestinationPoint _outerDoorPoint;
        [SerializeField] private DestinationPoint _outOfCameraPoint;

        [SerializeField] private bool _moveToCharacter = false;
        [SerializeField] private bool _reachedTheDestination = false;
        [SerializeField] private float _destinationReachedThreshold;

        [SerializeField] private bool _isDelivery = false;
        [SerializeField] private bool _deliveryArrived = false;

        #endregion

        #region Getter and Setter

        public bool DeliveryArrived { get => _deliveryArrived; set => _deliveryArrived = value; }

        #region Main methods

        private void Start() {
            _characterNavMeshAgent.updateRotation = false;
            _characterNavMeshAgent.updateUpAxis = false;
        }

        private void Update() {
            if(_moveToCharacter) {
                GoToTheDestinationPoint(_destinationPointTransform);
                LookAtTheDestination(_destinationPointTransform);
                CheckDestinationReached();
            }
        }

        #endregion

        #region Private methods

        private void GoToTheDestinationPoint(Transform destination) {
            _characterNavMeshAgent.SetDestination(destination.position);
        }

        private void LookAtTheDestination(Transform destination) {
            if(!_reachedTheDestination) {
                Vector2 lookDirection = (destination.position - transform.position);
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
                _characterRigidbody2D.rotation = angle;
            }
            
        }

        private void CheckDeliveryHasArrived() {
            if(_isDelivery) {
                DeliveryArrived = true;
            }
        }

        private void CheckDestinationReached() {
            float distanceToDestination = Vector3.Distance(transform.position, _destinationPointTransform.position);
            
            if(distanceToDestination < _destinationReachedThreshold) {
                LookAtTheDestination(_thePointOfLookTransform);
                CheckDeliveryHasArrived();
                _reachedTheDestination = true;
                _moveToCharacter = false;

                //CallShowHUDEvent(_showHUDFunction);
            } else {
                _reachedTheDestination = false;
            }
        }

        #endregion

        #region Internal methods

        internal void GoToTheOuterDoor() {
            _moveToCharacter = true;
            _isDelivery = true;
            DeliveryArrived = false;
            _destinationPointTransform = _outerDoorPoint.GetDestinationPoint();
            _thePointOfLookTransform = _outerDoorPoint.GetLookPoint();
        }

        internal void GoToTheOutOfCameraPoint() {
            _moveToCharacter = true;
            _isDelivery = false;
            _destinationPointTransform = _outOfCameraPoint.GetDestinationPoint();
            _thePointOfLookTransform = _outOfCameraPoint.GetLookPoint();
        }

        #endregion
    }
}
