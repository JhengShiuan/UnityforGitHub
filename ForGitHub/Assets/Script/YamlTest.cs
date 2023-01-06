using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Kara.Model;

public class YamlTest : MonoBehaviour
{
    private GameObject CreatBuild;
    public _BuildId BuildId;

    public enum _BuildId
    {
        Arena = 0,
        Dungeon = 1,
        Anteroom = 2,
    }

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("KeyCode.A");

            var path = Application.dataPath + "/Resources/YamlData/Build.yaml";
            string ymalData = File.ReadAllText(path);
            
            var deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();
            RoomScene RoomScenedata = deserializer.Deserialize<RoomScene>(ymalData);
            CreatBuild = (GameObject)Resources.Load($"Build/{RoomScenedata.Rooms[((int)BuildId)].BuildId}");

            CreatBuild.transform.localPosition = Vector3.zero;
            Instantiate(CreatBuild);
            
        }
}
                                                                   
}
