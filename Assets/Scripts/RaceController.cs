using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour {
    public int lapsInRace;
    private int nextCheckpointNumber;
    private int checkpointCount;
    private int lapCount;
    private float lapStartTime;
    private List<float> lapTimes = new List<float>();
    private Checkpoint activeCheckpoint;
    public GameManager gameManager;


    void Start () {
        nextCheckpointNumber = 0;
        checkpointCount = this.transform.childCount;

        for (int i = 0; i < checkpointCount; i++) {
            Checkpoint cp = transform.GetChild(i).GetComponent<Checkpoint>();
            cp.checkpointNumber = i;
            cp.isActiveCheckpoint = false;
        }
        StartRace();
	}
	
    public void StartRace() {
        activeCheckpoint = transform.GetChild(nextCheckpointNumber).GetComponent<Checkpoint>();
        activeCheckpoint.isActiveCheckpoint = true;
        lapStartTime = Time.time;
    }

    public void CheckpointPassed() {
        activeCheckpoint.isActiveCheckpoint = false;
        nextCheckpointNumber++;
        if (nextCheckpointNumber < checkpointCount) {
            activeCheckpoint = transform.GetChild(nextCheckpointNumber).GetComponent<Checkpoint>();
            activeCheckpoint.isActiveCheckpoint = true;
        }
        else
        {
            lapTimes.Add(Time.time - lapStartTime);
            lapCount++;
            lapStartTime = Time.time;
            nextCheckpointNumber = 0;
            if (lapCount < lapsInRace)
            {
                activeCheckpoint = transform.GetChild(nextCheckpointNumber).GetComponent<Checkpoint>();
                activeCheckpoint.isActiveCheckpoint = true;
            }
            else {
                float raceTotalTime = 0.0f;
                float fastestLapTime = lapTimes[0];
                for (int i = 0; i < lapsInRace; i++)
                {
                    if (lapTimes[i] < fastestLapTime) {
                        fastestLapTime = lapTimes[i];
                    }
                    raceTotalTime += lapTimes[i];
                }
            }
            gameManager.loadingScreenToNextLevel();
        }
    }
}