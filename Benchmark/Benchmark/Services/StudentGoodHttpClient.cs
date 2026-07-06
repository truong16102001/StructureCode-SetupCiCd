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
        private const string BaseAddress = "http://localhost:5154/api/StudentsGood";
        // db.sql co seed StudentId nay, nen benchmark ById/Condition se tra ve du lieu that.
        private const string ExistingStudentId = "00000000-0000-0000-0000-000000000001";
        // Guid dung format nhung khong co trong DB, dung de benchmark case not-found ma khong bi 400.
        private const string NotFoundStudentId = "99999999-9999-9999-9999-999999999999";

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
            return await client.GetFromJsonAsync<List<Student>>($"{BaseAddress}/student-with-details-by-id-good?id={NotFoundStudentId}");
        }

        public async Task<List<Student>> GetStudentAsync()
        {
            return await client.GetFromJsonAsync<List<Student>>($"{BaseAddress}/students-good");
        }

        public async Task<Student?> GetStudentByIdAsync()
        {
            return await client.GetFromJsonAsync<Student>($"{BaseAddress}/students-by-id-good?id={ExistingStudentId}");
        }

        public async Task<Student?> GetStudentByConditionAsync()
        {
            return await client.GetFromJsonAsync<Student>($"{BaseAddress}/students-by-condition-good?id={ExistingStudentId}");
        }
    }
}
