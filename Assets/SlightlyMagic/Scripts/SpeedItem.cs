using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MagicItem
{
	[SerializeField] private int _minValue;
	[SerializeField] private int _maxValue;

	public override int Value => Random.Range(_minValue, _maxValue);

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void Update()
	{
		base.Update();
	}
}
