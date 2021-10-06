using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCharacterController : MonoBehaviour {

    #region Private properties

    [SerializeField] private Transform _destinationPointTransform;
    [SerializeField] private Transform _thePointOfLookTransform;
    [SerializeField] private NavMeshAgent _playerNavMeshAgent;
    [SerializeField] private Rigidbody2D _playerRigidbody2D;

    [SerializeField] private bool _reachedTheDestination = false;
    [SerializeField] private float _destinationReachedThreshold;

    #endregion

    #region Main methods

    private void Start() {
        _playerNavMeshAgent.updateRotation = false;
        _playerNavMeshAgent.updateUpAxis = false;
    }

    private void Update() {
        GoToTheDestinationPoint(_destinationPointTransform);
        LookAtTheDestination(_destinationPointTransform);
        CheckDestinationReached();
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
        } else {
            _reachedTheDestination = false;
        }
    }

    #endregion
}
