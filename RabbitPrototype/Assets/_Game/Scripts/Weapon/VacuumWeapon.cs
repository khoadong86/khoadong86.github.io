using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;

public class VacuumWeapon : Weapon
{
	[MMInspectorGroup("Vacuum", true, 22)]
	/// the offset position at which the projectile will spawn
	[Tooltip("the Vacuum Trigger")]
	public Transform VacuumArea;

	protected bool isTriggerred;
	public override void Initialization()
	{
		base.Initialization();
		VacuumArea.gameObject.SetActive(false);
		isTriggerred = false;
	}
	/// <summary>
	/// Called everytime the weapon is used
	/// </summary>
	public override void WeaponUse()
	{
		base.WeaponUse();
		if (!isTriggerred)
        {
			VacuumArea.gameObject.SetActive(true);
			isTriggerred = true;
		}
	}

    public override void TurnWeaponOff()
    {
        base.TurnWeaponOff();
		if (isTriggerred)
		{
			VacuumArea.gameObject.SetActive(false);
			isTriggerred = false;
		}

	}
}