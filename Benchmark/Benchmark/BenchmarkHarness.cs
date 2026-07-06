using Benchmark.Services;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [HtmlExporter]
    public class BenchmarkHarness
    {
        // BenchmarkDotNet se chay moi benchmark 2 bo: 1 lan goi API va 5 lan goi API.
        [Params(1, 5)]
        public int IterationCount;

        // StudentHttpClient goi API baseline; StudentGoodHttpClient goi API da toi uu.
        private readonly StudentHttpClient _studentHttpClient = new StudentHttpClient();
        private readonly StudentGoodHttpClient _studentGoodHttpClient = new StudentGoodHttpClient();

        /// <summary>
        /// Baseline doc du lieu co Include. EF Core track toan bo entity graph tra ve.
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
        /// Ban Good doc du lieu co Include + AsNoTracking. Cung data shape, it overhead tracking hon.
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
        /// Baseline query Include voi id khong ton tai. Case nay van ghep Include truoc khi filter.
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
        /// Ban Good voi id khong ton tai, co AsNoTracking va cau hinh SplitQuery cua API.
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
        /// Baseline lay danh sach Student khong Include navigation data.
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
        /// Ban Good lay danh sach khong Include, dung AsNoTracking vi chi doc du lieu.
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
        /// Baseline FindById dung query EF Core dong bo.
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
        /// Ban Good FindById dung query EF Core async.
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
        /// Baseline tim theo dieu kien dung query EF Core dong bo.
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task Student_GetStudentsByConditionAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentHttpClient.GetStudentByConditionAsync();
            }
        }
        /// <summary>
        /// Ban Good tim theo dieu kien dung query EF Core async.
        /// </summary>
        /// <returns></returns>
        [Benchmark]
        public async Task StudentGood_GetStudentsByConditionAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _studentGoodHttpClient.GetStudentByConditionAsync();
            }
        }
    }
}
