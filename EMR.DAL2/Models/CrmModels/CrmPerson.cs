using System.Collections.Generic;
using System;
using EMR.DAL2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EMR.DAL.Models
{
    public class CrmPerson
    {
        public Int64 id { get; set; }
        [MaxLength(200, ErrorMessage = "Превышена максимальная длина поля")]
        public string name { get; set; }
        [MaxLength(200, ErrorMessage = "Превышена максимальная длина поля")]
        public string phone { get; set; }
        [MaxLength(200, ErrorMessage = "Превышена максимальная длина поля")]
        public string email { get; set; }
        public List<Category> categories { get; set; }
        [MaxLength(20, ErrorMessage = "Превышена максимальная длина поля - 20")]
        public string sex { get; set; }
        public int sex_id { get; set; }
        public int discount { get; set; }
        public int importance_id { get; set; }
        [MaxLength(200, ErrorMessage = "Превышена максимальная длина поля")]
        public string importance { get; set; }
        [MaxLength(200, ErrorMessage = "Превышена максимальная длина поля")]
        public string card { get; set; }
        [MaxLength(30, ErrorMessage = "Превышена максимальная длина поля")]
        public string birth_date { get; set; }
        [MaxLength(1000, ErrorMessage = "Превышена максимальная длина поля")]
        public string comment { get; set; }
        public int sms_check { get; set; }
        public int sms_not { get; set; }
        public int spent { get; set; }
        public int paid { get; set; }
        public int balance { get; set; }
        public int visits { get; set; }

        [ForeignKey("Person_Id")]
        public Person Person { get; set; }
        public Int64? Person_Id { get; set; }

        public Boolean Deleted { get; set; }
    }
}
