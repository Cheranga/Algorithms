using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Interesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new SinglyLinkedList<int>().Add(1).Add(2).Add(3);

            //var b = a.GetElementAt(4);

            var inputString = "cat! oh bloody cat!$#$";

            var stack = new Stack<char>();

            var output = new ReverseStringWithStacks().Get("cat and dog", ' ');

        }
    }
}
