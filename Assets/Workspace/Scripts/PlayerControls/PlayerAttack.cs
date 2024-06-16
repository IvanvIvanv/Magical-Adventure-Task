using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Hotbar Hotbar;
    public Transform ItemParent;

    public void Attack()
    {
        PlayAnim();
        Hotbar.TriggerSelected();
    }

    private void PlayAnim()
    {
        var anim = ItemParent.GetComponentInChildren<Animator>();
        if (anim == null) return;
        anim.SetTrigger("Use");
    }
}
