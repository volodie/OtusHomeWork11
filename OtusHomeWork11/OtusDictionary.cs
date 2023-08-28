using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomeWork11
{
    internal class OtusDictionary
    {
        int size = 32;
        OtusKeyValuePair[] values;

        public OtusDictionary()
        {
            values = new OtusKeyValuePair[size];
        }

        public string this[int key]
        {
            get { return Get(key); }
            set { Add(key, value); }
        }

        public void Add(int key, string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            var hash = GetHash(key);

            while (values[hash] != null)
            {
                if (values[hash].Key == key) throw new ArgumentException("Ключ уже существует.");

                values = IncreaseArraySize();
            }

            values[hash] = new OtusKeyValuePair() { Key = key, Value = value };
        }

        public string Get(int key) => values[GetHash(key)] != null
            ? values[GetHash(key)].Value
            : throw new ArgumentOutOfRangeException(nameof(key));

        OtusKeyValuePair[] IncreaseArraySize()
        {
            size *= 2;

            var newValues = new OtusKeyValuePair[size];

            foreach (var pair in values)
            {
                if (pair == null) continue;

                var hash = GetHash(pair.Key);

                if (newValues[hash] != null) return IncreaseArraySize();

                newValues[hash] = pair;
            }

            return newValues;
        }

        int GetHash(int key) => Math.Abs(key % size);

        class OtusKeyValuePair
        {
            public int Key { get; set; }
            public string Value { get; set; } = null!;
        }
    }
}
