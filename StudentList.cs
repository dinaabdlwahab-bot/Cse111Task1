// Name: Dina Abdelwahab Rizk Abdelwahab
// Student ID: 225114303

using System;
using System.Text;

namespace Cse111Task1
{
    public class StudentList
    {
        public Student? First;
        public Student? Last;
        public int Count;
        public void AddFront(int id)
        {
            Student node = new Student(id);
            node.Next = First;
            First = node;
            if (Last == null)
                Last = node;
            Count++;
        }
                public void AddEnd(int id)
        {
            Student node = new Student(id);
            if (Last == null)
            {
                First = node;
                Last = node;
            }
            else
            {
                Last.Next = node;
                Last = node;
            }
            Count++;
        }
        public bool Remove(int id)
        {
            Student? prev = null;
            Student? cur = First;

            while (cur != null)
            {
                if (cur.Id == id)
                {
                    if (prev == null)
                        First = cur.Next;    
                    else
                        prev.Next = cur.Next;  
                    if (cur == Last)
                        Last = prev;          

                    Count--;
                    return true;
                }
                prev = cur;
                cur = cur.Next;
            }
            return false;
        }
        public void Reverse()
        {
            Student? prev = null;
            Student? cur = First;
            Last = First;

            while (cur != null)
            {
                Student? next = cur.Next; 
                cur.Next = prev;
                prev = cur;
                cur = next;
            }
            First = prev;
        }

        public void Print()
        {
            StringBuilder sb = new StringBuilder();
            Student? cur = First;
            while (cur != null)
            {
                if (sb.Length > 0)
                    sb.Append(' ');
                sb.Append(cur.Id);
                cur = cur.Next;
            }
            Console.WriteLine(sb.ToString());
        }
    }

    public class Program
    {
        public static void Main()
        {
            StudentList list = new StudentList();
            list.AddFront(20);
            list.AddFront(10);
            list.AddEnd(30);
            list.AddEnd(40);
            list.Print();                
            list.Reverse();
            list.Print();               
            list.Remove(20);
            list.Print();                 
            Console.WriteLine($"First={list.First?.Id} Last={list.Last?.Id} Count={list.Count}");
        }
    }
}