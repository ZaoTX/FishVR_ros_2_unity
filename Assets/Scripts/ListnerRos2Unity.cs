// Copyright 2019-2021 Robotec.ai.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using UnityEngine;

namespace ROS2
{

/// <summary>
/// An example class provided for testing of basic ROS2 communication
/// </summary>
public class ListenerROS2Unity : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<std_msgs.msg.String> string_sub;
    private ISubscription<std_msgs.msg.Bool> bool_sub;
    private ISubscription<std_msgs.msg.Float32> float_sub; 
    private ISubscription<geometry_msgs.msg.Point> point_sub;
    private ISubscription<diagnostic_msgs.msg.KeyValue> key_value_sub;
    private ISubscription<geometry_msgs.msg.Pose> pose_sub;

    public synposition syn_pos;
    void Start()
    {
        ros2Unity = GetComponent<ROS2UnityComponent>();
        
    }
   
    void Update()
    {
        if (ros2Node == null && ros2Unity.Ok())
        {
            ros2Node = ros2Unity.CreateNode("ROS2UnityListenerNode");
            // string_sub = ros2Node.CreateSubscription<std_msgs.msg.String>(
            //   "string", msg => Debug.Log("Unity listener heard: [" + msg.Data + "]"));
            // bool_sub = ros2Node.CreateSubscription<std_msgs.msg.Bool>(
            //   "bool", msg => Debug.Log("Unity listener heard: [" + msg.Data + "]"));
            // float_sub = ros2Node.CreateSubscription<std_msgs.msg.Float32>(
            //   "float", msg => Debug.Log("Unity listener heard: [" + msg.Data + "]"));
            point_sub = ros2Node.CreateSubscription<geometry_msgs.msg.Point>(
              "point2", msg => {Debug.Log("point: x" + msg.X + "point: y" +   "point: z" + msg.Z);
               syn_pos.x = msg.X;
               syn_pos.y = msg.Y;
               syn_pos.z = msg.Z;
               syn_pos.triggered = true;
              });
            pose_sub = ros2Node.CreateSubscription<geometry_msgs.msg.Pose>(
              "pose_now", msg => {Debug.Log("point: x" + msg.Position.X + "point: y" + msg.Position.Y+  "point: z" + msg.Position.Z);
               syn_pos.x = msg.Position.X;
               syn_pos.y = msg.Position.Y;
               syn_pos.z = msg.Position.Z;
               syn_pos.ori_w = msg.Orientation.W;
               syn_pos.ori_x = msg.Orientation.X;
               syn_pos.ori_y = msg.Orientation.Y;
               syn_pos.ori_z = msg.Orientation.Z;
               syn_pos.triggered = true;
              }
            );
            // key_value_sub = ros2Node.CreateSubscription<diagnostic_msgs.msg.KeyValue>(
            //   "keyvalue", msg => Debug.Log("Key: " + msg.Key + "Value:"+ msg.Value));
        }
    }
}

}  // namespace ROS2
