using UnityEngine;

public class WinDoorActivationAreaScript : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Opening", true);
    }
}
