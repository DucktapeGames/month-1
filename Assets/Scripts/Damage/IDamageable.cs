using UnityEngine;
using System.Collections;

public interface IDamageable {
    bool IsEnemy();
    int TotalHp { get; set; }
    int Hp { get; set; }
    void Damage(int damage);
    void Kill();
}