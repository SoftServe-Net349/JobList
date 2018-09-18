using JobList.Common.Enums;
using System;

namespace JobList.Common.Requests
{
    public class SampleRequest
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public DateTime DateOfCreation { get; set; }

        public SampleEnum SampleField { get; set; }
    }
}
