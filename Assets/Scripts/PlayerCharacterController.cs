using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HealthyLife {

    public class PlayerCharacterController : MonoBehaviour {

        #region Private properties

        [SerializeField] private Transform _destinationPointTransform;
        [SerializeField] private Transform _thePointOfLookTransform;

        [SerializeField] private NavMeshAgent _playerNavMeshAgent;
        [SerializeField] private Rigidbody2D _playerRigidbody2D;

        [SerializeField] private DestinationPoint _fridgePoint;
        [SerializeField] private DestinationPoint _tablePoint;
        [SerializeField] private DestinationPoint _bedPoint;
        [SerializeField] private DestinationPoint _televisionPoint;
        [SerializeField] private DestinationPoint _kitchenPoint;
        [SerializeField] private DestinationPoint _innerDoorPoint;

        [SerializeField] private bool _moveToCharacter = false;
        [SerializeField] private bool _reachedTheDestination = false;
        [SerializeField] private float _destinationReachedThreshold;

        private ShowHUDFunction _showHUDFunction;

        #endregion

        #region Public properties

        public delegate void ShowHUDFunction();

        #endregion

        #region Main methods

        private void Start() {
            _playerNavMeshAgent.updateRotation = false;
            _playerNavMeshAgent.updateUpAxis = false;
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
            _playerNavMeshAgent.SetDestination(destination.position);
        }
        
        private void LookAtTheDestination(Transform destination) {
            if(!_reachedTheDestination) {
                Vector2 lookDirection = (destination.position - transform.position);
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
                _playerRigidbody2D.rotation = angle;
            }
            
        }

        private void CheckDestinationReached() {
            float distanceToDestination = Vector3.Distance(transform.position, _destinationPointTransform.position);
            
            if(distanceToDestination < _destinationReachedThreshold) {
                LookAtTheDestination(_thePointOfLookTransform);
                _reachedTheDestination = true;
                _moveToCharacter = false;

                CallShowHUDEvent(_showHUDFunction);
            } else {
                _reachedTheDestination = false;
            }
        }

        private void CallShowWorkHUDEvent() {
            EventObserver.ShowWorkHUDEvent();
        }

        private void CallShowSleepHUDEvent() {
            EventObserver.ShowSleepHUDEvent();
        }

        private void CallShowEatHUDEvent() {
            EventObserver.ShowEatHUDEvent();
        }

        private void CallShowExerciseHUDEvent() {
            EventObserver.ShowExerciseHUDEvent();
        }

        private void CallShowPartingHUDEvent() {
            EventObserver.ShowPartingHUDEvent();
        }

        private void CallShowWatchTVHUDEvent() {
            EventObserver.ShowWatchTVHUDEvent();
        }

        private void CallShowFoodDeliveryHUDEvent() {
            EventObserver.ShowDeliveryFoodHUDEvent();
        }

        private void CallShowPickUpDeliveryHUDEvent() {
            EventObserver.ShowPickUpDeliveryHUDEvent();
        }

        #endregion

        #region Internal methods

        internal void GoToTheInnerDoor() {
            _moveToCharacter = true;
            _destinationPointTransform = _innerDoorPoint.GetDestinationPoint();
            _thePointOfLookTransform = _innerDoorPoint.GetLookPoint();
        }

        internal void GoToTheFridge() {
            _moveToCharacter = true;
            _destinationPointTransform = _fridgePoint.GetDestinationPoint();
            _thePointOfLookTransform = _fridgePoint.GetLookPoint();
        }

        internal void GoToTheKitchen() {
            _moveToCharacter = true;
            _destinationPointTransform = _kitchenPoint.GetDestinationPoint();
            _thePointOfLookTransform = _kitchenPoint.GetLookPoint();
        }

        internal void GoToTheTable() {
            _moveToCharacter = true;
            _destinationPointTransform = _tablePoint.GetDestinationPoint();
            _thePointOfLookTransform = _tablePoint.GetLookPoint();
        }

        internal void GoToTheBed() {
            _moveToCharacter = true;
            _destinationPointTransform = _bedPoint.GetDestinationPoint();
            _thePointOfLookTransform = _bedPoint.GetLookPoint();
        }

        internal void GoToTheTelevision() {
            _moveToCharacter = true;
            _destinationPointTransform = _televisionPoint.GetDestinationPoint();
            _thePointOfLookTransform = _televisionPoint.GetLookPoint();
        }

        internal void AssignShowWorkHUDEvent() {
            _showHUDFunction = CallShowWorkHUDEvent;
        }

        internal void AssignShowSleepHUDEvent() {
            _showHUDFunction = CallShowSleepHUDEvent;
        }

        internal void AssignShowEatHUDEvent() {
            _showHUDFunction = CallShowEatHUDEvent;
        }

        internal void AssignShowExerciseHUDEvent() {
            _showHUDFunction = CallShowExerciseHUDEvent;
        }

        internal void AssignShowPartingHUDEvent() {
            _showHUDFunction = CallShowPartingHUDEvent;
        }

        internal void AssignShowWatchTVHUDEvent() {
            _showHUDFunction = CallShowWatchTVHUDEvent;
        }

        internal void AssignShowFoodDeliveryHUDEvent() {
            _showHUDFunction = CallShowFoodDeliveryHUDEvent;
        }

        internal void AssignShowPickUpDeliveryHUDEvent() {
            _showHUDFunction = CallShowPickUpDeliveryHUDEvent;
        }

        #endregion

        #region Public methods

        public static void CallShowHUDEvent(ShowHUDFunction showHUDFunction){
            showHUDFunction();
        }

        #endregion

    }
}