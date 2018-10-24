﻿namespace JobList.Common.UrlQuery
{
    public class ResumeUrlQuery
    {
        public string Position { get; set; }
        public string City { get; set; }
        public string WorkArea { get; set; }
        public string[] Schools { get; set; }
        public string[] Faculties { get; set; }
        public int? StartAge { get; set; }
        public int? FinishAge { get; set; }
        public string[] Languages { get; set; }
    }
}
