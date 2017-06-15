using UnityEngine;
using System.Collections;

public interface IDamageable {
    bool isEnemy();
    int totalHp { get; set; }
    int hp { get; set; }
    void Damage(int damage);
    void Kill();
}