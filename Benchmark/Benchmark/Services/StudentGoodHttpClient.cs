using Benchmark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Services
{
    public class StudentGoodHttpClient
    {
        private static readonly HttpClient client = new HttpClient();
        private const string BaseAddress = "http://localhost:5153/api/StudentsGood";

        public StudentGoodHttpClient()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Student>> GetStudentDetailsAsync()
        {
            return await client.GetFromJsonAsync<List<Student>>($"{BaseAddress}/student-with-details-good");
        }

        public async Task<List<Student>> GetStudentDetailsByIdAsync()
        {
            return await client.GetFromJsonAsync<List<Student>>($"{BaseAddress}/student-with-details-by-id-good");
        }

        public async Task<List<Student>> GetStudentAsync()
        {
            return await client.GetFromJsonAsync<List<Student>>($"{BaseAddress}/students-good");
        }

        public async Task<List<Student>> GetStudentByIdAsync()
        {
            return await client.GetFromJsonAsync<List<Student>>($"{BaseAddress}/students-by-id-good");
        }

        public async Task<List<Student>> GetStudentByConditionAsync()
        {
            return await client.GetFromJsonAsync<List<Student>>($"{BaseAddress}/students-by-condition-good");
        }
    }
}
