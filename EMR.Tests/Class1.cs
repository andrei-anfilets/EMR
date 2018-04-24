using System;
using System.Collections.Generic;

namespace EMR.DAL.Models
{
    public class Category
    {
        public int id { get; set; }
        public string title { get; set; }
        public string color { get; set; }
    }

    public class CrmPerson
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public List<Category> categories { get; set; }
        public string sex { get; set; }
        public int sex_id { get; set; }
        public int discount { get; set; }
        public int importance_id { get; set; }
        public string importance { get; set; }
        public string card { get; set; }
        public string birth_date { get; set; }
        public string comment { get; set; }
        public int sms_check { get; set; }
        public int sms_not { get; set; }
        public int spent { get; set; }
        public int paid { get; set; }
        public int balance { get; set; }
        public int visits { get; set; }
    }

    public class RootObject
    {
        public int count { get; set; }
        public List<CrmPerson> data { get; set; }
    }
}
