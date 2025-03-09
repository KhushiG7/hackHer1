using UnityEngine;
using System.Collections;

public class AnimationChangeSpeedEating : MonoBehaviour
{
    private Animator anim;
    public float newSpeed = 20f;
    public float resetTime = 3f;

    void Start() {
        anim = GetComponent<Animator>();
    }

    public void ChangeAnimationSpeed() {
        if (anim != null) {
            anim.speed = newSpeed;
            StartCoroutine(ResetAnimationSpeed());
        }
    }

    private IEnumerator ResetAnimationSpeed() {
        yield return new WaitForSeconds(resetTime);
        anim.speed = 1f;
    }
}
