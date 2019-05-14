using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValue
{
    public class Program
    {
        //1. Create a struct named `KeyValue` which contains one `string` "key" and one `object` "value" as `public readonly` instance fields
        struct KeyValue
        {
            public readonly string key;
            public readonly object value;

            public KeyValue(string searchKey, object value)
            {
                this.key = searchKey;
                this.value = value;
            }
        }

        class MyDictionary
        {
            KeyValue[] kvs = new KeyValue[16];
            int storedValues = 0;
        }

        public object this[string key]
        {
            set
            {
                bool found = false;
                for (int i = 0; i < storedValues & !found; ++i)
                {
                    if (kvs[i].key == searchKey)
                    {
                        return kvs[i].value;
                    }
                }
                if (!found)
                {
                    kvs[storedValues++] = new KeyValue(key, value);
                }
            }

            get
            {
                bool found = false;
                for (int i = 0; i < storedValues; ++i)
                {
                    if (kvs[i].key == searchKey)
                    {
                        return kvs[i].value;
                    }
                    throw new KeyNotFoundException($"Didn't find\"{searchKey}\" in MyDictionary");
                }
        }

    


    static void Main(string[] args)
    {
            var d = new MyDictionary();
            try
            {
                Console.WriteLine(d["Cats"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            d["Cats"] = 42;
            d["Dogs"] = 17;
            Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");
        }
    }
}
}
