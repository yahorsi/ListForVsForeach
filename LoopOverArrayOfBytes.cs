using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace ListForVsForeach
{
    public class LoopOverArrayOfBytes
    {
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

    }
}
