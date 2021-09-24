using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(menuName = "Animator Controller List")]
public class AnimatorControllerList : ScriptableObject
{
    [Tooltip("The possible animator controllers to use. ")]
    public List<RuntimeAnimatorController> animatorControllers = new List<RuntimeAnimatorController>();

    public RuntimeAnimatorController GetAnimatorController(){
        RuntimeAnimatorController result = null;
        if(animatorControllers.Count <= 0){
            Debug.LogErrorFormat("Warning: animatorControllers on AnimatorControllerList {0} is null or empty.", new object[]{
                this.name
            });
            return null;
        }
        int index = UnityEngine.Random.Range(0, animatorControllers.Capacity - 1);
        return animatorControllers[index];
    }
}
