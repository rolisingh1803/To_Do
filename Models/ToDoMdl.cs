using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.Models
{
    public class ToDoMdl
    {
        [Key]
        public int Id { get; set; }


        public string Title { get; set; }

        public string Description { get; set; }

       // public DateTime? CreatedDate { get; set; }
        public string strCreatedDate { get; set; }

        //public DateTime? UpdatedDate { get; set; }
        public string strUpdatedDate { get; set; }

        public Boolean Checkbox { get; set; }
        
        public int userid { get; set; }
     
    }

    
}