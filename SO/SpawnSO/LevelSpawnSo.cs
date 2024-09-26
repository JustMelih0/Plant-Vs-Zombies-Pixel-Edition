using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SO_newChapterSO", menuName = "LevelSpawnSo/ChapterSO", order = 0)]
public class LevelSpawnSo : ScriptableObject {
    
    public SpawnSO[] chapterLevels;
}
