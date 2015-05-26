using PruebaMoraviaWebService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PruebaMoraviaWebService.Models
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            //key  
            HasKey(t => t.CommentId);

            //relationship  
            //HasRequired(t => t.Usuario).WithMany(c => c.Comments).HasForeignKey(t => t.UserName).WillCascadeOnDelete(false);
        }
    }  
}