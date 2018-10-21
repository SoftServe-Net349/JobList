namespace JobList.Common.UrlQuery
{
    public class VacancyUrlQuery
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string WorkArea { get; set; }
        public string[] NamesOfCompanies { get; set; }
        public bool IsChecked { get; set; }
        public string TypeOfEmployment { get; set; }
        public decimal? Salary { get; set; }
    }
}
