using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MagicItem
{
	[SerializeField] private int _value;

	public override int Value => _value;
}
