using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHDemo
{
    public class Cat
    {
        private string id;
        private string name;
        private char sex;
        private float weight;

        public Cat()
        {
        }

        public virtual string Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual char Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public virtual float Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}