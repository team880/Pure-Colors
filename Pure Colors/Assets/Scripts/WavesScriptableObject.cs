using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New wave", menuName = "Wave")]

public class WavesScriptableObject : ScriptableObject
{
    public List<MiniWavesScriptableObject> wave;
}

[CreateAssetMenu(fileName = "New miniwave", menuName = "Mini-wave")]
public class MiniWavesScriptableObject : ScriptableObject
{
    public MiniWave miniWave;
}

[CreateAssetMenu(fileName = "New level of waves", menuName = "Level")]
public class LevelScriptableObject : ScriptableObject
{
    public List<WavesScriptableObject> waves;
}