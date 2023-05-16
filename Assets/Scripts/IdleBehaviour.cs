using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
	[SerializeField] private float _timeUntilBored = 3f;
	[SerializeField] private int _numBoredAnims;
	private bool _isBored;
	private float _idleTime;
	private int _boredAnim;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//Debug.Log("Begin Idle");
		ResetIdle();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (_isBored == false)
		{
			_idleTime += Time.deltaTime;
			
			if (_idleTime > _timeUntilBored && stateInfo.normalizedTime % 1 < 0.02)
			{
				_isBored = true;
				_boredAnim = Random.Range(1, _numBoredAnims + 1);
				animator.SetInteger("Animation_int", _boredAnim);
				Debug.Log("This is the bored anim = "+_boredAnim);
			}
		}
		else if (stateInfo.normalizedTime % 1 > 0.98)
		{
			Debug.Log("Reseting Idle");
			ResetIdle();
		}
	}
	private void ResetIdle()
	{
		Debug.Log("Idle Reset");

		_isBored = false;
		_idleTime = 0;
		_boredAnim = 0;
	}
}
