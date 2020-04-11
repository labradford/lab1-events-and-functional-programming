using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class PointList : IList<Point>
    {
        private List<Point> _Points = new List<Point>();

        public Point this[int index] {
            get 
            {
                return _Points[index];
            }
            set
            {
                _Points[index] = value;
                Changed?.Invoke(this, new PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Update));
            }
        }

        public int Count
        {
            get
            {
                return _Points.Count;
            }
        }

        public bool IsReadOnly 
        {
            get
            {
                return ((ICollection<Point>)_Points).IsReadOnly;
            }
        }

        public event EventHandler<PointListChangedEventArgs> Changed;

        public PointList()
        {
        }

        public void Add(Point item)
        {
            ((IList<Point>)_Points).Add(item);
            Changed?.Invoke(this, new PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Add));
        }

        public void Clear()
        {
            ((IList<Point>)_Points).Clear();
            Changed?.Invoke(this, new PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Clear));
        }

        public bool Contains(Point item)
        {
            return ((IList<Point>)_Points).Contains(item);
        }

        public void CopyTo(Point[] array, int arrayIndex)
        {
            ((IList<Point>)_Points).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return ((IList<Point>)_Points).GetEnumerator();
        }

        public int IndexOf(Point item)
        {
            return ((IList<Point>)_Points).IndexOf(item);
        }

        public void Insert(int index, Point item)
        {
            ((IList<Point>)_Points).Insert(index, item);
            Changed?.Invoke(this, new PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Insert));
        }

        public bool Remove(Point item)
        {
            bool success = false;
            if (((IList<Point>)_Points).Remove(item))
            {
                Changed?.Invoke(this, new PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Remove));
                success = true;
            }
            return success;
        }

        public void RemoveAt(int index)
        {
            ((IList<Point>)_Points).RemoveAt(index);
            Changed?.Invoke(this, new PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Remove));
        }

        public static bool InFirstQuadrant(Point item)
        {
            return item.X > 0 && item.Y > 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<Point>)_Points).GetEnumerator();
        }
    }
}
