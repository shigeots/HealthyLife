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
        [SerializeField] private AudioSource _playerAudioSource;

        [SerializeField] private AudioClip _walkAudioClip;
        [SerializeField] private AudioClip _chopAudioClip;
        [SerializeField] private AudioClip _wakeUpAudioClip;
        [SerializeField] private AudioClip _eatAudioClip;
        [SerializeField] private AudioClip _fridgeDoorOpenAudioClip;
        [SerializeField] private AudioClip _tvSwitchOnAudioClip;
        [SerializeField] private AudioClip _doorAudioClip;

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
                StopSound();
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
            PlayInnerDoorSound();
        }

        private void CallShowFridgeHUDEvent() {
            EventObserver.ShowFridgeHUDEvent();
            PlayFridgeSound();
        }

        private void CallShowCookHUDEvent() {
            EventObserver.ShowCookHUDEvent();
        }

        private void CallShowShoppingHUDEvent() {
            EventObserver.ShowShoppingHUDEvent();
        }

        private void StopSound() {
            _playerAudioSource.Stop();
        }

        private void PlayWalkSound() {
            _playerAudioSource.Stop();
            _playerAudioSource.loop = true;
            _playerAudioSource.clip = _walkAudioClip;
            _playerAudioSource.Play();
        }

        private void PlayFridgeSound() {
            _playerAudioSource.Stop();
            _playerAudioSource.loop = false;
            _playerAudioSource.clip = _fridgeDoorOpenAudioClip;
            _playerAudioSource.Play();
        }

        #endregion

        #region Internal methods

        internal void GoToTheInnerDoor() {
            _moveToCharacter = true;
            _destinationPointTransform = _innerDoorPoint.GetDestinationPoint();
            _thePointOfLookTransform = _innerDoorPoint.GetLookPoint();
            PlayWalkSound();
        }

        internal void GoToTheFridge() {
            _moveToCharacter = true;
            _destinationPointTransform = _fridgePoint.GetDestinationPoint();
            _thePointOfLookTransform = _fridgePoint.GetLookPoint();
            PlayWalkSound();
        }

        internal void GoToTheKitchen() {
            _moveToCharacter = true;
            _destinationPointTransform = _kitchenPoint.GetDestinationPoint();
            _thePointOfLookTransform = _kitchenPoint.GetLookPoint();
            PlayWalkSound();
        }

        internal void GoToTheTable() {
            _moveToCharacter = true;
            _destinationPointTransform = _tablePoint.GetDestinationPoint();
            _thePointOfLookTransform = _tablePoint.GetLookPoint();
            PlayWalkSound();
        }

        internal void GoToTheBed() {
            _moveToCharacter = true;
            _destinationPointTransform = _bedPoint.GetDestinationPoint();
            _thePointOfLookTransform = _bedPoint.GetLookPoint();
            PlayWalkSound();
        }

        internal void GoToTheTelevision() {
            _moveToCharacter = true;
            _destinationPointTransform = _televisionPoint.GetDestinationPoint();
            _thePointOfLookTransform = _televisionPoint.GetLookPoint();
            PlayWalkSound();
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

        internal void AssignShowFridgeHUDEvent() {
            _showHUDFunction = CallShowFridgeHUDEvent;
        }

        internal void AssignShowCookHUDEvent() {
            _showHUDFunction = CallShowCookHUDEvent;
        }

        internal void AssignShowShoppingHUDEvent() {
            _showHUDFunction = CallShowShoppingHUDEvent;
        }

        internal void PlayCookSound() {
            _playerAudioSource.Stop();
            _playerAudioSource.loop = false;
            _playerAudioSource.clip = _chopAudioClip;
            _playerAudioSource.Play();
        }

        internal void PlayEatSound() {
            _playerAudioSource.Stop();
            _playerAudioSource.loop = false;
            _playerAudioSource.clip = _eatAudioClip;
            _playerAudioSource.Play();
        }

        internal void PlayWakeUpSound() {
            _playerAudioSource.Stop();
            _playerAudioSource.loop = false;
            _playerAudioSource.clip = _wakeUpAudioClip;
            _playerAudioSource.Play();
        }

        internal void PlayTVOnSound() {
            _playerAudioSource.Stop();
            _playerAudioSource.loop = false;
            _playerAudioSource.clip = _tvSwitchOnAudioClip;
            _playerAudioSource.Play();
        }

        internal void PlayInnerDoorSound() {
            _playerAudioSource.Stop();
            _playerAudioSource.loop = false;
            _playerAudioSource.clip = _doorAudioClip;
            _playerAudioSource.Play();
        }

        #endregion

        #region Public methods

        public static void CallShowHUDEvent(ShowHUDFunction showHUDFunction){
            showHUDFunction();
        }

        #endregion

    }
}