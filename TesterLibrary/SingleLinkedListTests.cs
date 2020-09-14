using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace TesterLibrary
{
    public class SingleLinkedListTests
    {
        [Fact]
        public void CreateListMultipleValues()
        {
            var sut = new SingleLinkedList();

            var list = new List<int>()
            {
                1,2,3,4,5
            };


            foreach(var item in list)
                sut.AddToEnd(item);


            Assert.Equal(list, sut.ToList());


        }
        

        [Fact]
        public void ShouldBeAbleToReverseAList()
        {
            var list1 = new SingleLinkedList();

            foreach(var i in Enumerable.Range(1,5)) {
                list1.AddToEnd(i);
            }

            var list1Result = list1.ToList();

            var list2 = new SingleLinkedList();

            while(!list1.IsEmpty) {
                list2.AddToStart( list1.RemoveFromStart() );
            }

            var list2Result = list2.ToList();

            var expected1 = new List<int>() { 1,2,3,4,5 };
            var expected2 = new List<int>() { 5,4,3,2,1 };

            Assert.Equal(expected1, list1Result);
            Assert.Equal(expected2, list2Result);

            Assert.Equal(0, list1.Count());
            Assert.Equal(5, list2.Count());

        }

        [Fact]
        public void ShouldBeAbleToCountAList()
        {
            var list = new SingleLinkedList();

            list.AddToStart(1);
            list.AddToStart(2);

            Assert.Equal(new List<int>{2,1}, list.ToList());

        }  

        [Fact]
        public void ShouldBeAbleToEnumerate()
        {
            var list = new SingleLinkedList();

            list.AddToEnd(1);
            list.AddToEnd(2);
            list.AddToEnd(3);
            list.AddToEnd(4);

            var morethanTwo = list.Where(x => x > 2).ToArray();
            var first = list.First();

            Assert.Equal(new List<int>{3,4}, morethanTwo.ToList());
            Assert.Equal(1, first);

            Assert.Equal(10, list.Sum());
        }

        [Fact]
        public void ShouldBeAbleToAdd1000ToEnd()
        {
            var list = new SingleLinkedList();

            var watch = new Stopwatch();

            watch.Start();

            foreach (var i in Enumerable.Range(1, 100000))
                list.AddToStart(i);

            var list2 = new SingleLinkedList();

            while (!list.IsEmpty)
                list2.AddToStart(list.RemoveFromStart()); //89166 -- 86558

            watch.Stop();

            Console.WriteLine($"Adding 1000 to end {watch.ElapsedTicks}");
            Assert.Equal(100, watch.ElapsedTicks);
         }

        [Fact]
        public void ShouldBeAbleToAdd1000ToBeginning()
        {
            var list = new SingleLinkedList();

            var watch = new Stopwatch();

            watch.Start();

            foreach (var i in Enumerable.Range(1, 100000))
                list.AddToStart(i);



            watch.Stop();

            Console.WriteLine($"Adding 1000 to Beginning {watch.ElapsedTicks}");
            Assert.Equal(100, watch.ElapsedTicks);
        }
    }
}
