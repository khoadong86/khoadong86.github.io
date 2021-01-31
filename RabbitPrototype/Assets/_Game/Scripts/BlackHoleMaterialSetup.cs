using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using DG.Tweening;

public class BlackHoleMaterialSetup : MonoBehaviour
{
    protected GameObject _model;
    protected Material _mat;

    // Start is called before the first frame update
    void Start()
    {
        _model = this.gameObject.GetComponentInParent<Character>()?.CharacterModel;
        _mat = _model.GetComponent<Renderer>()?.sharedMaterial;
        _mat.SetVector("_BlackHolePos", Vector3.zero);
        //_mat.DOFloat(5.0f, "Range", 0.5f);
        _mat.SetFloat("_Range", 10f);
        _mat.DOFloat(5.0f, "_Effect", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
