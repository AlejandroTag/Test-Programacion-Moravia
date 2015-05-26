using PruebaMoraviaWebService.Logical;
using PruebaMoraviaWebService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaMoraviaWebService.ViewsModels
{
    public class CommentViewModel
    {
        public Comment comment;

        public string UserName
        {
            get
            {
                return comment.UserName;
            }
        }

        public string CommentDescription
        {
            get
            {
                return comment.CommentDescription;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return comment.Fecha;
            }
        }

        public string TimeAgo
        {
            get
            {
                return CalculateTimeAgo.Calculate(comment.Fecha);
            }
        }
    }
}