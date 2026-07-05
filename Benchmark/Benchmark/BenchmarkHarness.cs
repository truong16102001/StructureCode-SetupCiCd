using Benchmark.Services;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [HtmlExporter]
    public class BenchmarkHarness
    {
        [Params(1, 5)]
        public int IterationCount;
        private readonly StudentHttpClient _studentHttpClient = new StudentHttpClient();
        private readonly StudentGoodHttpClient _studentGoodHttpClient = new StudentGoodHttpClient();

        /// <summary>
        /// Has data within Include statement (not have AsNoTracking();)
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task Student_GetStudentDetails()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentHttpClient.GetStudentDetailsAsync();
            }
        }
        /// <summary>
        /// Has data within Include statement (have AsNoTracking();)
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task StudentGood_GetStudentDetails()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentGoodHttpClient.GetStudentDetailsAsync();
            }
        }

        /// <summary>
        /// Not found data to see  if SplitQuery has faster or not
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task Student_GetStudentDetailsByIdNotFound()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentHttpClient.GetStudentDetailsByIdAsync();
            }
        }
        /// <summary>
        /// has AsNoTracking and splitquery
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task StudentGood_GetStudentDetailsByIdNotFound()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentGoodHttpClient.GetStudentDetailsByIdAsync();
            }
        }

        /// <summary>
        /// Has no data within Include statement
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task Student_GetStudents()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentHttpClient.GetStudentAsync();
            }
        }
        /// <summary>
        /// has AsNoTracking and splitquery
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task StudentGood_GetStudents()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentGoodHttpClient.GetStudentAsync();
            }
        }

        /// <summary>
        /// FindById (Sync)
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task Student_GetStudentsByIdAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentHttpClient.GetStudentByIdAsync();
            }
        }
        /// <summary>
        /// FindById (Async)
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task StudentGood_GetStudentsByIdAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentGoodHttpClient.GetStudentByIdAsync();
            }
        }

        /// <summary>
        /// FindByCondition (Sync)
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task Student_GetStudentsByConditionAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentHttpClient.GetStudentByIdAsync();
            }
        }
        /// <summary>
        /// FindByCondition (Async)
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task StudentGood_GetStudentsByConditionAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentGoodHttpClient.GetStudentByIdAsync();
            }
        }
    }
}
