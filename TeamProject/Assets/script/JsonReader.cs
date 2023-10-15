using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class JsonReader : MonoBehaviour
{
    [System.Serializable]
    public class NPC
    {
        public string question;
        public List<string> options;
        public string answer;
    }

    [System.Serializable]
    public class NPCList
    {
        public NPC[] ps;
        public NPC[] prog;
        public NPC[] it;
        public NPC[] ads;
        public NPC[] adm;
    }

    private readonly string json = System.IO.File.ReadAllText(@"../TeamProject/Assets/JSON/questionsLevel1.json");
    public NPCList myNPCList = new NPCList();
    
    // Start is called before the first frame update
    void Start()
    {
        myNPCList = JsonUtility.FromJson<NPCList>(json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
