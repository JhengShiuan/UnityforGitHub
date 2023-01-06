using UnityEngine;
using Kara.Model;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class TestRoomScene
{
    public void TestRoomSceneYaml()
    {
        var yml = @"
rooms:
- pos: 2
  build_id: 1011
  slave_id: 2001
  anim_id: 2
- pos: 5
  build_id: 1021
  slave_id: 2001
  anim_id: 2
- pos: 8
  build_id: 1031
  slave_id: 2001
  anim_id: 2

room_spaces:
-
  - 0
  - 1
  - 2
  - 3
-
  - 0
  - 1
  - 2
  - 3
  - 4
  - 5
  - 6
  - 7

room_layouts:
- x: 0
  y: 1
- x: 10
  y: 1";
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
        try
        {
            var room = deserializer.Deserialize<RoomScene>(yml);
            var serilizer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            var yml2 = serilizer.Serialize(room);
        }
        catch (YamlException e)
        {
            Debug.Log($"Serialize failed: {e}");
        }
    }
}
