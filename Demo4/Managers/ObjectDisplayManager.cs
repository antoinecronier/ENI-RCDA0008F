using Demo4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo4.Managers
{
    public class ObjectDisplayManager<T,T1> where T1 : User where T : IDisplayable
    {
        private T item;

        public ObjectDisplayManager(T item)
        {
            this.item = item;
        }

        public void Show()
        {
            item.Show();
        }

        public void Show2<K>() where K : new()
        {
            K item1 = new K();
        }

        public int Yololo()
        {
            return 2;
        }
    }
}
