using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyBehaviour
{
    public void Idle();
    public void Patrol();
    public void Chase();
    public void Attack();
    public void GotHit();
    public void Dead();


}
