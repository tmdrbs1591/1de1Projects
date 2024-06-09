using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReFirstStage : MonoBehaviour
{
    public ParallaxScroll map;
    public GameObject SpeedEffect;
    public GameObject ClearPanel;
    public GameObject Warning;
    public AudioSource Song;
    public PlaayerController thePlayerController;
    public int bpm = 120;
    double currentTime = 0d;
    int noteCount = 0; // 생성된 노트의 수

    enum BeatType
    {
        Whole = 1,
        Half = 2,
        Quarter = 4,
        Eighth = 8,
        Sixteenth = 16
    }

    public ObjectManager objectManager;
    public GameObject PowerEffect;

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject go1 = null;
    [SerializeField] GameObject go2 = null;
    [SerializeField] GameObject go3 = null;
    [SerializeField] GameObject go4 = null;
    [SerializeField] GameObject go5 = null;
    [SerializeField] GameObject go6 = null;

    TimingManager theTimingManager;
    EffectManager theEffectManager;
    ComboManager thecomboManager;

    void Start()
    {
        Song.Stop();
        thecomboManager = FindObjectOfType<ComboManager>();
        theEffectManager = FindObjectOfType<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();
    }

    void FixedUpdate()
    {
        if (thePlayerController != null)
        {
            thePlayerController = FindObjectOfType<PlaayerController>();

        }

        double beatInterval = 60d / bpm;

        currentTime += Time.deltaTime;
        #region beat

        if (noteCount < 1)
        {
            if (currentTime >= beatInterval * 4.4f)
            {
                Song.Play();
                SpawnRandomNote();
                currentTime -= beatInterval * 4.4f;
                noteCount++;
            }
        }
        else if (noteCount < 3)
        {
            if (currentTime >= beatInterval * 1.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.7f;
                noteCount++;
            }
        }
        else if (noteCount < 6)
        {
            if (currentTime >= beatInterval * 2)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.75f;
                noteCount++;
            }
        }
        else if (noteCount < 7)
        {
            if (currentTime >= beatInterval * 3.5f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 3.5f;
                noteCount++;
            }
        }
        else if (noteCount < 13)
        {
            if (currentTime >= beatInterval * 1.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.78f;
                noteCount++;
            }
        }
        else if (noteCount < 14)
        {
            if (currentTime >= beatInterval * 2.8f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 16)
        {
            if (currentTime >= beatInterval * 1.5f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.5f;
                noteCount++;
            }
        }
        else if (noteCount < 17)
        {
            if (currentTime >= beatInterval * 2.45f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 2.45f;
                noteCount++;
            }
        }
        else if (noteCount < 19)
        {
            if (currentTime >= beatInterval * 0.6f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.34f;
                noteCount++;
            }
        }
        else if (noteCount < 21)
        {
            if (currentTime >= beatInterval * 1f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.65f;
                noteCount++;
            }
        }
        else if (noteCount < 22)
        {
            if (currentTime >= beatInterval * 2.7f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 24)
        {
            if (currentTime >= beatInterval * 1.7f)
            {
                Warning.SetActive(true);
                SpawnENote();
                currentTime -= beatInterval * 0.35f;
                noteCount++;
            }
        }
        else if (noteCount < 25)
        {
            if (currentTime >= beatInterval * 2.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 2.3;
                noteCount++;
            }
        }
        else if (noteCount < 43)
        {
            if (currentTime >= beatInterval * 1.3f)
            {
                SpawnSpaceNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 47) // StartStartStartStartStartStart
        {
            if (currentTime >= beatInterval * 1.5f)
            {
                Warning.SetActive(false);

                SpawnRandomNote();
                currentTime -= beatInterval * 0.44f;
                noteCount++;
            }
        }
        else if (noteCount < 50)
        {
            if (currentTime >= beatInterval * 2.9f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 52)
        {
            if (currentTime >= beatInterval * 3.5f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.7f;
                noteCount++;
            }
        }
        else if (noteCount < 56) // OOOO
        {
            if (currentTime >= beatInterval * 5f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.44f;
                noteCount++;
            }
        }
        else if (noteCount < 59)
        {
            if (currentTime >= beatInterval * 6.5f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 61)
        {
            if (currentTime >= beatInterval * 7f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.7f;
                noteCount++;
            }
        }
        else if (noteCount < 64)
        {
            if (currentTime >= beatInterval * 7.4f)
            {
                SpawnQWNote();
                currentTime -= beatInterval * 0.53f;
                noteCount++;
            }
        }
        else if (noteCount < 68) // OOOO
        {
            if (currentTime >= beatInterval * 7.2f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.44f;
                noteCount++;
            }
        }
        else if (noteCount < 71)
        {
            if (currentTime >= beatInterval * 8.5f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 73)
        {
            if (currentTime >= beatInterval * 9.1f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.7f;
                noteCount++;
            }
        }
        else if (noteCount < 74)
        {
            if (currentTime >= beatInterval * 10.9f)
            {
                SpawnDoubleRandomNote();
                currentTime -= beatInterval * 10.72f;
                noteCount++;
            }
        }
        else if (noteCount < 78) // OOOO
        {
            if (currentTime >= beatInterval * 2.3f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.44f;
                noteCount++;
            }
        }
        else if (noteCount < 80) // OOOO
        {
            if (currentTime >= beatInterval * 2.6f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.6f;
                noteCount++;
            }
        }
        else if (noteCount < 81) 
        {
            if (currentTime >= beatInterval * 3.5f)
            {

                SpawnDoubleRandomNote();
                currentTime -= beatInterval * 0.65f;
                noteCount++;
            }
        }
        else if (noteCount < 85) // OOOO
        {
            if (currentTime >= beatInterval * 3.8f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.5f;
                noteCount++;
            }
        }
        else if (noteCount < 88)
        {
            if (currentTime >= beatInterval * 5f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 90)
        {
            if (currentTime >= beatInterval * 5.5f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.65f;
                noteCount++;
            }
        }
        else if (noteCount < 94) // OOOO
        {
            if (currentTime >= beatInterval * 7.2f)
            {

                SpawnRandomNote();
                currentTime -= beatInterval * 0.48f;
                noteCount++;
            }
        }
        else if (noteCount < 97)
        {
            if (currentTime >= beatInterval * 8.6f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 99)
        {
            if (currentTime >= beatInterval * 9f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.68f;
                noteCount++;
            }
        }
        else if (noteCount < 102) // OOO
        {
            if (currentTime >= beatInterval * 9.3f)
            {

                SpawnEWNote();
                currentTime -= beatInterval * 0.5f;
                noteCount++;
            }
        }
        else if (noteCount < 106) // OOOO
        {
            if (currentTime >= beatInterval * 9.2f)
            {
                
                SpawnRandomNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 109)
        {
            if (currentTime >= beatInterval * 10.8f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 111)
        {
            if (currentTime >= beatInterval * 11.1f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.68f;
                noteCount++;
            }
        }
        else if (noteCount < 112)
        {
            if (currentTime >= beatInterval * 12.8f)
            {
                SpawnDoubleRandomNote();
                currentTime -= beatInterval * 0.68f;
                noteCount++;
            }
        }
        else if (noteCount < 116)
        {
            if (currentTime >= beatInterval * 14.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.58f;
                noteCount++;
            }
        }
        else if (noteCount < 118)
        {
            if (currentTime >= beatInterval * 14.4f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.62f;
                noteCount++;
            }
        }
        else if (noteCount < 123)
        {
            if (currentTime >= beatInterval * 17.5f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 126)
        {
            if (currentTime >= beatInterval * 17.8f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.5f;
                noteCount++;
            }
        }
        else if (noteCount < 128)
        {
            if (currentTime >= beatInterval * 18.2f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 133)
        {
            if (currentTime >= beatInterval * 20.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 136)
        {
            if (currentTime >= beatInterval * 21.7f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 138)
        {
            if (currentTime >= beatInterval * 22.1f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.51f;
                noteCount++;
            }
        }
        else if (noteCount < 143)
        {
            if (currentTime >= beatInterval * 23.5f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 146)
        {
            if (currentTime >= beatInterval * 24.1f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 149)
        {
            if (currentTime >= beatInterval * 24.6f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 151)
        {
            if (currentTime >= beatInterval * 24.8f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.6f;
                noteCount++;
            }
        }
        else if (noteCount < 154)
        {
            if (currentTime >= beatInterval * 25.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 180)
        {
            if (currentTime >= beatInterval * 25.3f)
            {
                SpawnSpaceNote();
                currentTime -= beatInterval * 0.15f;
                noteCount++;
            }
        }
        else if (noteCount < 181)
        {
            if (currentTime >= beatInterval * 25.47f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 25.3f;
                noteCount++;
            }
        }
        else if (noteCount < 183)
        {
            if (currentTime >= beatInterval * 1.2f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.4f;
                noteCount++;
            }
        }
        else if (noteCount < 186)
        {
            if (currentTime >= beatInterval * 1.34f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 187)
        {
            if (currentTime >= beatInterval * 2f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 190)
        {
            if (currentTime >= beatInterval * 1f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.4f;
                noteCount++;
            }
        }
        else if (noteCount < 193)
        {
            if (currentTime >= beatInterval * 1.3f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 194)
        {
            if (currentTime >= beatInterval * 2f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 1.9f;
                noteCount++;
            }
        }
        else if (noteCount < 195)
        {
            if (currentTime >= beatInterval * 1f)
            {
                SpawnENote();
                currentTime -= beatInterval * 1F;
                noteCount++;
            }
        }
        else if (noteCount < 196)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 197)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 198)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 199)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 200)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 201)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 204)
        {
            if (currentTime >= beatInterval * 1f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.35f;
                noteCount++;
            }
        }
        else if (noteCount < 207)
        {
            if (currentTime >= beatInterval * 1.4f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 209)
        {
            if (currentTime >= beatInterval * 2.13f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.3f;
                noteCount++;
            }
        }
        else if (noteCount < 211)
        {
            if (currentTime >= beatInterval * 2.78f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.3f;
                noteCount++;
            }
        }
        else if (noteCount < 214)
        {
            if (currentTime >= beatInterval * 3.37f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 215)
        {
            if (currentTime >= beatInterval * 4.1f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 4.1f;
                noteCount++;
            }
        }
        else if (noteCount < 218)
        {
            if (currentTime >= beatInterval * 0.95f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.32f;
                noteCount++;
            }
        }
        else if (noteCount < 221)
        {
            if (currentTime >= beatInterval * 1.47f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 222)
        {
            if (currentTime >= beatInterval * 1.9f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 2;
                noteCount++;
            }
        }
        else if (noteCount < 223)
        {
            if (currentTime >= beatInterval * 1.1f)
            {
                SpawnENote();
                currentTime -= beatInterval * 1.1f;
                noteCount++;
            }
        }
        else if (noteCount < 224)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 225)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 226)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 227)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 228)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 229)
        {
            if (currentTime >= beatInterval * 0.44f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 234)
        {
            if (currentTime >= beatInterval * 0.85f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 237)
        {
            if (currentTime >= beatInterval * 1f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 238)
        {
            if (currentTime >= beatInterval * 1.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 240)
        {
            if (currentTime >= beatInterval * 2f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.35f;
                noteCount++;
            }
        }
        else if (noteCount < 243)
        {
            if (currentTime >= beatInterval * 2.44f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 244)
        {
            if (currentTime >= beatInterval * 3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 247)
        {
            if (currentTime >= beatInterval * 3.8f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.35f;
                noteCount++;
            }
        }
        else if (noteCount < 250)
        {
            if (currentTime >= beatInterval * 4f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 251)
        {
            if (currentTime >= beatInterval * 5f)
            {
                SpawnQWNote();
                currentTime -= beatInterval * 5f;
                noteCount++;
            }
        }
        else if (noteCount < 252)
        {
            if (currentTime >= beatInterval * 0.8f)
            {
                SpawnEWNote();
                currentTime -= beatInterval * 0.8f;
                noteCount++;
            }
        }
        else if (noteCount < 253)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnQWNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 254)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnEWNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 255)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnQWNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 256)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnEWNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 257)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnQWNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 258)
        {
            if (currentTime >= beatInterval * 0.45f)
            {
                SpawnEWNote();
                currentTime -= beatInterval * 0.45f;
                noteCount++;
            }
        }
        else if (noteCount < 261)
        {
            if (currentTime >= beatInterval * 0.8f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.4f;
                noteCount++;
            }
        }
        else if (noteCount < 264)
        {
            if (currentTime >= beatInterval * 1.1f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
            }
        }
        else if (noteCount < 265)
        {
            if (currentTime >= beatInterval * 2.6f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 2.6f;
                noteCount++;
            }
        }
        else if (noteCount < 267)
        {
            if (currentTime >= beatInterval * 0.7f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.35f;
                noteCount++;
            }
        }
        else if (noteCount < 270)
        {
            if (currentTime >= beatInterval * 1f)
            {
                SpawnQWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;
         
            }
        }
        else if (noteCount < 271)
        {
            if (currentTime >= beatInterval * 1.9f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 2f;
                noteCount++;
            }
        }
        else if (noteCount < 274)
        {
            if (currentTime >= beatInterval * 0.9f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.3f;
                noteCount++;
            }
        }
        else if (noteCount < 277)
        {
            if (currentTime >= beatInterval * 1.23f)
            {
                SpawnEWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;

            }
        }
        else if (noteCount < 279)
        {
            if (currentTime >= beatInterval * 4.6f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.6f;
                noteCount++;

            }
        }
        else if (noteCount < 281)
        {
            if (currentTime >= beatInterval * 4.67f)
            {
                SpawnQNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;

            }
        }
        else if (noteCount < 283)
        {
            if (currentTime >= beatInterval * 5.1f)
            {
                SpawnWNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;

            }
        }
        else if (noteCount < 285)
        {
            if (currentTime >= beatInterval * 5.5f)
            {
                SpawnENote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;

            }
        }
        else if (noteCount < 320)
        {
            if (currentTime >= beatInterval * 7f)
            {
                SpawnSpaceNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;

            }
        }
        else if (noteCount < 321)
        {
            if (currentTime >= beatInterval * 7.9f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 7.9f;
                noteCount++;

            }
        }
        else if (noteCount < 323)
        {
            if (currentTime >= beatInterval * 0.8f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.3f;
                noteCount++;

            }
        }
        else if (noteCount < 324)
        {
            if (currentTime >= beatInterval * 1.7f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 1.7f;
                noteCount++;

            }
        }
        else if (noteCount < 326)
        {
            if (currentTime >= beatInterval * 0.9f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.4f;
                noteCount++;

            }
        }
        else if (noteCount < 328)
        {
            if (currentTime >= beatInterval * 1.5f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.36f;
                noteCount++;

            }
        }
        else if (noteCount < 329)
        {
            if (currentTime >= beatInterval * 3.5f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 3.5f;
                noteCount++;

            }
        }
        else if (noteCount < 331)
        {
            if (currentTime >= beatInterval * 0.9f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.4f;
                noteCount++;

            }
        }
        else if (noteCount < 332)
        {
            if (currentTime >= beatInterval * 1.7f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 1.7f;
                noteCount++;

            }
        }
        else if (noteCount < 334)
        {
            if (currentTime >= beatInterval * 0.8f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.4f;
                noteCount++;

            }
        }
        else if (noteCount < 336)
        {
            if (currentTime >= beatInterval * 1.5f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.4f;
                noteCount++;

            }
        }
        else if (noteCount < 337)//dddddddddd
        {
            if (currentTime >= beatInterval * 4f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 4f;
                noteCount++;

            }
        }
        else if (noteCount < 338)
        {
            if (currentTime >= beatInterval * 2f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval *2f;
                noteCount++;

            }
        }
        else if (noteCount < 340)
        {
            if (currentTime >= beatInterval * 2.3f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 0.2f;
                noteCount++;

            }
        }
        else if (noteCount < 341)
        {
            if (currentTime >= beatInterval * 4.1f)
            {
                SpawnRandomNote();
                currentTime -= beatInterval * 4.1f;
                noteCount++;
                StartCoroutine(ClearPanelCor());

            }
        }
    }

    IEnumerator ClearPanelCor()
    {

        yield return new WaitForSeconds(4f);
        ClearPanel.SetActive(true);
    }
    #endregion
    IEnumerator Effect()
    {
        yield return new WaitForSeconds(1.4f);



        map.MapSpeed *= 1000;

        PowerEffect.SetActive(true);
    }
    void SpawnRandomNote()
    {
        int randomIndex = Random.Range(1, 4);
        GameObject t_note = null;
        switch (randomIndex)
        {
            case 1:

                t_note = Instantiate(go1, tfNoteAppear.position, Quaternion.identity);
                break;
            case 2:
                t_note = Instantiate(go2, tfNoteAppear.position, Quaternion.identity);
                break;
            case 3:
                t_note = Instantiate(go3, tfNoteAppear.position, Quaternion.identity);
                break;
            default:
                break;
        }
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnDoubleRandomNote()
    {
        int randomIndex = Random.Range(1, 3);
        GameObject t_note = null;
        switch (randomIndex)
        {
            case 1:

                t_note = Instantiate(go4, tfNoteAppear.position, Quaternion.identity);
                break;
            case 2:
                t_note = Instantiate(go5, tfNoteAppear.position, Quaternion.identity);
                break;

            default:
                break;
        }
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnQNote()
    {
        GameObject t_note = Instantiate(go1, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnWNote()
    {
        GameObject t_note = Instantiate(go2, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnSpaceNote()
    {
        GameObject t_note = Instantiate(go6, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnENote()
    {
        GameObject t_note = Instantiate(go3, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnQWNote()
    {
        GameObject t_note = Instantiate(go4, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    void SpawnEWNote()
    {
        GameObject t_note = Instantiate(go5, tfNoteAppear.position, Quaternion.identity);
        if (t_note != null)
        {
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {

            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                thePlayerController.TakeDamage(1);
                theEffectManager.judgementEffect(4);
                thecomboManager.ResetCombo();
            }


            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }

    }
}
