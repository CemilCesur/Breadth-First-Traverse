using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT
{
    class Queue
    {
        private int SIZE = 20;
        private int[] queArray;
        private int front;
        private int rear;
        public Queue() 
        {
            queArray = new int[SIZE];
            front = 0;
            rear = -1;
        }

        public void insert(int j) 
        {
            if (rear == SIZE - 1)
                rear = -1;
            queArray[++rear] = j;
        }
        public int remove()
        {
            int temp = queArray[front++];
            if (front == SIZE)
                front = 0;
            return temp;
        }
        public Boolean isEmpty() 
        {return (rear + 1 == front || (front + SIZE - 1 == rear)); }} 
    class Vertex
    {
        public char label;
        public Boolean wasVisited;
        public Vertex(char lab) 
        {label = lab; wasVisited = false;}} 
    class Graph
    {
        private int MAX_VERTS = 20;
        private Vertex[] vertexList; 
        private int[,] adjMat; 
        private int nVerts; 
        private Queue theQueue;
        public Graph() 
        {
            vertexList = new Vertex[MAX_VERTS];
            adjMat = new int[MAX_VERTS,MAX_VERTS];
            nVerts = 0;
            for (int j = 0; j < MAX_VERTS; j++) 
                for (int k = 0; k < MAX_VERTS; k++) 
                    adjMat[j,k] = 0;
            theQueue = new Queue();}
        public void addVertex(char lab)
        {vertexList[nVerts++] = new Vertex(lab);}
        public void addEdge(int start, int end)
        {
            adjMat[start,end] = 1;
            adjMat[end,start] = 1;}
        public void displayVertex(int v)
        {
            Console.WriteLine(vertexList[v].label);
        }
        public void bfs() 
        { 
            vertexList[0].wasVisited = true; 
            displayVertex(0); 
            theQueue.insert(0); 
            int v2;
            while (!theQueue.isEmpty()) 
            {
                int v1 = theQueue.remove(); 
                while ((v2 = getAdjUnvisitedVertex(v1)) != -1)
                { 
                    vertexList[v2].wasVisited = true; 
                    displayVertex(v2); 
                    theQueue.insert(v2);
                } 
            } 

            for (int j = 0; j < nVerts; j++) 
                vertexList[j].wasVisited = false;
        }
        public int getAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j < nVerts; j++)
                if (adjMat[v,j] == 1 && vertexList[j].wasVisited == false)
                    return j;
            return -1;
        } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph theGraph = new Graph();
            theGraph.addVertex('0'); 
            theGraph.addVertex('1'); 
            theGraph.addVertex('2'); 
            theGraph.addVertex('3');
            theGraph.addVertex('4');
            theGraph.addEdge(0, 3);
            theGraph.addEdge(1, 2);
            theGraph.addEdge(1, 3);
            theGraph.addEdge(1, 4);
            theGraph.addEdge(2, 4);
            Console.WriteLine("Geçtilen Yerler: ");
            theGraph.bfs(); 
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
