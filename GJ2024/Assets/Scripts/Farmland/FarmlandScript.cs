using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmlandScript : MonoBehaviour
{
    public MeshRenderer mesh;
    public bool hasPlant;
    public bool isWet;
    public GameObject attachedCrop;
    public Crops cropp;
    public Material dryMat, wetMat;

    public void SetWet()
    {
        mesh.material = wetMat;
        isWet = true;

        if(attachedCrop != null)
        {
            cropp = attachedCrop.GetComponent<Crops>();
            cropp.StartGrow();
        }
    }

    public void SetDry()
    {
        mesh.material = dryMat;
        isWet = false;
    }
}
