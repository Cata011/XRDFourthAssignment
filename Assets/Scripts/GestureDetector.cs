using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognized;
}
public class GestureDetector : MonoBehaviour
{
    public float threshold = 0.1f; 
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    private List<OVRBone> fingerbones;
    private Gesture previousGesture;
    public bool debugMode=true;
    // Start is called before the first frame update
    void Start()
    {
        fingerbones = new List<OVRBone>(skeleton.Bones);
        previousGesture = new Gesture();
    }

    // Update is called once per frame
    void Update()
    {
        if (debugMode && Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }

        Gesture gesture = Recognize();
        bool hasRecognized = !gesture.Equals(new Gesture());
        if (hasRecognized && !gesture.Equals(previousGesture))
        {
            Debug.Log("Gesture found: " + gesture.name);
            gesture.onRecognized.Invoke();
        }
    }
    void Save()
    {
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();
        foreach (var bone in fingerbones)
        {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerDatas = data;
        gestures.Add(g);
    }


    Gesture Recognize()
    {
        Gesture current = new Gesture();
        float currentMin = Mathf.Infinity;

        foreach (var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerbones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerbones[1].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]);
                if (distance > threshold)
                {
                    isDiscarded = true;
                    break;
                }

                sumDistance += distance;
            }

            if (!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                current = gesture;
            }
        }

        return current;
    }
}
