using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using ListNew = System.Collections.GenericNew.List<byte>;

namespace ListForVsForeach
{
    public class LoopOverArrayOfBytes
    {
        private ListNew _byteDataListNew;
        private List<byte> _byteDataList;

        [Params(16, 256, 1024)]
        public int N { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var byteData = new byte[N];

            for (int i = 0; i < byteData.Length; ++i)
            {
                byteData[i] = (byte)i;
            }

            _byteDataList = new List<byte>(byteData.Length);
            _byteDataList.AddRange(byteData);

            _byteDataListNew = new ListNew(byteData.Length);
            _byteDataListNew.AddRange(byteData);
        }

        [Benchmark(Baseline = true)]
        public int For()
        {
            var data = _byteDataList;
            int sum = 0;

            for (int i = 0; i < data.Count; ++i)
            {
                sum += data[i];
            }

            return sum;
        }

        public int ForNew()
        {
            var data = _byteDataListNew;
            int sum = 0;

            for (int i = 0; i < data.Count; ++i)
            {
                sum += data[i];
            }

            return sum;
        }

        [Benchmark]
        public int Foreach()
        {
            var data = _byteDataList;
            int sum = 0;

            foreach (var n in data)
            {
                sum += n;
            }

            return sum;
        }

        [Benchmark]
        public int ForeachNew()
        {
            var data = _byteDataListNew;
            int sum = 0;

            foreach (var n in data)
            {
                sum += n;
            }

            return sum;
        }
    }
}
