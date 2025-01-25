using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Neetcode.ArraysAndHashing
{
    public class _Set
    {
        public class Node<T> : IEnumerable<Node<T>>
        {
            public Node<T>? Next { get; set; }
            public T? Value { get; set; }

            public bool HasValue(T value)
            {
                if (Value == null)
                    return false;
                if (Value.Equals(value))
                    return true;
                if (Next == null)
                    return false;
                return Next.HasValue(value);
            }

            public IEnumerator<Node<T>> GetEnumerator()
            {
                var current = this;
                while (current != null)
                {
                    yield return current;
                    current = current.Next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class Set<T>
        {
            private Node<T>[] _hashes;
            private int _fill;

            public Set()
            {
                _hashes = new Node<T>[17];
            }

            public bool Contains(T value)
            {
                if (value == null)
                    throw new ArgumentNullException();

                var position = GetPosition(value);

                if (position < 0 || position >= _hashes.Length)
                    throw new IndexOutOfRangeException("out of range");

                var nodes =  _hashes[position];

                return nodes != null && nodes.HasValue(value);
            }

            public int GetPosition(T value)
            {
                if(value == null)
                    return 0;

                return value.GetHashCode() % _hashes.Length;
            }

            public void Add(T value)
            {
                if (Contains(value))
                    return;
                
                if (((_hashes.Length / 4) * 3) < _fill)
                    Grow();

                var position = GetPosition(value);
                if (_hashes[position] == null)
                {
                    _hashes[position] = new Node<T> { Value = value };
                }
                else
                {
                    _hashes[position].Next = new Node<T> { Value = value };
                }
            }

            private void Grow()
            {
                var temp = _hashes;
                _hashes = new Node<T>[_hashes.Length * 2];
                foreach(var entry in _hashes)
                    foreach(var node in entry)
                        if(node != null && node.Value != null)
                            Add(node.Value);
            }
        }

        [Fact]
        public void Test1()
        {
            var set = new _Set.Set<int>();
            
            Assert.False(set.Contains(1));

            set.Add(1);

            Assert.True(set.Contains(1));

            set.Add(1);

            Assert.True(set.Contains(1));
            
        }
    }


}

