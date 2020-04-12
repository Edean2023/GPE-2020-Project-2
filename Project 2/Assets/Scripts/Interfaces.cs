using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces : MonoBehaviour
{
    public interface Idamageable<T>
    {
        int Health { get; set; }
    }

    public interface Ikillable
    {
        void Kill();
    }
}
