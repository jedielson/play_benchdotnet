using BenchmarkDotNet.Attributes;

namespace BoundCheck.Teste
{
    [DisassemblyDiagnoser(exportCombinedDisassemblyReport: true)]
    public class BenchBoundCheck
    {
        int[] _a;

        public BenchBoundCheck()
        {
            _a = new int[100000];
        }

        [Benchmark(Baseline = true)]
        public void Slow()
        {
            for (int i = 0; i < _a.Length; i++)
            {
                _a[i] = i;
            }
        }

        [Benchmark]
        public void Fast()
        {
            var a = _a;
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i;
            }
        }
    }
}