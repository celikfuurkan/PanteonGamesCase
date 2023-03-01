using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public static List<AudioClip> sound; //static list
    public List<AudioClip> _sound; //public list
    public static int random;

    void Start()
    {
        sound = _sound;
    }


    /// <summary>
    /// sound listesi içinden rastgele bir soundu seçmek için random sayý üretir.
    /// </summary>
    public static void RandomNumber()
    {
       random= Random.Range(0, 4);
    }
}
