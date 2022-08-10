using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class NotesManager : MonoBehaviour
{
    public static float noteSpeedScale = 10f;
    private Dictionary<KeyCode, NoteSpawner> _spawners = new Dictionary<KeyCode, NoteSpawner>();
    private Queue<NoteData> _notedataQueue = new Queue<NoteData>();

    [SerializeField] private Transform _spawnersPoint;
    [SerializeField] private Transform _noteHittersPoint;


    public float noteFallingDistance
    {
        get => _spawnersPoint.position.y - _noteHittersPoint.position.y;
    }

    

    public float noteFallingTime
    {
        get => noteFallingDistance / noteSpeedScale;
    }

    [SerializeField] private VideoPlayer _videoPlayer;
    public void StartSpawn()
    {
        if (_notedataQueue.Count > 0)
        {          
            StartCoroutine(E_Spawning());
            Invoke("PlayVideoPlayer", noteFallingTime);
        }
    }

    IEnumerator E_Spawning()
    {
        float startTimeMark = Time.time;
        while(_notedataQueue.Count > 0)
        {
            for (int i = 0; i < _notedataQueue.Count; i++)
            {
                if(_notedataQueue.Peek().time < (Time.time - startTimeMark))
                {
                    NoteData noteData = _notedataQueue.Dequeue();

                    _spawners[noteData.keycode].SpawnNote().speed *= noteData.speedScale;
                }
                else
                {
                    break;
                }
                
            }
            yield return null;
        }
    }

    private void PlayVideoPlayer()
    {
        _videoPlayer.clip = SongSelector.instance.clip;
        _videoPlayer.Play();
    }
    private void Awake()
    {      
        StartCoroutine(E_Init());
    }
    IEnumerator E_Init()
    {
        NoteSpawner[] spawners = GameObject.Find("NoteSpawners").GetComponentsInChildren<NoteSpawner>();
        for (int i = 0; i < spawners.Length; i++)
        {
            _spawners.Add(spawners[i].keyCode, spawners[i]);
        }
        yield return new WaitUntil(() => SongSelector.instance != null &&
                                         SongSelector.instance.isDataLoaded);

        List<NoteData> notesData = SongSelector.instance.songData.notes;
        for (int i = 0; i < notesData.Count; i++)
        {
            float tmpspeedScale = 0;
            if (notesData[i].speedScale > 0)
                tmpspeedScale = notesData[i].speedScale;
            else
                tmpspeedScale = 1;

            float timeScaled = notesData[i].time * tmpspeedScale;
            notesData[i].time = timeScaled;
        }

        notesData.Sort((x, y) => x.time.CompareTo(y.time));
        for (int i = 0; i < notesData.Count; i++)
        {
            _notedataQueue.Enqueue(notesData[i]);
        }
    }
}
