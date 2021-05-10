using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFSA
{
    class Program
    {
        public class Node
        {
            public string Name;
            public int H;
            public int SC;
            public List<Node> MyCildren = new List<Node>();
        }

        public class History
        {
            public List<Node> Opened = new List<Node>();
            public List<Node> Closed = new List<Node>();
        }

        static public List<Node> Nodes;

        static public List<History> All;

        static void Main(string[] args)
        {
            Create();
            //PrintALL();
            DFS_Algorithm();
            Print_Opend_And_Closed();
        }

        static public void Create()
        {
            Nodes = new List<Node>();
            
            Node pnn = new Node();

            //Parent1
            pnn.Name = "S";
            pnn.H = 0;
            pnn.SC = 0;

            //Cildern1
            Node pnc = new Node();
            pnc.Name = "A";
            pnc.H = 7;
            pnc.SC = 1;
            pnn.MyCildren.Add(pnc);
            //Childer2
            pnc = new Node();
            pnc.Name = "B";
            pnc.H = 10;
            pnc.SC = 8;
            pnn.MyCildren.Add(pnc);
            //Childer3
            pnc = new Node();
            pnc.Name = "C";
            pnc.H = 5;
            pnc.SC = 4;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);
            
            //Parent2
            pnn = new Node();
            pnn.Name = "A";
            pnn.H = 7;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "D";
            pnc.H = 4;
            pnc.SC = 5;
            pnn.MyCildren.Add(pnc);
            //Childer2
            pnc = new Node();
            pnc.Name = "H";
            pnc.H = 6;
            pnc.SC = 12;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);
            
            //Parent3
            pnn = new Node();
            pnn.Name = "B";
            pnn.H = 10;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "H";
            pnc.H = 6;
            pnc.SC = 1;
            pnn.MyCildren.Add(pnc);
            //Childer2
            pnc = new Node();
            pnc.Name = "G1";
            pnc.H = 0;
            pnc.SC = 4;
            pnn.MyCildren.Add(pnc);
            //Childer3
            pnc = new Node();
            pnc.Name = "J";
            pnc.H = 8;
            pnc.SC = 4;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);
            
            //Parent4
            pnn = new Node();
            pnn.Name = "C";
            pnn.H = 5;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "E";
            pnc.H = 7;
            pnc.SC = 2;
            pnn.MyCildren.Add(pnc);
            //Childer2
            pnc = new Node();
            pnc.Name = "F";
            pnc.H = 9;
            pnc.SC = 6;
            pnn.MyCildren.Add(pnc);
            
            Nodes.Add(pnn);

            //Parent5
            pnn = new Node();
            pnn.Name = "D";
            pnn.H = 4;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "H";
            pnc.H = 6;
            pnc.SC = 2;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent6
            pnn = new Node();
            pnn.Name = "E";
            pnn.H = 7;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "F";
            pnc.H = 9;
            pnc.SC = 10;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent7
            pnn = new Node();
            pnn.Name = "F";
            pnn.H = 9;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "G2";
            pnc.H = 0;
            pnc.SC = 2;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent8
            pnn = new Node();
            pnn.Name = "G1";
            pnn.H = 0;
            pnn.SC = 0;

            Nodes.Add(pnn);

            //Parent9
            pnn = new Node();
            pnn.Name = "H";
            pnn.H = 6;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "J";
            pnc.H = 8;
            pnc.SC = 4;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent10
            pnn = new Node();
            pnn.Name = "J";
            pnn.H = 8;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "G2";
            pnc.H = 0;
            pnc.SC = 2;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent11
            pnn = new Node();
            pnn.Name = "G2";
            pnn.H = 0;
            pnn.SC = 0;

            Nodes.Add(pnn);
        }

        static public void PrintALL()
        {
            int i = 0, j = 0;

            for (i = 0; i < Nodes.Count; i++)
            {
                Console.WriteLine(Nodes[i].Name + "---------");
                for ( j = 0 ; j < Nodes[i].MyCildren.Count ; j++ )
                {
                    Console.WriteLine(Nodes[i].MyCildren[j].Name);
                }
            }

        }

        static public void DFS_Algorithm()
        {
            int Flag = 0;
            All = new List<History>();
            List<Node> Opened = new List<Node>();
            List<Node> Closed = new List<Node>();
            List<Node> Temp = new List<Node>();

            Node MyNode = new Node();
            MyNode = Nodes[0];

            Opened.Add(MyNode);

            History New = new History();
            New.Opened = Opened;
            New.Closed = new List<Node>();
            All.Add(New);

            while (true)
            {
                if (MyNode.Name == "G1" || MyNode.Name == "G2")
                {
                    break;
                }
                int i = 0, j = 0, k = 0, z = 0;
                for (i = 0; i < Nodes.Count; i++)
                {
                    if (Nodes[i].Name == Opened[0].Name)
                    {
                        Temp = new List<Node>();
                        if (Opened[0].Name == "G1" || Opened[0].Name == "G2")
                        {
                            MyNode = new Node();
                            MyNode.Name = Opened[0].Name;
                            break;
                            Closed.Add(Opened[0]);
                            if (Nodes[i].MyCildren.Count > 0)
                            {
                                for (k = 0; k < Nodes[i].MyCildren.Count; k++)
                                {
                                    Flag = 0;
                                    for (z = 0; z < Opened.Count; z++)
                                    {
                                        if (Nodes[i].MyCildren[k].Name == Opened[z].Name)
                                        { Flag = 1; break; }
                                    }
                                    if (Flag == 0)
                                    {
                                        for (z = 0; z < Closed.Count; z++)
                                        {
                                            if (Nodes[i].MyCildren[k].Name == Closed[z].Name)
                                            { Flag = 1; break; }
                                        }
                                    }
                                    if (Flag == 0)
                                    { Temp.Add(Nodes[i].MyCildren[k]); }
                                }
                            }
                            for (j = 1; j < Opened.Count; j++)
                            {
                                Temp.Add(Opened[j]);
                            }
                            Opened = Temp;

                            New = new History();
                            New.Opened = Opened;
                            for (j = 0; j < Closed.Count; j++)
                            {
                                New.Closed.Add(Closed[j]);
                            }
                            All.Add(New);
                        }
                        else
                        {
                            Closed.Add(Opened[0]);
                            if (Nodes[i].MyCildren.Count > 0)
                            {
                                for (k = 0; k < Nodes[i].MyCildren.Count; k++)
                                {
                                    Flag = 0;
                                    for (z = 0; z < Opened.Count; z++)
                                    {
                                        if (Nodes[i].MyCildren[k].Name == Opened[z].Name)
                                        { Flag = 1; break; }
                                    }
                                    if (Flag == 0)
                                    {
                                        for (z = 0; z < Closed.Count; z++)
                                        {
                                            if (Nodes[i].MyCildren[k].Name == Closed[z].Name)
                                            { Flag = 1; break; }
                                        }
                                    }
                                    if (Flag == 0)
                                    { Temp.Add(Nodes[i].MyCildren[k]); }
                                }
                            }
                            for (j = 1; j < Opened.Count; j++)
                            {
                                Temp.Add(Opened[j]);
                            }
                            Opened = Temp;

                            New = new History();
                            New.Opened = Opened;
                            for (j = 0; j < Closed.Count; j++)
                            {
                                New.Closed.Add(Closed[j]);
                            }
                            All.Add(New);
                        }
                        break;
                    }
                }
            }
        }

        static public void Print_Opend_And_Closed()
        {
            Console.WriteLine("Opened           Closed");
            int i = 0, j= 0;
            for (i = 0; i < All.Count; i++)
            {
                Console.Write("[");
                for (j = 0; j < All[i].Opened.Count; j++)
                {
                    if (j == All[i].Opened.Count-1)
                        Console.Write(All[i].Opened[j].Name + "]");
                    else
                    Console.Write(All[i].Opened[j].Name + ",");
                }
                if (All[i].Closed.Count == 0)
                {
                    Console.Write("                [");
                    Console.WriteLine("]");
                }
                else
                {
                    Console.Write("            [");
                    for (j = 0; j < All[i].Closed.Count; j++)
                    {
                        if (j == All[i].Closed.Count - 1)
                            Console.WriteLine(All[i].Closed[j].Name + "]");
                        else
                            Console.Write(All[i].Closed[j].Name + ",");
                       
                    }
                }
            }

            j = Console.Read();
        }
    }
}
