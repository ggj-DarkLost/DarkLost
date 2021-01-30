using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    [Header("主角音效")]
    public AudioClip walkAudio, openTorchAudio, reflectAudio, stuckAudio, outAudio;
    [Header("敌人音效")]
    public AudioClip enemyAudio;
    [Header("狗叫")]
    public AudioClip dogAudio;

    private void Awake()
    {
        instance = this;
    }
    //走路
    public void WalkAudio()
    {
        audioSource.clip = walkAudio;
        audioSource.Play();
    }
    //开关手电
    public void OpenTorchAudio()
    {
        audioSource.clip = openTorchAudio;
        audioSource.Play();
    }
    //反射光
    public void ReflectAudio()
    {
        audioSource.clip = reflectAudio;
        audioSource.Play();
    }
    //困住
    public void StuckAudio()
    {
        audioSource.clip = stuckAudio;
        audioSource.Play();
    }
    //解除捆绑
    public void OutAudio()
    {
        audioSource.clip = outAudio;
        audioSource.Play();
    }
    //敌人叫声
    public void EnemyAudio()
    {
        audioSource.clip = enemyAudio;
        audioSource.Play();
    }
    //狗叫
    public void DogAudio()
    {
        audioSource.clip = dogAudio;
        audioSource.Play();
    }
}
