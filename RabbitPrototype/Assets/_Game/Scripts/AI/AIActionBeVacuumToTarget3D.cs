using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using DG.Tweening;

namespace MoreMountains.TopDownEngine
{
    /// <summary>
    /// Requires a CharacterMovement ability. Makes the character move up to the specified MinimumDistance in the direction of the target. 
    /// </summary>
    [AddComponentMenu("TopDown Engine/Character/AI/Actions/AIActionBeVacuumToTarget3D")]
    //[RequireComponent(typeof(CharacterMovement))]
    public class AIActionBeVacuumToTarget3D : AIAction
    {
        /// the minimum distance from the target this Character can reach.
        [Tooltip("the minimum distance from the target this Character can reach.")]
        public float MinimumDistance = 1f;

        protected Vector3 _directionToTarget;
        protected int _numberOfJumps = 0;
        protected Vector2 _movementVector;
        protected GameObject _model;
        protected Material _mat;
        //protected Vector3.

        /// <summary>
        /// On init we grab our CharacterMovement ability
        /// </summary>
        protected override void Initialization()
        {
            _model = this.gameObject.GetComponentInParent<Character>()?.CharacterModel;
            _mat = _model.GetComponent<Renderer>()?.sharedMaterial;
        }

        /// <summary>
        /// On PerformAction we move
        /// </summary>
        public override void PerformAction()
        {
            Move();
        }

        public override void OnEnterState()
        {
            Debug.Log("Be Vacuum");
            base.OnEnterState();
            if (_brain.Target == null)
            {
                return;
            }
            _mat.SetVector("_BlackHolePos", _brain.Target.position);
            //_mat.DOFloat(5.0f, "Range", 0.5f);
            _mat.SetFloat("_Range", 10f);
            _mat.SetFloat("_Effect", 0.5f);
            _mat.DOFloat(0.9f, "_Effect", 2f);//.SetEase(Ease.OutElastic);
            //transform.DOMove(_brain.Target.position, 0.5f);
            //transform.DOScale(0.1f, 0.5f);
        }

        /// <summary>
        /// Moves the character towards the target if needed
        /// </summary>
        protected virtual void Move()
        {
            if (_brain.Target == null)
            {
                return;
            }

            /*
            _directionToTarget = _brain.Target.position - this.transform.position;
            _movementVector.x = _directionToTarget.x;
            _movementVector.y = _directionToTarget.z;


            if (Mathf.Abs(this.transform.position.x - _brain.Target.position.x) < MinimumDistance)
            {
            }

            if (Mathf.Abs(this.transform.position.z - _brain.Target.position.z) < MinimumDistance)
            {
            }
            */
        }

        /// <summary>
        /// On exit state we stop our movement
        /// </summary>
        public override void OnExitState()
        {
            base.OnExitState();
        }
    }
}
