using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ObsidianPortal
{
    public class AreaInformation : MonoBehaviour
    {
        public enum Field
        {
            None = 0,
            Plain = 1,
            Forest = 2,
            Sea = 3,
            Mountain = 4,
            Wall = 5,
            Bridge1 = 6,
            Bridge2 = 7,
            Road_V = 8,
            Road_H = 9,
            Wall_1 = 10,
            Road_RB = 11,
            Road_LB = 12,
            Road_TR = 13,
            Road_TL = 14,
        }
        public Field field = Field.Plain;

        public int MoveCost
        {
            get
            {
                if (field == Field.Plain) { return 1; }
                if (field == Field.Road_H) { return 1; }
                if (field == Field.Road_V) { return 1; }
                if (field == Field.Road_LB) { return 1; }
                if (field == Field.Road_RB) { return 1; }
                if (field == Field.Road_TL) { return 1; }
                if (field == Field.Road_TR) { return 1; }
                if (field == Field.Bridge1) { return 1; }
                if (field == Field.Bridge2) { return 1; }
                if (field == Field.Plain) { return 1; }
                if (field == Field.Forest) { return 2; }
                if (field == Field.Mountain) { return 999; }
                if (field == Field.None) { return 999; }
                if (field == Field.Wall) { return 999; }
                return 999;
            }
        }

        public List<AreaInformation> connectNode = new List<AreaInformation>();

        public int cost = -1; //探索に要したコスト。-1の時はそのノードを未探索としています。
        public AreaInformation toGoal = null; //ゴールへの最短ルートにつながるノード
    }
}