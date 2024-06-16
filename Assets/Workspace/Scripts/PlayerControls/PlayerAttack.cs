using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Reload Reload;
    public Hotbar Hotbar;
    public Transform ItemParent;

    public void Attack()
    {
        if (!Reload.CanShoot) return;
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
