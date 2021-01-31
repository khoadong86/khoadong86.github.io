using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using DG.Tweening;

namespace MoreMountains.Feedbacks
{
    /// <summary>
    /// When played, this feedback will activate the Wiggle method of a MMWiggle object based on the selected settings, wiggling either its position, rotation, scale, or all of these.
    /// </summary>
    [AddComponentMenu("")]
    [FeedbackPath("Transform/Custom")]
    public class FeedbackCustom : MMFeedback
    {
        /// sets the inspector color for this feedback
#if UNITY_EDITOR
        public override Color FeedbackColor { get { return MMFeedbacksInspectorColors.TransformColor; } }
#endif

        public GameObject TargetWiggle;

        protected GameObject _model;
        protected Material _mat;


        public override void Initialization(GameObject owner)
        {
            base.Initialization(owner);
            _model = TargetWiggle;//.GetComponentInParent<Character>()?.CharacterModel;
            _mat = _model.GetComponent<Renderer>()?.sharedMaterial;
            Debug.Log("log" + _mat);
        }
        /// <summary>
        /// On Play we trigger the desired wiggles
        /// </summary>
        /// <param name="position"></param>
        /// <param name="attenuation"></param>
        protected override void CustomPlayFeedback(Vector3 position, float attenuation = 1.0f)
        {
            if (Active && (TargetWiggle != null))
            {
                Debug.Log("Feedback custom");
                //_mat.SetVector("_BlackHolePos", Vector3.zero);
                //_mat.DOFloat(5.0f, "Range", 0.5f);
                //_mat.SetFloat("_Range", 10f);
                //_model.transform.DOShakeRotation(1f);
                //_model.transform.DOShakePosition(1f);
                _model.transform.DOShakeScale(0.5f, 0.5f);
                //_mat.DOFloat(0.82f, "_Effect", 0.5f).SetEase(Ease.OutBounce);
            }
        }
    }
}