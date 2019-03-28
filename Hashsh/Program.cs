using System;
using System.Collections.Generic;
using System.Linq;


namespace Hash
{	
    public class Program
    {
        class DataHash
        {
            public readonly int Key;
            public object Value;
            public DataHash(int key, object value)
            {
                Key = key;
                Value = value;
            }
        }
        public class HashTable
        {
            private List<DataHash>[] list;

            public HashTable(int size)
            {
                list = new List<DataHash>[size];
            }

            public void PutPair(object key, object value)
            {
                var keyHashCode = key.GetHashCode();
                var id = Math.Abs(keyHashCode) % list.Length;

                if (list[id] == null)
                {
                    list[id] = new List<DataHash> { new DataHash(keyHashCode, value) };
                }
                else
                {
                    var val = list[id].FirstOrDefault(x => x.Key == keyHashCode);

                    if (val != null)
                        val.Value = value;
                    else
                        list[id].Add(new DataHash(keyHashCode, value));
                }
            }


            public object GetValueByKey(object key)
            {
                try
                {
                    var keyHashCode = key.GetHashCode();
                    var value = list[Math.Abs(keyHashCode) % list.Length];
                    return value.Find(x => x.Key == keyHashCode).Value;
                }
                catch
                {
                    return null;
                }
            }      
        }

        static void Main(string[] args)
        {
        }
    }  
}


